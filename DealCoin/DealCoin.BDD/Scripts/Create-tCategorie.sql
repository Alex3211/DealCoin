CREATE TABLE categories (
name varchar(50) NOT NULL,
type int NOT NULL,
description varchar(300) DEFAULT NULL,
status int DEFAULT 0,
position int NOT NULL,
posted_date date NOT NULL,
created date NOT NULL,
created_pk varchar(35) NOT NULL,
created_ip varchar(15) NOT NULL,
updated date NOT NULL,
updated_pk varchar(35) NOT NULL,
updated_ip varchar(15) NOT NULL,
 
constraint category_pk primary key (name)
);