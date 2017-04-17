/*
Created		27.03.2017
Modified		17.04.2017
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/


Create table [Languages]
(
	[Language_Code] Char(2) NOT NULL,
	[Name] Nvarchar(30) NOT NULL,
Primary Key ([Language_Code])
) 
go

Create table [Scenarios]
(
	[ID_Scenario] Integer Identity NOT NULL, UNIQUE ([ID_Scenario]),
Primary Key ([ID_Scenario])
) 
go

Create table [Sections]
(
	[ID_Section] Integer Identity NOT NULL, UNIQUE ([ID_Section]),
Primary Key ([ID_Section])
) 
go

Create table [CheckPoints]
(
	[ID_CheckPoint] Integer Identity NOT NULL, UNIQUE ([ID_CheckPoint]),
Primary Key ([ID_CheckPoint])
) 
go

Create table [Operations]
(
	[ID_Operation] Integer Identity NOT NULL, UNIQUE ([ID_Operation]),
Primary Key ([ID_Operation])
) 
go

Create table [Scenarios_Sections]
(
	[ID_Scenario] Integer NOT NULL,
	[ID_Section] Integer NOT NULL,
	[ID_CheckPoint] Integer NOT NULL,
	[Order_Number] Integer NOT NULL,
Primary Key ([ID_Scenario],[ID_Section],[ID_CheckPoint])
) 
go

Create table [CheckPoints_Operations]
(
	[ID_CheckPoint] Integer NOT NULL,
	[ID_Operation] Integer NOT NULL,
	[Order_Number] Integer NOT NULL,
Primary Key ([ID_CheckPoint],[ID_Operation])
) 
go

Create table [Sections_Translation]
(
	[ID_Section] Integer NOT NULL,
	[Language_Code] Char(2) NOT NULL,
	[Name] Nvarchar(30) NOT NULL,
Primary Key ([ID_Section],[Language_Code])
) 
go

Create table [CheckPoints_Translation]
(
	[ID_CheckPoint] Integer NOT NULL,
	[Language_Code] Char(2) NOT NULL,
	[Name] Nvarchar(30) NOT NULL,
Primary Key ([ID_CheckPoint],[Language_Code])
) 
go

Create table [Operations_Translation]
(
	[ID_Operation] Integer NOT NULL,
	[Language_Code] Char(2) NOT NULL,
	[Name] Nvarchar(30) NOT NULL,
Primary Key ([ID_Operation],[Language_Code])
) 
go

Create table [Scenarios_Translation]
(
	[ID_Scenario] Integer NOT NULL,
	[Language_Code] Char(2) NOT NULL,
	[Name] Nvarchar(30) NOT NULL,
Primary Key ([ID_Scenario],[Language_Code])
) 
go

Create table [Log]
(
	[ID_Log] Integer Identity NOT NULL,
	[Time] Datetime NOT NULL,
	[Table] Nvarchar(50) NOT NULL,
	[Operation] Nvarchar(50) NOT NULL,
	[User] Nvarchar(256) NOT NULL,
Primary Key ([ID_Log])
) 
go


Alter table [Scenarios_Sections] add  foreign key([ID_Scenario]) references [Scenarios] ([ID_Scenario])  on update no action on delete no action 
go
Alter table [Scenarios_Translation] add  foreign key([ID_Scenario]) references [Scenarios] ([ID_Scenario])  on update no action on delete no action 
go
Alter table [Scenarios_Sections] add  foreign key([ID_Section]) references [Sections] ([ID_Section])  on update no action on delete no action 
go
Alter table [Sections_Translation] add  foreign key([ID_Section]) references [Sections] ([ID_Section])  on update no action on delete no action 
go
Alter table [CheckPoints_Operations] add  foreign key([ID_CheckPoint]) references [CheckPoints] ([ID_CheckPoint])  on update no action on delete no action 
go
Alter table [CheckPoints_Translation] add  foreign key([ID_CheckPoint]) references [CheckPoints] ([ID_CheckPoint])  on update no action on delete no action 
go
Alter table [Scenarios_Sections] add  foreign key([ID_CheckPoint]) references [CheckPoints] ([ID_CheckPoint])  on update no action on delete no action 
go
Alter table [CheckPoints_Operations] add  foreign key([ID_Operation]) references [Operations] ([ID_Operation])  on update no action on delete no action 
go
Alter table [Operations_Translation] add  foreign key([ID_Operation]) references [Operations] ([ID_Operation])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


