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
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Track_Lap]') AND parent_object_id = OBJECT_ID(N'[dbo].[Track]'))
ALTER TABLE [dbo].[Track] DROP CONSTRAINT [FK_Track_Lap]
GO

USE [RunTrack]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 03/19/2010 13:26:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track]') AND type in (N'U'))
DROP TABLE [dbo].[Track]
GO

USE [RunTrack]
GO

CREATE TABLE [dbo].[Track](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LapID] [int] not NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Lap] FOREIGN KEY([LapID])
REFERENCES [dbo].[Lap] ([ID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Lap]