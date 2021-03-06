-- Відділ культури

USE RatingsKNU;
GO

-- Кількість міжнародних виставок у галузі науки, освіти, технологій, 
-- на яких репрезентовано здобутки вищого навчального закладу
create table InternationalExhibitionsOfScienceEducation (
	Id int not null,
	ExhibionName varchar(50) not null
	constraint _PK_InternationalExhibitionsOfScienceEducation primary key (Id)
);

-- Кількість нагород (медалі, дипломи), отриманих вищим навчальним закладом, 
-- на міжнародних виставках у галузі науки, освіти, технологій, 
-- на яких репрезентовано здобутки вищого навчального закладу
create table GrantsOnInternationsExhibitionsOfScienceEducation (
	Id int not null,
	ExhibitionId int not null,
	GrantName varchar(50) not null,
	constraint _PK_GrantsOnInternationsExhibitionsOfScienceEducation primary key (Id),
	constraint _FK_GrantsOnInternationsExhibitionsOfScienceEducation foreign key (ExhibitionId) 
			references InternationalExhibitionsOfScienceEducation(Id) 
			on delete cascade
);

-- Кількість міжнародних мистецьких виставок, фестивалів і конкурсів тощо, 
-- на яких репрезентовано здобутки вищого навчального закладу
create table InternationalExhibitionsOfArts (
	Id int not null,
	ExhibionName varchar(50) not null
	constraint _PK_InternationalExhibitionsOfArts primary key (Id)
);

-- Кількість нагород (медалі,  дипломи переможців), отримано вищим навчальним закладом, 
-- на міжнародних мистецьких виставках, фестивалях і конкурсах тощо, 
-- на яких репрезентовано здобутки вищого навчального закладу
create table GrantsOnInternationsExhibitionsOfArts (
	Id int not null,
	ExhibitionId int not null,
	GrantName varchar(50) not null,
	constraint _PK_GrantsOnInternationsExhibitionsOfArts primary key (Id),
	constraint _FK_GrantsOnInternationsExhibitionsOfArts foreign key (ExhibitionId) 
			references InternationalExhibitionsOfArts(Id) 
			on delete cascade
);

-- Кількість  всеукраїнських національних та галузевих виставках, 
-- на яких репрезентовано здобутки вищого навчального закладу
create table UkrExhibitionsOfIndustries  (
	Id int not null,
	ExhibionName varchar(50) not null
	constraint _PK_UkrExhibitionsOfIndustries primary key (Id)
);

-- Кількість нагород (медалі, дипломи) отримано вищим навчальним закладом
-- на всеукраїнських національних та галузевих виставках, на яких репрезентовано 
-- здобутки вищого навчального закладу
create table GrantsOnUkrExhibitionsOfIndustries (
	Id int not null,
	ExhibitionId int not null,
	GrantName varchar(50) not null,
	constraint _PK_GrantsOnUkrExhibitionsOfIndustries primary key (Id),
	constraint _FK_GrantsOnUkrExhibitionsOfIndustries foreign key (ExhibitionId) 
			references UkrExhibitionsOfIndustries(Id) 
			on delete cascade
);

-- Кількість всеукраїнських фестивалів, мистецьких форумів, 
-- на яких репрезентовано здобутки вищого навчального закладу
create table UkrExhibitionsOfArts  (
	Id int not null,
	ExhibionName varchar(50) not null
	constraint _PK_UkrExhibitionsOfArts primary key (Id)
);

-- Кількість нагород (медалі, дипломи) отримано вищим навчальним закладом
-- на всеукраїнських фестивалях, мистецьких форумах, на яких репрезентовано 
-- здобутки вищого навчального закладу
create table GrantsOnUkrExhibitionsOfArts (
	Id int not null,
	ExhibitionId int not null,
	GrantName varchar(50) not null,
	constraint _PK primary key (Id),
	constraint _FK_GrantsOnUkrExhibitionsOfArts foreign key (ExhibitionId) 
			references UkrExhibitionsOfArts(Id) 
			on delete cascade
);

-- Кількість нагород, здобутих  спортсменами на  міжнародних 
-- спортивних змаганнях (Олімпійські ігри, чемпіонати Світу, Європи,  
-- Всесвітні Універсіади, чемпіонати світу та Європи серед студентів)
create table GrantsOnSportCompetitions  (
	Id int not null,
	CompetitionName varchar(50) not null
	constraint _PK_GrantsOnSportCompetitions primary key (Id)
);

-- Кількість публікацій та предметів мистецтва
create table NoOfPublicationsAndArtSubjects (
	Lock char(1) not null DEFAULT 'X',
	NoOfReviewedSciencePublications int, -- Кількість рецензованих наукових публікацій (статті, матеріали конференцій, монографій, книжні видання, опубліковані дисертаційні роботи)
	NoOfNotReviewedProfessionalPublications int, -- Кількість професійних публікацій (загальна кількість публікацій, надрукованих у журналах, книжках та інших медіа, адресованих професійній аудиторії та які можна ідентифікувати бібліографічно). Ці публікації не є рецензованими, як у попередній категорії.
	NoOfCultureAndArtEventsAndWritings int, -- Кількість культурно-мистецьких заходів та творів
	NoOfConcerts int, -- Кількість концертів (повністю або частково організованих за участю Університету та відкриті для широкого загалу)
	NoOfExhibitions int, -- Кількість виставок (повністю або частково організованих за участю Університету та відкриті для широкого загалу)
	NoOfReviewedArtifacts int, -- Кількість рецензованих артефактів (каталогованих експонатів, витворів мистецтва, музичних творів тощо)
	NoOfMediaProducts int -- Кількість медіа-продуктів (повністю або частково створених за участі Університету)
	/* Single row constarins */
    constraint _PK_PositionInWebometrics PRIMARY KEY (Lock),
    constraint _CK_PositionInWebometrics CHECK (Lock='X')
);