USE master
GO


if DB_ID('GGChatDB') is not null drop database GGChatDB
go

create database GGChatDB
go

use GGChatDB
go 

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




insert into GGUser values('617828826','000','幻影追风','我的世界自己主宰！！！','1.png','2016/9/5')
insert into GGUser values('1099953500','000','云晟睿','我的世界自己主宰！！！','2.png','2016/9/5')
insert into GGUser values('1095874125','000','旋影','我的世界自己主宰！！！','3.png','2016/9/5')
insert into GGUser values('541789021','000','遗忘成事','我的世界自己主宰！！！','4.png','2016/9/5')
go


--617828826的分组  幻影追风1
insert into GGGroup values('group1001','我的好友','617828826','2,3','2016/10/10',1)
insert into GGGroup values('group1002','亲人','617828826','4','2016/10/11',0)
insert into GGGroup values('group1003','同学','617828826','','2016/10/12',0)
--1099953500的分组  云晟睿2
insert into GGGroup values('group1001','我的好友','1099953500','1,3','2016/10/10',1)
insert into GGGroup values('group1002','亲人','1099953500','4','2016/10/11',0)
insert into GGGroup values('group1003','同学','1099953500','','2016/10/12',0)
--1095874125的分组  旋影3
insert into GGGroup values('group1001','我的好友','1095874125','1,2','2016/10/10',1)
insert into GGGroup values('group1002','亲人','1095874125','4','2016/10/11',0)
insert into GGGroup values('group1003','同学','1095874125','','2016/10/12',0)
--541789021的分组  遗忘成事4
insert into GGGroup values('group1001','我的好友','541789021','1,2','2016/10/10',1)
insert into GGGroup values('group1002','亲人','541789021','3','2016/10/11',0)
insert into GGGroup values('group1003','同学','541789021','','2016/10/12',0)
go


