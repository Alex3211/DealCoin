CREATE TABLE [dc].[products]
(
productsId int IDENTITY(1,1) NOT NULL,
categoriesId int NULL,
title varchar(100) NULL,
photo varchar(200),
desc1 varchar(100) NULL,
price varchar(10) NULL,
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
