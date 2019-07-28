
use master
go

if DB_ID('GGChatDB') is not null drop database GGChatDB
go

create database GGChatDB
go

use GGChatDB
go 

--QQ用户
create table  GGUser (
	userAutoid int primary key identity,
	userId varchar(50) unique,
	userPwd varchar(100),
	userNickName varchar(50),
	qqSign varchar (100),
	userImg varchar(50),
	createTime datetime
) 
GO

insert into GGUser values('617828826','000','幻影追风','我的世界自己主宰！！！','1.png','2016/9/5')
insert into GGUser values('1099953500','000','云晟睿','我的世界自己主宰！！！','2.png','2016/9/5')
insert into GGUser values('1095874125','000','旋影','我的世界自己主宰！！！','3.png','2016/9/5')
insert into GGUser values('541789021','000','遗忘成事','我的世界自己主宰！！！','4.png','2016/9/5')
go



--QQ分组
create table GGGroup (
	groupAutoId int primary key identity,
	groupId varchar(50),
	groupName varchar (20),
	createId varchar (20),--外键 GGUser(userId)
	members text,--外键 GGUser(userAutoid)
	createTime datetime	
) 
GO

--617828826的分组  幻影追风1
insert into GGGroup values('group1001','我的好友','617828826','2,3','2016/10/10')
insert into GGGroup values('group1002','亲人','617828826','4','2016/10/11')
insert into GGGroup values('group1003','同学','617828826','','2016/10/12')
--1099953500的分组  云晟睿2
insert into GGGroup values('group1001','我的好友','1099953500','1,3','2016/10/10')
insert into GGGroup values('group1002','亲人','1099953500','4','2016/10/11')
insert into GGGroup values('group1003','同学','1099953500','','2016/10/12')
--1095874125的分组  旋影3
insert into GGGroup values('group1001','我的好友','1095874125','1,2','2016/10/10')
insert into GGGroup values('group1002','亲人','1095874125','4','2016/10/11')
insert into GGGroup values('group1003','同学','1095874125','','2016/10/12')
--541789021的分组  遗忘成事4
insert into GGGroup values('group1001','我的好友','541789021','1,2','2016/10/10')
insert into GGGroup values('group1002','亲人','541789021','3','2016/10/11')
insert into GGGroup values('group1003','同学','541789021','','2016/10/12')
go


--聊天记录
create table ChatMessageRecord (
	chatRecordAutoId bigint primary key identity,
	[chatRecordId] [uniqueidentifier],
	sendId int,--外键 GGUser(userAutoid)
	receiveId int,--外键 GGUser(userAutoid)
	isGroupChat bit,--是否为群聊
	content text,
	occureTime datetime	
) 
GO
 
 

select*from GGGroup
go