USE [GGChatDB]
GO

/****** Object:  Table [dbo].[GGGroup]    Script Date: 08/11/2019 21:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GGGroup]') AND type in (N'U'))
DROP TABLE [dbo].[GGGroup]
GO

USE [GGChatDB]
GO

/****** Object:  Table [dbo].[GGGroup]    Script Date: 08/11/2019 21:45:21 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


