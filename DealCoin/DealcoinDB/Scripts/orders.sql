CREATE TABLE [dc].[orders]
(
ordersId int identity(0,1) NOT NULL,
usersId int NULL,
fname varchar(255) null,
lname varchar(255) null,
phone varchar(255) null,
addresse varchar(255),
departement varchar(255),
city varchar(255),
postale varchar(255),
delivery_fname varchar(255) null,
delivery_lname varchar(255) null,
delivery_phone varchar(255) null,
delivery_adresse varchar(255) null,
delivery_departement varchar(255) null,
delivery_city varchar(255) null,
delivery_postale varchar(255) null,
shipping_cost decimal(10,2) null,
 
constraint PK_orders primary key(ordersId),
constraint FK_orders_users foreign key(usersId) references dc.users(userId)
)
