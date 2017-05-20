USE RatingsKNU;
GO

create table FinancialSupport(
RecordId int,
UniId int,
UniName varchar(100),
GeneralNatFundCurrYear varchar(100),
SpecialNatFundForActivity varchar(100),
StudentsMaintenanceCost varchar(100),
NewEquipmentCost varchar(100),
Currency varchar(100),
primary key(RecordId)
)