-- ̳������. ���� + ���� ����

USE RatingsKNU;
GO

-- ������� ����������� � �������� Webometrics �����:
create table PositionInWebometrics (
	Lock char(1) not null DEFAULT 'X',
	EasternEuropeUniversities int, -- ��� ���� ������ ������
	WorldUniversities int -- ��� ���� ����
	/* Single row constarins */
    constraint _PK PRIMARY KEY (Lock),
    constraint _CK CHECK (Lock='X')
);

-- ������� ����������� � QS:
create table PositionInQS (
	Lock char(1) not null DEFAULT 'X',
	AllWorld int,
	EasternEuropeAndCentralAsia int,
	/* Single row constarins */
    constraint _PK PRIMARY KEY (Lock),
    constraint _CK CHECK (Lock='X')
);

