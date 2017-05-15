CREATE TABLE orders (
orders_id varchar(35) NOT NULL,
id varchar(35) NOT NULL,
fname varchar(255) not null,
lname varchar(255) not null,
phone varchar(255) not null,
addresse varchar2(255),
departement varchar2(255),
city varchar2(255),
postale varchar2(255),
delivery_fname varchar(255) not null,
delivery_lname varchar(255) not null,
delivery_phone varchar(255) not null,
delivery_adresse varchar(255) not null,
delivery_departement varchar(255) not null,
delivery_city varchar(255) not null,
delivery_postale varchar(255) not null,
shipping_cost decimal(10,2) not null,
 
constraint FK_orders_users foreign key(id) references dc.users(id)
);