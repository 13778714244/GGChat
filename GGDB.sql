USE [GGChatDB]
GO

/****** Object:  Table [dbo].[ChatMessageRecord]    Script Date: 2019/7/28 星期日 22:54:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ChatMessageRecord](
	[chatRecordAutoId] [bigint] IDENTITY(1,1) NOT NULL,
	[chatRecordId] [varchar](36) NULL,
	[sendId] [varchar](50) NULL,
	[receiveId] [varchar](50) NULL,
	[msgType] [int] NULL,
	[content] [text] NULL,
	[datetime] [datetime] NULL,
	[isRead] [bit] NULL,
 CONSTRAINT [PK__ChatMess__6F2CD9AF324301D7] PRIMARY KEY CLUSTERED 
(
	[chatRecordAutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [GGChatDB]
GO

/****** Object:  Table [dbo].[GGUser]    Script Date: 2019/7/28 星期日 22:54:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GGUser](
	[userAutoid] [int] IDENTITY(1,1) NOT NULL,
	[userId] [varchar](50) NULL,
	[userPwd] [varchar](100) NULL,
	[userNickName] [varchar](50) NULL,
	[qqSign] [varchar](100) NULL,
	[userImg] [varchar](50) NULL,
	[createTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[userAutoid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [GGChatDB]
GO

/****** Object:  Table [dbo].[GGGroup]    Script Date: 2019/7/28 星期日 22:54:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GGGroup](
	[groupAutoId] [int] IDENTITY(1,1) NOT NULL,
	[groupId] [varchar](50) NULL,
	[groupName] [varchar](20) NULL,
	[createId] [varchar](20) NULL,
	[members] [text] NULL,
	[createTime] [datetime] NULL,
	[isDefault] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[groupAutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


