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