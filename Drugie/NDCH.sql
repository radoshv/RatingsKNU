-- НДЧ

USE RatingsKNU;
GO

-- Рейтингові показники	
create table RatingScores (
	Lock char(1) not null DEFAULT 'X',
	NoOfScopusPublications int, -- Кількість публікацій у Scopus
	NoOfScopusQuotations int, -- Кількість цитувань у Scopus
	ScopusHIndex int, -- Індекс Гірша (h-індекс) у Scopus
	NoOfEmployeeWithHindexHigherThanThree int, -- Кількість штатних науково-педагогічних працівників з індексом Гірша 3 і більше
	TotalNoOfEuropeanPrograms int, -- Загальна кількість Європейських програм
	NoOfTEMPUSActiveThisYearGrantedByUniv int, -- Кількість Європейських програм (TEMPUS - ТЕМПУС), діючих у поточному році, за якими навчаний заклад виграв гранти
	NoOfFPSevenActiveThisYearGrantedByUniv int -- Кількість Європейських програм (Seventh Framework Programme (FP7) - сьома рамкова програма), діючих у поточному році, за якими навчаний заклад виграв гранти
	/* Single row constraints */
    constraint _PK_RatingScores PRIMARY KEY (Lock),
    constraint _CK_RatingScores CHECK (Lock='X')
);

-- Кількість старт-апів або спін-офф компаній, які первинно були результатом договору про використання ліцензії, формального трансферу технології з боку ВНЗ або з боку офісу чи фірми з трансферу технологій. Старт-апи (нові бізнеси) засновані аби дослідити нову технологію чи інтелектуальну власність, спродуковану ВНЗ.
create table StartupsAndSpinoffCompaniesRelatedToUnivTechnologies (
	CompanyId int not null, 
	CompanyName varchar(50) not null,
	Date Date not null,
	Founder varchar(50), -- Засновник
	Manager varchar(50), -- Управляючий
	WebsiteURL varchar(100),
	CurrentlySponsoredByUniv bit not null default(0), -- Чи фінансується компанія університетом зараз
	constraint _PK_StartupsAndSpinoffCompaniesRelatedToUnivTechnologies primary key (CompanyId) 
);

-- Кількість дійсних компаній(не державних та поза університетських), які проводили спільні дослідження з університетом, результати досліджень буди опубліковані у базі Scopus за останні 5 років.
create table ActiveCompaniesCommonResearchWithUniv (
	CompanyId int not null, 
	CompanyName varchar(50) not null,
	Country varchar(20), -- Країна
	Project varchar(50), -- Проект
	PublishYear int, -- Рік публікації
	constraint _PK_ActiveCompaniesCommonResearchWithUniv primary key (CompanyId) 
);

-- Кількість компаній спін-офф заснованих за останні 5 років що  до сих пір функціонують та не потребують підтримки університету.
create table SpinOffCompaniesNotNeedingUnivSupportAnymore (
	CompanyId int not null, 
	CompanyName varchar(50) not null,
	Date Date not null,
	Founder varchar(50), -- Засновник
	Manager varchar(50), -- Управляючий
	WebsiteURL varchar(100),
	CurrentlySponsoredByUniv bit not null default(0), -- Чи фінансується компанія університетом зараз
	constraint _PK_SpinOffCompaniesNotNeedingUnivSupportAnymore primary key (CompanyId) 
);

