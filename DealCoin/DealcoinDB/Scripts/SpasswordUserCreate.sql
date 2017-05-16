create procedure dc.SpasswordUserCreate
(
    @email    nvarchar(64),
    @password varbinary(128)
)
as
begin
    insert into dc.users(email) values(@email);
    declare @userId int;
    select @userId = scope_identity();
    insert into dc.users(userId,  [Password])
                           values(@userId, @Password);
    return 0;
end;