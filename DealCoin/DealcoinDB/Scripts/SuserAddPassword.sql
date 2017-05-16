create procedure dc.SuserAddPassword
(
    @userId   int,
    @password varbinary(128)
)
as
begin
    insert into dc.users(userId,  [Password])
                           values(@userId, @password);
    return 0;
end;