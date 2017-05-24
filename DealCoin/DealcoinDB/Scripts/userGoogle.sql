create table [dc].googleUser
(
    userId       int,
    googleId     NVARCHAR(MAX) not null,
    refreshToken NVARCHAR(MAX) not null,

    constraint PK_googleUser primary key(userId),
    constraint FK_googleUser_userId foreign key(userId) references dc.users(userId)
);