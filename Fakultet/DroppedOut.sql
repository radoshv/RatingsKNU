CREATE TABLE [dbo].[DroppedOut]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SpecName] VARCHAR(100) NULL, 
    [SpecCode] VARCHAR(100) NULL, 
    [StydyForm] VARCHAR(100) NULL, 
    [PaymentForm] VARCHAR(100) NULL, 
    [Reason] NCHAR(10) NULL
)
