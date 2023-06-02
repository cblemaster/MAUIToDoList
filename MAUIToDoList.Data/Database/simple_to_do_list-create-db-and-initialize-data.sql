USE master
GO

DECLARE @SQL nvarchar(1000);
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = N'simple_to_do_list')
BEGIN
    SET @SQL = N'USE simple_to_do_list;

                 ALTER DATABASE simple_to_do_list SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 USE master;

                 DROP DATABASE simple_to_do_list;';
    EXEC (@SQL);
END;

CREATE DATABASE simple_to_do_list
GO

USE simple_to_do_list
GO

CREATE TABLE to_do_item
(
	id					int				IDENTITY(1,1)		NOT NULL,
	[name]				varchar(50)							NOT NULL,
	[description]	    varchar(255) 						NULL,
	is_important		bit									NOT NULL,
	is_complete			bit									NOT NULL,
	due_date			datetime							NOT NULL

 
	CONSTRAINT PK_transfer_types PRIMARY KEY(id)	
)
GO

-- load a row of sample data
INSERT INTO to_do_item ([name],[description],is_important,is_complete,due_date)
VALUES ('Mow lawn','Mow lawn, front and back',0,0,GETDATE()),
	   ('Grocery shopping','Milk, eggs, bread',1,0,DATEADD(day,3,GETDATE())),
	   ('Schedule car maintenance','Oil change and tire rotation',0,1,DATEADD(day,-6,GETDATE())),
	   ('Pick up dry cleaning','New place at 6th and Empire',1,1,DATEADD(day,-12,GETDATE())),
	   ('Pay bills','Call about the water statement',1,0,GETDATE());
