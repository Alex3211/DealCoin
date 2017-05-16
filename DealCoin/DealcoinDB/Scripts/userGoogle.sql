create table [dc].googleUser
(
    userId       int,
    googleId     varchar(32) not null,
    refreshToken varchar(64) not null,

    constraint PK_googleUser primary key(userId),
    constraint FK_googleUser_userId foreign key(userId) references dc.users(userId),
    constraint UK_googleUser_googleId unique(googleId)
);