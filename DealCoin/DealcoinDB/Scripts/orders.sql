CREATE TABLE [dc].[orders]
(
ordersId int identity(0,1) NOT NULL,
usersId int NOT NULL,
fname varchar(255) not null,
lname varchar(255) not null,
phone varchar(255) not null,
addresse varchar(255),
departement varchar(255),
city varchar(255),
postale varchar(255),
delivery_fname varchar(255) not null,
delivery_lname varchar(255) not null,
delivery_phone varchar(255) not null,
delivery_adresse varchar(255) not null,
delivery_departement varchar(255) not null,
delivery_city varchar(255) not null,
delivery_postale varchar(255) not null,
shipping_cost decimal(10,2) not null,
 
constraint PK_orders primary key(ordersId),
constraint FK_orders_users foreign key(usersId) references dc.users(usersId)
)
