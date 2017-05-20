
USE RatingsKNU;
GO

CREATE TABLE [dbo].[Table2]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SpecName] VARCHAR(100) NULL, 
    [SpecCode] VARCHAR(100) NULL, 
    [StudyForm] VARCHAR(100) NULL, 
    [StudentSex] VARCHAR(100) NULL, 
    [PaymentForm] VARCHAR(100) NULL, 
    [DistantStudyForm] VARCHAR(100) NULL 
)
