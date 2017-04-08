-- ̳������. ���� + ���� ����

USE RatingsKNU;
GO

-- ������� ����������� � �������� Webometrics �����:
create table PositionInWebometrics (
	Lock char(1) not null DEFAULT 'X',
	EasternEuropeUniversities int, -- ��� ���� ������ ������
	WorldUniversities int -- ��� ���� ����
	/* Single row constarins */
    constraint _PK_PositionInWebometrics PRIMARY KEY (Lock),
    constraint _CK_PositionInWebometrics CHECK (Lock='X')
);

-- ������� ����������� � QS:
create table PositionInQS (
	Lock char(1) not null DEFAULT 'X',
	AllWorld int,
	EasternEuropeAndCentralAsia int,
	/* Single row constarins */
    constraint _PK_PositionInQS PRIMARY KEY (Lock),
    constraint _CK_PositionInQS CHECK (Lock='X')
);

