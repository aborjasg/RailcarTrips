
select TripId, count(Id) 
from [dbo].[EquipmentEvents]
group by TripId
order by TripId