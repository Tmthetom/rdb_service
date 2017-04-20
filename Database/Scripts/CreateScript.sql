/* Tables */

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
	[TimeDate] Datetime NOT NULL,
	[TableName] Nvarchar(50) NOT NULL,
	[Operation] Nvarchar(50) NOT NULL,
	[UserName] Nvarchar(256) NOT NULL,
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

/* Triggers */

CREATE TRIGGER t_Languages
   ON Languages
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_Scenarios
   ON Scenarios
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_Scenarios_Translation
   ON Scenarios_Translation
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_Sections
   ON Sections
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_Sections_Translation
   ON Sections_Translation
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_CheckPoints
   ON CheckPoints
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_CheckPoints_Translation
   ON CheckPoints_Translation
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_Operations
   ON Operations
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_Operations_Translation
   ON Operations_Translation
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_Scenarios_Sections
   ON Scenarios_Sections
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

CREATE TRIGGER t_CheckPoints_Operations
   ON CheckPoints_Operations
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @event_type varchar(6)
	IF EXISTS(SELECT * FROM inserted)
		IF EXISTS(SELECT * FROM deleted)
			SELECT @event_type = 'Update'
		ELSE
			SELECT @event_type = 'Insert'
	ELSE
	IF EXISTS(SELECT * FROM deleted)
		SELECT @event_type = 'Delete'
	ELSE
		SELECT @event_type = 'None'

	DECLARE @table_name varchar(64)
	SELECT
		@table_name = OBJECT_NAME(parent_id)
	FROM
		sys.triggers
	WHERE
		object_id = @@PROCID

	INSERT INTO Log(TimeDate, TableName, Operation, UserName) 
		VALUES(GetDate(), @table_name, @event_type, USER_NAME())
END
GO

/* Instead of Triggers */

CREATE TRIGGER t_Check_Languages
   ON Languages
   INSTEAD OF INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @Language_Code Char(2)
	DECLARE @Name NVarchar(30)
	
	SET @Language_Code = (SELECT Language_Code FROM inserted)
	SET @Name = (SELECT Name FROM inserted)

	if(DATALENGTH(@Language_Code) > 1)
	begin
		INSERT INTO Languages(Language_Code, Name) VALUES(@Language_Code, @Name)
	end	
END
GO