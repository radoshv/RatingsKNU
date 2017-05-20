
USE RatingsKNU;
GO

CREATE TABLE [dbo].[SpecialisationCapacity]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Degree] VARCHAR(100) NULL, 
    [StudyForm] VARCHAR(10) NULL, 
    [LicensedCapacity] INT NULL
)
