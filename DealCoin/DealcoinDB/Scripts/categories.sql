CREATE TABLE [dc].[categories] (
categoriesId INT NOT NULL IDENTITY(1,1),
name varchar(50) NOT NULL,
parentId int NOT NULL,
type int NOT NULL,
description varchar(300) DEFAULT NULL,
status int DEFAULT 0,
position int NOT NULL,
posted_date date NOT NULL,

 constraint PK_tCategories primary key(CategoriesId),
 constraint FK_categories_categories foreign key (parentId) references dc.categories(parentId)
);