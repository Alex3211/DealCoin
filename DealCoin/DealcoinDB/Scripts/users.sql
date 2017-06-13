CREATE TABLE [dc].[users]
(
userId INT NOT NULL IDENTITY(1,1),
email varchar(64) NOT NULL,
[Password] VARBINARY(128) NOT null,
nom varchar(255) null,
prenom varchar(255) null,
phone varchar(255) null,
addresse varchar(255),
departement varchar(255),
city varchar(255),
postale varchar(255),
role varchar(35) ,
status int DEFAULT '0',
visits int DEFAULT '0',
last_login date,
first_login date,

constraint PK_users primary key(userId),
constraint UK_users_email unique(email)
);


