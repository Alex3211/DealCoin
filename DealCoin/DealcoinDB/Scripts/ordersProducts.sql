CREATE TABLE [dc].[ordersProducts]
(
orderProductsId INT NOT NULL IDENTITY(1,1),
ordersId int null,
productsId int NULL,
title varchar(100) NULL,
photo varchar(200),
desc1 varchar(100) NULL,
price varchar(10) NULL,
 
constraint ordersProducts_pk primary key (orderProductsId),
constraint FK_ordersProducts_orders foreign key (ordersId) references dc.orders(ordersId),
constraint FK_ordersproducts_products foreign key(productsId) references dc.products(productsId)
)
