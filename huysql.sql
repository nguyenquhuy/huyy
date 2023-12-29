create database huy
go

use huy
go

drop table courses
create table userinfo (	
	username nvarchar(50) primary key,
	password nvarchar(100)
)

create table courses (
	CoursesId uniqueidentifier NOT NULL DEFAULT NEWID(),
	name nvarchar(50),
	description nvarchar(200),	
	sources nvarchar(200),
	slug nvarchar(50),
	owner nvarchar(50) foreign key references userinfo(username)
)

insert into userinfo
values('huy1234', 'huy')

insert into courses(name, description, sources, slug, owner) 
values('Khóa học HTML cơ bản', 'Đây là khóa học abcxyz', 'https://www.youtube.com/watch?v=H8smNnt3Dq0&ab_channel=ONEPIECE%E5%85%AC%E5%BC%8FYouTube%E3%83%81%E3%83%A3%E3%83%B3%E3%83%8D%E3%83%AB', 'html', 'huy123')


select * from userinfo
