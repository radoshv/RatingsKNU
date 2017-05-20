
USE RatingsKNU;
GO

create table LiveCost(
RecordId int,
UniId int,
UniName varchar(100),
AverCostCorridor int, 
AverCostBlock int, 
AverCostBetter int, 
AverCostBetterRooms int 
primary key (RecordId)
)