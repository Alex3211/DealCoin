﻿CREATE TABLE [dc].[users]
(
userId INT NOT NULL IDENTITY(1,1),
email varchar(64) NOT NULL,
[Password] varbinary(128) not null,
fname varchar(255) not null,
lname varchar(255) not null,
phone varchar(255) not null,
addresse varchar(255),
departement varchar(255),
city varchar(255),
postale varchar(255),
role varchar(35) default 'user',
status int DEFAULT '0',
visits int DEFAULT '0',
last_login date,

constraint PK_users primary key(userId),
constraint UK_users_email unique(email)
);