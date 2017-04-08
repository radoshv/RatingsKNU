-- Міжнарод. відділ + відділ Беха

USE RatingsKNU;
GO

-- Позиція Університету в рейтингу Webometrics серед:
create table PositionInWebometrics (
	Lock char(1) not null DEFAULT 'X',
	EasternEuropeUniversities int, -- ВНЗ країн Східної Європи
	WorldUniversities int -- ВНЗ країн світу
	/* Single row constarins */
    constraint _PK PRIMARY KEY (Lock),
    constraint _CK CHECK (Lock='X')
);

-- Рейтинг Університету в QS:
create table PositionInQS (
	Lock char(1) not null DEFAULT 'X',
	AllWorld int,
	EasternEuropeAndCentralAsia int,
	/* Single row constarins */
    constraint _PK PRIMARY KEY (Lock),
    constraint _CK CHECK (Lock='X')
);

