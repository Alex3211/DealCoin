CREATE TABLE [dc].[ordersProducts]
(
orderProductsId INT NOT NULL IDENTITY(1,1),
ordersId int not null,
productsId int NOT NULL,
title varchar(100) NOT NULL,
photo varchar(200),
desc1 varchar(100) NOT NULL,
price varchar(10) NOT NULL,
 
constraint ordersProducts_pk primary key (orderProductsId),
constraint FK_ordersProducts_orders foreign key (ordersId) references dc.orders(ordersId),
constraint FK_ordersproducts_products foreign key(productsId) references dc.products(productsId)
)
