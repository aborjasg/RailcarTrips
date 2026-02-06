using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RailcarTrips.Models;
using RailcarTrips.Utils;

namespace RailcarTrips.Components.Pages
{
    public partial class Home
    {
        private List<RailcarTrip> RailcarTripList { get; set; } = [];
        private List<EquipmentEvent> EquipmentEventList { get; set; } = [];
        private List<EventCode> EventCodeList { get; set; } = [];
        private List<City> CityList { get; set; } = [];
        private List<RailcarTrip_View> RailcarTrip_ViewList { get; set; } = [];
        private List<EquipmentEvent_View> EquipmentEvent_ViewList { get; set; } = [];
        
        private IBrowserFile? uploadedFile;
        private string MessageImport { set; get; } = string.Empty;
        private bool ShowPopup = false;

        private readonly ILogger<Home> _logger;

        #region "CRUD methods"

        private async Task EventCode_LoadList()
        {
            EventCodeList = await _dbContext.EventCodes.ToListAsync();            
        }

        private async Task City_LoadList()
        {
            CityList = await _dbContext.Cities.ToListAsync();
        }

        private async Task RailcarTrip_LoadList()
        {
            RailcarTripList = await _dbContext.RailcarTrips.ToListAsync();

            foreach (var record in RailcarTripList)
            {
                RailcarTrip_ViewList.Add(new RailcarTrip_View()
                {
                    TripId = record.TripId,
                    EquipmetId = record.EquipmetId,
                    OriginCityName = CityList.FirstOrDefault(x => x.Id == record.OriginCityId)!.Name,
                    StartDate = record.StartDate,
                    DestinationCityName = CityList.FirstOrDefault(x => x.Id == record.DestinationCityId)!.Name,
                    EndDate = record.EndDate,
                    TotalTripHours = record.TotalTripHours,
                    UserName = record.UserName,
                    isActive= record.isActive
                });
            }
        }

        private async Task<int> RailcarTrip_SaveRecord(RailcarTrip record)
        {            
            _dbContext.RailcarTrips.Add(record);
            await _dbContext.SaveChangesAsync();
            return record.TripId; // Get the PK Id
        }

        private async Task RailcarTrip_Details(int recordId)
        {
            EquipmentEvent_ViewList = new();

            if (recordId > 0)
            {
                EquipmentEventList = await _dbContext.EquipmentEvents.Where(x => x.TripId == recordId).ToListAsync();

                foreach (var record in EquipmentEventList)
                {
                    EquipmentEvent_ViewList.Add(new EquipmentEvent_View()
                    {
                        Id = record.Id,
                        TripId = record.TripId,
                        EventId = record.EventId,
                        EventDescription = EventCodeList.FirstOrDefault(x => x.Id == record.EventId)!.EventDescription,
                        EventTime = record.EventTime,
                        CityId = record.CityId,
                        CityName = CityList.FirstOrDefault(x => x.Id == record.CityId)!.Name,
                        CityTimeZone = CityList.FirstOrDefault(x => x.Id == record.CityId)!.TimeZone
                    });
                }
                ShowPopup = true;
            }
        }

        private async Task RailcarTrip_DeleteRecord(int recordId)
        {
            var record = _dbContext.RailcarTrips.Where(x => x.TripId == recordId).FirstOrDefault();
            _dbContext.RailcarTrips.Remove(record!);
            await _dbContext.SaveChangesAsync();

            // Refresh data grid
            await RailcarTrip_LoadList();
        }

        private async Task EquipmentEvent_SaveList(int parentId, List<EquipmentEvent> list)
        {
            foreach (var record in list)
            {
                record.TripId = parentId;
                _dbContext.EquipmentEvents.Add(record);
            }
            _dbContext.SaveChanges();
        }

        #endregion

        public Home(ILogger<Home> logger)
        {
            _logger = logger;
        }

        protected override async Task OnInitializedAsync()
        {            
            await EventCode_LoadList();
            await City_LoadList();
            await RailcarTrip_LoadList();
        }

        /// <summary>
        ///  Select the CSV file
        /// </summary>
        /// <param name="e"></param>
        private void LoadCsvFile(InputFileChangeEventArgs e)
        {
            uploadedFile = e.File;
        }

