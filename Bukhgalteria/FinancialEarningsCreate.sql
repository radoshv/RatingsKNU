
USE RatingsKNU;
GO

-- WRONGS
create table FinancialEarnings(
RecordId int,
UniId int,
UniName varchar(100),
FromNatBudget varchar(100),
EducationCost varchar(100),
ExternalEarnings varchar(100),
PostGraduateEducation varchar(100),
CopyrightEarningsOnNDDKR varchar(100),
OtherEarnings varchar(100),
Total varchar(100),
primary key(RecordId)
)