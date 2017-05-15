CREATE TABLE users (
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
email varchar(35) NOT NULL,
password varchar(40) NOT NULL,
fname varchar(255) not null,
lname varchar(255) not null,
phone varchar(255) not null,
addresse varchar2(255),
departement varchar2(255),
city varchar2(255),
postale varchar2(255),
role varchar(35) default 'user',
status int DEFAULT '0',
visits int DEFAULT '0',
last_login date DEFAULT sysdate,
created date default sysdate,
created_ip varchar(15) NOT NULL,
updated date default sysdate,
updated_ip varchar(15) NOT NULL,
updated_pk varchar(35) NOT NULL,
 
constraint users_pk primary key (id)
);