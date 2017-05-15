CREATE TABLE orders_products (
id_products INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
orders_id int not null,
id_products int NOT NULL,
title varchar(100) NOT NULL,
photo varchar(200),
desc1 varchar(100) NOT NULL,
price varchar(10) NOT NULL,
 
constraint products_pk primary key (id_products),
constraint FK_orders_products_orders foreign key(orders_id) references dc.orders(orders_id),
constraint FK_orders_products_products foreign key(id_products) references dc.products(id_products)
);