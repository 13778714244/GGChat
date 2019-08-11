USE [GGChatDB]
GO

/****** Object:  Table [dbo].[ChatRecord]    Script Date: 08/11/2019 21:45:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChatRecord]') AND type in (N'U'))
DROP TABLE [dbo].[ChatRecord]
GO

USE [GGChatDB]
GO

/****** Object:  Table [dbo].[ChatRecord]    Script Date: 08/11/2019 21:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ChatRecord](
	[chatAutoId] [bigint] IDENTITY(1,1) NOT NULL,
	[sendId] [varchar](50) NULL,
	[receiveId] [varchar](50) NULL,
	[msgType] [int] NULL,
	[content] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


