/*
   25. april 200911:42:47
   User: 
   Server: .\SQLEXPRESS
   Database: 
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Athlete', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Athlete', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Athlete', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Run
	(
	ID int NOT NULL IDENTITY (1, 1),
	AthleteID int NOT NULL,
	Time int NOT NULL,
	Distance int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Run ADD CONSTRAINT
	PK_Run PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Run ADD CONSTRAINT
	FK_Run_Athlete1 FOREIGN KEY
	(
	AthleteID
	) REFERENCES dbo.Athlete
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Run', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Run', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Run', 'Object', 'CONTROL') as Contr_Per 