        /// <summary>
        /// Read the CSV content and save complete trips
        /// </summary>
        /// <returns></returns>
        private async Task ProcessCsvFile()
        {
            // 1. Read CSV file:
            if (uploadedFile is null)
            {
                MessageImport = "No Data imported";
                return;
            }

            using var stream = uploadedFile.OpenReadStream();
            using var reader = new StreamReader(stream);

            var importedList = new List<EquipmentEvent_Import>();

            // Validate the header: Equipment Id, Event Code, Event Time  City Id
            var header_line = await reader.ReadLineAsync();
            var header = header_line!.Split(",");

            if (header == null || header.Length != 4)
            {
                MessageImport = "Invalid CSV file";
                return;
            }

            if (!(header[0] == "Equipment Id" &&
                header[1] == "Event Code" &&
                header[2] == "Event Time" &&
                header[3] == "City Id"))
            {
                MessageImport = "Invalid CSV file";
                return;
            }

            // Read the body:
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');

                importedList.Add(new EquipmentEvent_Import
                {
                    EquipmentId = parts[0],
                    EventCode = parts[1],
                    EventTime = DateTime.Parse(parts[2]),
                    CityId = int.Parse(parts[3])
                });
            }

            importedList = importedList.OrderBy(x => x.EquipmentId).ThenBy(x => x.EventTime).ToList();

            // 2. Group by Equipment and sort by Event Time
            bool endOfEvent = false;
            int parentPK = 0, completeTrips = 0, uncompleteTrips = 0;
            List<EquipmentEvent>? listEquipmentEvents = null;

            foreach (var record in importedList)
            {
                // Search start point "W"
                if (record.EventCode == "W")
                {
                    if (listEquipmentEvents != null)
                    {
                        _logger.LogWarning($"[Uncomplete] listEquipmentEvents.Count: {listEquipmentEvents.Count}");
                        uncompleteTrips++;
                    }
                    listEquipmentEvents = new();
                }
                else if (record.EventCode == "Z")
                {
                    _logger.LogInformation($"[Complete] listEquipmentEvents.Count: {listEquipmentEvents!.Count}");
                    endOfEvent = true;
                    completeTrips++;
                }

                if (listEquipmentEvents != null)
                {
                    listEquipmentEvents.Add(new EquipmentEvent()
                    {
                        EventId = record.EventCode,
                        EventTime = record.EventTime,
                        CityId = record.CityId
                    });                  
                }

                if (endOfEvent && listEquipmentEvents != null)
                {
                    // 1. Create the equipment (parent):
                    var startDate = SharedFunctions.ConvertToUtcTime(CityList, listEquipmentEvents[0].EventTime, listEquipmentEvents[0].CityId);
                    var endDate = SharedFunctions.ConvertToUtcTime(CityList, listEquipmentEvents.Last().EventTime, listEquipmentEvents.Last().CityId);

                    parentPK = await RailcarTrip_SaveRecord(new RailcarTrip()
                    {
                        EquipmetId = record.EquipmentId,
                        OriginCityId = listEquipmentEvents[0].CityId,
                        StartDate = startDate,
                        DestinationCityId = listEquipmentEvents.Last().CityId,
                        EndDate = endDate,
                        TotalTripHours = Math.Round((endDate - startDate).TotalHours, 2),
                        UserName = "aborjas"
                    });

                    await EquipmentEvent_SaveList(parentPK, listEquipmentEvents);

                    // Start again
                    endOfEvent = false;
                    listEquipmentEvents = null;
                }

            }

            if (!endOfEvent)
            {
                _logger.LogWarning($"[Uncomplete] listEquipmentEvents.Count: {listEquipmentEvents!.Count}");
                uncompleteTrips++;
            }                

            MessageImport = $"Loaded {importedList.Count} rows | Total Trips = {completeTrips + uncompleteTrips} | Complete Trips = {completeTrips} | Uncomplete Trips = {uncompleteTrips}";
            await RailcarTrip_LoadList();
        }

        private void ClosePopup()
        {
            ShowPopup = false;
        }
    }

}

