

USE RatingsKNU;
GO

CREATE TABLE [dbo].[ForeignContingent]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Country] VARCHAR(100) NULL, 
    [Sex] VARCHAR(100) NULL, 
    [Language] VARCHAR(100) NULL, 
    [Degree] VARCHAR(100) NULL 
)
