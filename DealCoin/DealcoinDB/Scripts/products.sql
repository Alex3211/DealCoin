﻿CREATE TABLE [dc].[products]
(
productsId int IDENTITY(1,1) NOT NULL,
userId int  NOT NULL,
categoriesId int NULL,
title varchar(MAX) NULL,
photo varchar(MAX),
desc1 varchar(MAX) NULL,
price varchar(10) NULL,
visits int DEFAULT 0,
posted_date date NULL,
created date NULL,
created_pk varchar(35) NULL,
created_ip varchar(15) NULL,
updated date NULL,
updated_pk varchar(35) NULL,
updated_ip varchar(15) NULL,
 
constraint products_pk primary key (productsId),
constraint FK_products_categories foreign key(categoriesId) references dc.categories(categoriesId)
)
