USE [master]
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'${sql.database}')
BEGIN
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'${sql.database}'
END 
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'${sql.database}')
BEGIN
	ALTER DATABASE [${sql.database}] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
END 
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'${sql.database}')
BEGIN
	ALTER DATABASE [${sql.database}] SET  SINGLE_USER 
END 
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'${sql.database}')
BEGIN
	DROP DATABASE [${sql.database}]
END 
GO
