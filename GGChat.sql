
use master
go

if DB_ID('GGChatDB') is not null drop database GGChatDB
go

create database GGChatDB
go

use GGChatDB
go 

--QQ�û�
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

insert into GGUser values('617828826','000','��Ӱ׷��','�ҵ������Լ����ף�����','1.png','2016/9/5')
insert into GGUser values('1099953500','000','�����','�ҵ������Լ����ף�����','2.png','2016/9/5')
insert into GGUser values('1095874125','000','��Ӱ','�ҵ������Լ����ף�����','3.png','2016/9/5')
insert into GGUser values('541789021','000','��������','�ҵ������Լ����ף�����','4.png','2016/9/5')
go



--QQ����
create table GGGroup (
	groupAutoId int primary key identity,
	groupId varchar(50),
	groupName varchar (20),
	createId varchar (20),--��� GGUser(userId)
	members text,--��� GGUser(userAutoid)
	createTime datetime	
) 
GO

--617828826�ķ���  ��Ӱ׷��1
insert into GGGroup values('group1001','�ҵĺ���','617828826','2,3','2016/10/10')
insert into GGGroup values('group1002','����','617828826','4','2016/10/11')
insert into GGGroup values('group1003','ͬѧ','617828826','','2016/10/12')
--1099953500�ķ���  �����2
insert into GGGroup values('group1001','�ҵĺ���','1099953500','1,3','2016/10/10')
insert into GGGroup values('group1002','����','1099953500','4','2016/10/11')
insert into GGGroup values('group1003','ͬѧ','1099953500','','2016/10/12')
--1095874125�ķ���  ��Ӱ3
insert into GGGroup values('group1001','�ҵĺ���','1095874125','1,2','2016/10/10')
insert into GGGroup values('group1002','����','1095874125','4','2016/10/11')
insert into GGGroup values('group1003','ͬѧ','1095874125','','2016/10/12')
--541789021�ķ���  ��������4
insert into GGGroup values('group1001','�ҵĺ���','541789021','1,2','2016/10/10')
insert into GGGroup values('group1002','����','541789021','3','2016/10/11')
insert into GGGroup values('group1003','ͬѧ','541789021','','2016/10/12')
go


--�����¼
create table ChatMessageRecord (
	chatRecordAutoId bigint primary key identity,
	[chatRecordId] [uniqueidentifier],
	sendId int,--��� GGUser(userAutoid)
	receiveId int,--��� GGUser(userAutoid)
	isGroupChat bit,--�Ƿ�ΪȺ��
	content text,
	occureTime datetime	
) 
GO
 
 

select*from GGGroup
go