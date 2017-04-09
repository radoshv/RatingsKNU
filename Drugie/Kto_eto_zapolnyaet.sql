-- Кто это заполняет

USE RatingsKNU;
GO

-- Кількість вищих начальних закладів І-ІІ рівнів акредитації
create table SchoolsWithOneTwoAccreditationLevel (
	Id int not null,
	Name varchar(50) not null
	constraint _PK_SchoolsWithOneTwoAccreditationLevel primary key (Id) 
);

-- Кількість інститутів
create table Institutions (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_Institutions primary key (Id) 
);

-- Кількість факультетів
create table Faculties (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_Faculties primary key (Id) 
);

-- Кількість факультетів денної форми навчання
create table FullTimeFaculties (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_FullTimeFaculties primary key (Id) 
);

-- Структура вищого навчального закладу	
create table UniversityStructureStatistics (
	Lock char(1) not null DEFAULT 'X',
	NoOfDepartments int, -- Кількість кафедр
	NoOfDepartmentsHeadedByDoctorsProfessorsFullTime int, -- Кількість кафедр, які очолюють доктори наук, професори і працюють в штаті на повну ставку
	NoOfReleasingDepartments int, -- Кількість випускаючих кафедр
	NoOfReleasingDepartmentsHeadedByDoctorsProfessorsFullTime int, -- Кількість випускаючих кафедр, які очолюють професори, доктори наук і працюють в штаті на повну ставку
	NoOfSmallDepartmentsWithLessThanFiveTeachers int -- Кількість малочисельних кафедр зі штатом 5 і менше викладачів
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- Кількісь навчально-наукових комплексів
create table ScientificEducationalComplexes (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_ScientificEducationalComplexes primary key (Id)
);

-- Кількість навчальних комплексів (ВНЗ - загально-освітня школа, ВНЗ - ПТУ, 
-- ВНЗ - технікум, коледж та інші)
create table ScientificComplexes (
	Id int not null,
	Name varchar(50) not null,
	constraint _PK_ScientificEducationalComplexes primary key (Id)
);

-- Зараховано в рамках комплексів, встого осіб
create table NoOfEnrolledWithinComplexes (
	Lock char(1) not null DEFAULT 'X',
	Total int,
	GraduatesOfSecondarySchools int, -- у т.ч. випускників загальноосвітніх шкіл, всього осіб 
	GraduatesOfPTUs int, -- у т.ч. випускниікв ПТУ, встого осіб
	GraduatesOfColleges int, -- у т.ч. випускників технікумів, коледжів, всього осіб 
	GraduatesOfLyceums int -- у т.ч. випускниікв ліцеїв, всього осіб 
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X'));

-- Кількість відокремлених структурних підрозділів
create table NoOfSeparatedStructuralUnits (
	Lock char(1) not null DEFAULT 'X',
	Total int,
	WithTheRightLegalEntity int, -- з правом юридичної особи
	WithoutTheRightLegalEntity int, -- без права юридичної особи
	NoOInstitutions int, -- у т.ч. інститутів
	NoOfSchoolsWithOneTwoAccreditationLevel int, -- у т.ч. ВНЗ І-ІІ рівнів акредитації
	NoOfBranches int, -- у т.ч. філій
	NoOfFaculties int, -- у т.ч. факультетів
	NoOfTrainingAndConsultingCentres int, -- у т.ч. навчально-консультаційних центрів
	NoOfStudentsOfAllEducationForms int, -- Контингент студентів всіх форм навчання, які навчаються у відокремлених структурних підрозділах, всього осіб
	NoOfStudentsOfFullTimeEducation int -- Контингент студентів денної форми навчання, які навчаються у відокремлених структурних підрозділах, всього осіб
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- Презентація наукових  досягнень студентів на міжнародному та 
-- національному рівнях	
create table ScientificAchivementsOfStudents (
	Lock char(1) not null DEFAULT 'X',
	NoOfWinnersOfInternationalCompetitionsThisYear int, -- Чисельність студентів, переможців та призерів міжнародних олімпіад (конкурсів) в поточному календарному році
	NoOfWinnersOfAllUkrainianCompetitionsThisYear int, -- Чисельність студентів, переможців та призерів загальноукраїнських олімпіад (конкурсів) в поточному календарному році
	NoOfParticipantsInScientificPracticalConferences int, -- Чисельність студентів учасників міжнародних та всеукраїнських науково-практичних конференцій та семінарів 
	NoOfWinnersInStageTwoAllUkrainianOlympiadThisReportingYear int, -- Чисельність призерів ІІ етапу Всеукраїнської студентської олімпіади у звітному навчальному році
	NoOfWinnersOfCompletitionOfStudentScientificWorksThisReportingYear int, -- Чисельність призерів ІІ туру Всеукраїнського конкурсу студентських наукових робіт з природничих, технічних та гуманітарних наук у звітному навчальному році
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- Участь студентів міжнародних мистецьких та творчих конкурсах, національних спортивних змаганнях
create table ArtAndSportAchivementsOfStudents (
	Lock char(1) not null DEFAULT 'X',
	NoOfStudentsWinnersOfInternationalCompetitions int, -- Чисельність студентів призерів  міжнародних мистецьких та творчих конкурсів
	NoOfGrantsOnAllUkrainianSportCompetitions int, -- Кількість нагород, здобутих студентами-призерами на національних  спортивних змаганнях 
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- Задоволеність студентів
create table StudentsSatisfation (
	Lock char(1) not null DEFAULT 'X',
	PercentSatisfiedWithEducationQuality decimal(5,2), -- Відсоток студентів, що задоволені якістю навчання в університеті.
	PercentStatisfiedWithQualityOfEducationalPrograms decimal(5,2) -- Відсоток студентів, які задоволені рівнем якості своїх освітніх програм.
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

--create table TeachingQuality (
--	PercentSatisfiedWithUniversityExperience decimal(5,2),
--	PercentSatisfiedWithEducationalProgram decimal(5,2),
