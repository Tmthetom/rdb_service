Create table [operation]
(
	[operation_code] Nvarchar(10) NOT NULL, UNIQUE ([operation_code]),
	[name] Text NOT NULL,
	[description] Text NOT NULL,
Primary Key ([operation_code])
) 
go

Create table [section]
(
	[section_code] Nvarchar(10) NOT NULL, UNIQUE ([section_code]),
	[name] Text NOT NULL,
	[description] Text NOT NULL,
Primary Key ([section_code])
) 
go

Create table [scenario]
(
	[scenario_code] Nvarchar(10) NOT NULL, UNIQUE ([scenario_code]),
	[name] Text NOT NULL,
	[description] Text NOT NULL,
Primary Key ([scenario_code])
) 
go

Create table [check_point]
(
	[check_code] Nvarchar(10) NOT NULL, UNIQUE ([check_code]),
	[name] Text NOT NULL,
	[description] Text NOT NULL,
Primary Key ([check_code])
) 
go

Create table [check_operations]
(
	[operation_code] Nvarchar(10) NOT NULL,
	[check_code] Nvarchar(10) NOT NULL,
	[order] Integer NOT NULL,
Primary Key ([operation_code],[check_code])
) 
go

Create table [operation_attributes]
(
	[attribute_code] Nvarchar(10) NOT NULL, UNIQUE ([attribute_code]),
	[type] Nvarchar(20) NOT NULL,
	[language] Nvarchar(5) NULL,
	[value] Text NOT NULL,
Primary Key ([attribute_code])
) 
go

Create table [operation_contains]
(
	[attribute_code] Nvarchar(10) NOT NULL,
	[operation_code] Nvarchar(10) NOT NULL,
Primary Key ([attribute_code],[operation_code])
) 
go

Create table [check_attributes]
(
	[attribute_code] Nvarchar(10) NOT NULL, UNIQUE ([attribute_code]),
	[type] Nvarchar(20) NOT NULL,
	[language] Nvarchar(5) NULL,
	[value] Text NOT NULL,
Primary Key ([attribute_code])
) 
go

Create table [section_attributes]
(
	[attribute_code] Nvarchar(10) NOT NULL, UNIQUE ([attribute_code]),
	[type] Nvarchar(20) NOT NULL,
	[language] Nvarchar(5) NULL,
	[value] Text NOT NULL,
Primary Key ([attribute_code])
) 
go

Create table [scenario_attributes]
(
	[attribute_code] Nvarchar(10) NOT NULL, UNIQUE ([attribute_code]),
	[type] Nvarchar(20) NOT NULL,
	[language] Nvarchar(5) NULL,
	[value] Text NOT NULL,
Primary Key ([attribute_code])
) 
go

Create table [check_contains]
(
	[attribute_code] Nvarchar(10) NOT NULL,
	[check_code] Nvarchar(10) NOT NULL,
Primary Key ([attribute_code],[check_code])
) 
go

Create table [section_contains]
(
	[section_code] Nvarchar(10) NOT NULL,
	[attribute_code] Nvarchar(10) NOT NULL,
Primary Key ([section_code],[attribute_code])
) 
go

Create table [scenario_contains]
(
	[scenario_code] Nvarchar(10) NOT NULL,
	[attribute_code] Nvarchar(10) NOT NULL,
Primary Key ([scenario_code],[attribute_code])
) 
go

Create table [scenario_checks]
(
	[section_order] Integer NOT NULL,
	[scenario_code] Nvarchar(10) NOT NULL,
	[section_code] Nvarchar(10) NOT NULL,
	[check_code] Nvarchar(10) NOT NULL,
	[check_order] Integer NOT NULL,
Primary Key ([section_order],[scenario_code],[section_code],[check_code])
) 
go

Alter table [check_operations] add  foreign key([operation_code]) references [operation] ([operation_code])  on update no action on delete no action 
go
Alter table [operation_contains] add  foreign key([operation_code]) references [operation] ([operation_code])  on update no action on delete no action 
go
Alter table [section_contains] add  foreign key([section_code]) references [section] ([section_code])  on update no action on delete no action 
go
Alter table [scenario_checks] add  foreign key([section_code]) references [section] ([section_code])  on update no action on delete no action 
go
Alter table [scenario_contains] add  foreign key([scenario_code]) references [scenario] ([scenario_code])  on update no action on delete no action 
go
Alter table [scenario_checks] add  foreign key([scenario_code]) references [scenario] ([scenario_code])  on update no action on delete no action 
go
Alter table [check_operations] add  foreign key([check_code]) references [check_point] ([check_code])  on update no action on delete no action 
go
Alter table [check_contains] add  foreign key([check_code]) references [check_point] ([check_code])  on update no action on delete no action 
go
Alter table [scenario_checks] add  foreign key([check_code]) references [check_point] ([check_code])  on update no action on delete no action 
go
Alter table [operation_contains] add  foreign key([attribute_code]) references [operation_attributes] ([attribute_code])  on update no action on delete no action 
go
Alter table [check_contains] add  foreign key([attribute_code]) references [check_attributes] ([attribute_code])  on update no action on delete no action 
go
Alter table [section_contains] add  foreign key([attribute_code]) references [section_attributes] ([attribute_code])  on update no action on delete no action 
go
Alter table [scenario_contains] add  foreign key([attribute_code]) references [scenario_attributes] ([attribute_code])  on update no action on delete no action 
go