CREATE TABLE products (
id_products int NOT NULL,
category_pk varchar(50) NOT NULL,
title varchar(100) NOT NULL,
photo varchar(200),
desc1 varchar(100) NOT NULL,
price varchar(10) NOT NULL,
posted_date date NOT NULL,
created date NOT NULL,
created_pk varchar(35) NOT NULL,
created_ip varchar(15) NOT NULL,
updated date NOT NULL,
updated_pk varchar(35) NOT NULL,
updated_ip varchar(15) NOT NULL,
 
constraint products_pk primary key (id)
);