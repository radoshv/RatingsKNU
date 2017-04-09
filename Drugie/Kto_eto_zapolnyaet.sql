-- ��� ��� ���������

USE RatingsKNU;
GO

-- ʳ������ ����� ��������� ������� �-�� ���� �����������
create table SchoolsWithOneTwoAccreditationLevel (
	Id int not null,
	Name varchar(50) not null
	constraint _PK_SchoolsWithOneTwoAccreditationLevel primary key (Id) 
);

-- ʳ������ ���������
create table Institutions (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_Institutions primary key (Id) 
);

-- ʳ������ ����������
create table Faculties (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_Faculties primary key (Id) 
);

-- ʳ������ ���������� ����� ����� ��������
create table FullTimeFaculties (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_FullTimeFaculties primary key (Id) 
);

-- ��������� ������ ����������� �������	
create table UniversityStructureStatistics (
	Lock char(1) not null DEFAULT 'X',
	NoOfDepartments int, -- ʳ������ ������
	NoOfDepartmentsHeadedByDoctorsProfessorsFullTime int, -- ʳ������ ������, �� �������� ������� ����, ��������� � �������� � ���� �� ����� ������
	NoOfReleasingDepartments int, -- ʳ������ ����������� ������
	NoOfReleasingDepartmentsHeadedByDoctorsProfessorsFullTime int, -- ʳ������ ����������� ������, �� �������� ���������, ������� ���� � �������� � ���� �� ����� ������
	NoOfSmallDepartmentsWithLessThanFiveTeachers int -- ʳ������ ������������� ������ � ������ 5 � ����� ����������
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- ʳ����� ���������-�������� ���������
create table ScientificEducationalComplexes (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_ScientificEducationalComplexes primary key (Id)
);

-- ʳ������ ���������� ��������� (��� - ��������-������ �����, ��� - ���, 
-- ��� - �������, ������ �� ����)
create table ScientificComplexes (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_ScientificEducationalComplexes primary key (Id)
);

-- ���������� � ������ ���������, ������ ���
create table NoOfEnrolledWithinComplexes (
	Lock char(1) not null DEFAULT 'X',
	Total int,
	GraduatesOfSecondarySchools int, -- � �.�. ���������� �������������� ���, ������ ��� 
	GraduatesOfPTUs int, -- � �.�. ���������� ���, ������ ���
	GraduatesOfColleges int, -- � �.�. ���������� ��������, �������, ������ ��� 
	GraduatesOfLyceums int -- � �.�. ���������� ����, ������ ��� 
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X'));

-- ʳ������ ������������ ����������� ��������
create table NoOfSeparatedStructuralUnits (
	Lock char(1) not null DEFAULT 'X',
	Total int,
	WithTheRightLegalEntity int, -- � ������ �������� �����
	WithoutTheRightLegalEntity int, -- ��� ����� �������� �����
	NoOInstitutions int, -- � �.�. ���������
	NoOfSchoolsWithOneTwoAccreditationLevel int, -- � �.�. ��� �-�� ���� �����������
	NoOfBranches int, -- � �.�. ����
	NoOfFaculties int, -- � �.�. ����������
	NoOfTrainingAndConsultingCentres int, -- � �.�. ���������-��������������� ������
	NoOfStudentsOfAllEducationForms int, -- ���������� �������� ��� ���� ��������, �� ���������� � ������������ ����������� ���������, ������ ���
	NoOfStudentsOfFullTimeEducation int -- ���������� �������� ����� ����� ��������, �� ���������� � ������������ ����������� ���������, ������ ���
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- ����������� ��������  ��������� �������� �� ����������� �� 
-- ������������� �����	
create table ScientificAchivementsOfStudents (
	Lock char(1) not null DEFAULT 'X',
	NoOfWinnersOfInternationalCompetitionsThisYear int, -- ���������� ��������, ���������� �� ������� ���������� ������ (��������) � ��������� ������������ ����
	NoOfWinnersOfAllUkrainianCompetitionsThisYear int, -- ���������� ��������, ���������� �� ������� ������������������ ������ (��������) � ��������� ������������ ����
	NoOfParticipantsInScientificPracticalConferences int, -- ���������� �������� �������� ���������� �� ������������� �������-���������� ����������� �� ������� 
	NoOfWinnersInStageTwoAllUkrainianOlympiadThisReportingYear int, -- ���������� ������� �� ����� ������������ ����������� ������� � ������� ����������� ����
	NoOfWinnersOfCompletitionOfStudentScientificWorksThisReportingYear int, -- ���������� ������� �� ���� �������������� �������� ������������ �������� ���� � �����������, �������� �� ����������� ���� � ������� ����������� ����
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- ������ �������� ���������� ���������� �� ������� ���������, ������������ ���������� ���������
create table ArtAndSportAchivementsOfStudents (
	Lock char(1) not null DEFAULT 'X',
	NoOfStudentsWinnersOfInternationalCompetitions int, -- ���������� �������� �������  ���������� ���������� �� ������� ��������
	NoOfGrantsOnAllUkrainianSportCompetitions int, -- ʳ������ �������, �������� ����������-��������� �� ������������  ���������� ��������� 
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- ������������ ��������
create table StudentsSatisfation (
	Lock char(1) not null DEFAULT 'X',
	PercentSatisfiedWithEducationQuality decimal(5,2), -- ³������ ��������, �� ��������� ����� �������� � ����������.
	PercentStatisfiedWithQualityOfEducationalPrograms decimal(5,2) -- ³������ ��������, �� ��������� ����� ����� ���� ������ �������.
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

--create table TeachingQuality (
--	PercentSatisfiedWithUniversityExperience decimal(5,2),
--	PercentSatisfiedWithEducationalProgram decimal(5,2),
