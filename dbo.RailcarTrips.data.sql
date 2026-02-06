SET IDENTITY_INSERT [dbo].[RailcarTrips] ON
INSERT INTO [dbo].[RailcarTrips] ([TripId], [EquipmetId], [DateProcessed], [UserName], [isActive]) VALUES (1, N'ACAR1234', N'2026-02-05 00:00:00', N'aborjas', 1)
SET IDENTITY_INSERT [dbo].[RailcarTrips] OFF


select TripId, count(Id) 
from [dbo].[EquipmentEvents]
group by TripId
order by count(Id)

truncate table EquipmentEvents;
truncate table RailcarTrips;

drop table EquipmentEvents;
drop table RailcarTrips;
drop table Cities;
drop table EventCodes;
