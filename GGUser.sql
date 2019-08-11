USE [GGChatDB]
GO

/****** Object:  Table [dbo].[GGUser]    Script Date: 08/11/2019 21:45:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GGUser]') AND type in (N'U'))
DROP TABLE [dbo].[GGUser]
GO

USE [GGChatDB]
GO

/****** Object:  Table [dbo].[GGUser]    Script Date: 08/11/2019 21:45:25 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


