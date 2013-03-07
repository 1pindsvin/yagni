USE [RunTrack]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

USE [RunTrack]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Lap_Activity]') AND parent_object_id = OBJECT_ID(N'[dbo].[Lap]'))
ALTER TABLE [dbo].[Lap] DROP CONSTRAINT [FK_Lap_Activity]
GO

USE [RunTrack]
GO
/****** Object:  Table [dbo].[Lap]    Script Date: 03/19/2010 13:26:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lap]') AND type in (N'U'))
DROP TABLE [dbo].[Lap]
GO

USE [RunTrack]
GO

CREATE TABLE [dbo].[Lap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] not NULL,
	[Version] [timestamp] NOT NULL,
	[TotalTimeSeconds] [int] not NULL,
	[DistanceMeters] [int] not NULL,
	[MaximumSpeed] [int] not NULL,
	[Calories] [int] not NULL,
	[AverageHeartRateBpm] [int] not NULL,
	[MaximumHeartRateBpm] [int] not NULL,
	[Intensity] [varchar](50) NULL,
	[TriggerMethod] [varchar](50) NULL
 CONSTRAINT [PK_Lap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Lap]  WITH CHECK ADD  CONSTRAINT [FK_Lap_Activity] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Activity] ([ID])
GO
ALTER TABLE [dbo].[Lap] CHECK CONSTRAINT [FK_Lap_Activity]