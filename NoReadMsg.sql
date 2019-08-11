USE [GGChatDB]
GO

/****** Object:  Table [dbo].[NoReadMsg]    Script Date: 08/11/2019 21:45:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NoReadMsg]') AND type in (N'U'))
DROP TABLE [dbo].[NoReadMsg]
GO

USE [GGChatDB]
GO

/****** Object:  Table [dbo].[NoReadMsg]    Script Date: 08/11/2019 21:45:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[NoReadMsg](
	[chatRecordAutoId] [bigint] IDENTITY(1,1) NOT NULL,
	[chatRecordId] [varchar](36) NULL,
	[sendId] [varchar](50) NULL,
	[receiveId] [varchar](50) NULL,
	[msgType] [int] NULL,
	[content] [text] NULL,
	[datetime] [datetime] NULL,
	[isRead] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


