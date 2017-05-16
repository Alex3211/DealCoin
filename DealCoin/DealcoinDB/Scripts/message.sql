CREATE TABLE [dc].[message]
(
messageId INT NOT NULL IDENTITY(1,1),
email varchar(50) NOT NULL,
phone varchar(15),
subject varchar(200),
message varchar(4000),
response varchar(4000),
status int default 0,
posted_date date,

constraint PK_message primary key(messageId),

)
