USE [master]
GO

If Exists (select loginname from master.dbo.syslogins where name = '${sql.database}_Webuser' and dbname = '${sql.database}')
Begin
	EXEC sp_droplogin '${sql.database}_Webuser'
end

EXEC sp_addlogin '${sql.database}_Webuser', '${sql.password}', '${sql.database}'

USE [${sql.database}]
GO

EXEC sp_grantdbaccess '${sql.database}_Webuser', '${sql.database}_Webuser'

USE [${sql.database}]
GO

EXEC sp_addrolemember N'db_owner', N'${sql.database}_Webuser'
GO
 