use master
GO
	CREATE DATABASE [${sql.database}] ON  PRIMARY
	( NAME = N'${sql.database}', FILENAME = '${sql.database.file.without-extension}.mdf' , FILEGROWTH = 1024KB )
	LOG ON
	( NAME = N'${sql.database}_log', FILENAME = '${sql.database.file.without-extension}_log.ldf' , FILEGROWTH = 10%)
GO
	EXEC dbo.sp_dbcmptlevel @dbname=N'${sql.database}', @new_cmptlevel=80
GO
	IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
	begin
		EXEC [${sql.database}].[dbo].[sp_fulltext_database] @action = 'disable'
	end
GO
	ALTER DATABASE [${sql.database}] SET ANSI_NULL_DEFAULT OFF
GO
	ALTER DATABASE [${sql.database}] SET ANSI_NULLS OFF
GO
	ALTER DATABASE [${sql.database}] SET ANSI_PADDING OFF
GO
	ALTER DATABASE [${sql.database}] SET ANSI_WARNINGS ON
GO
	ALTER DATABASE [${sql.database}] SET ARITHABORT ON
GO
	ALTER DATABASE [${sql.database}] SET AUTO_CLOSE OFF
GO
	ALTER DATABASE [${sql.database}] SET AUTO_CREATE_STATISTICS ON
GO
	ALTER DATABASE [${sql.database}] SET AUTO_SHRINK OFF
GO
	ALTER DATABASE [${sql.database}] SET AUTO_UPDATE_STATISTICS ON
GO
	ALTER DATABASE [${sql.database}] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
	ALTER DATABASE [${sql.database}] SET CURSOR_DEFAULT  GLOBAL
GO
	ALTER DATABASE [${sql.database}] SET CONCAT_NULL_YIELDS_NULL OFF
GO
	ALTER DATABASE [${sql.database}] SET NUMERIC_ROUNDABORT OFF
GO
	ALTER DATABASE [${sql.database}] SET QUOTED_IDENTIFIER OFF
GO
	ALTER DATABASE [${sql.database}] SET RECURSIVE_TRIGGERS OFF
GO
	ALTER DATABASE [${sql.database}] SET  READ_WRITE
GO
	ALTER DATABASE [${sql.database}] SET RECOVERY FULL 
GO
	ALTER DATABASE [${sql.database}] SET  MULTI_USER
GO
