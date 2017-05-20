
USE RatingsKNU;
GO

CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SpecName] VARCHAR(100) NULL, 
    [SpecCode] VARCHAR(100) NULL, 
    [DailyForm] VARCHAR(100) NULL, 
    [StudenSex] VARCHAR(100) NULL, 
    [PaymentForm] VARCHAR(100) NULL 
)
