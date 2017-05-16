create procedure dc.SpasswordUserUpdate
(
    @userId   int,
    @password varbinary(128)
)
as
begin
    update dc.users set [Password] = @password where userId = @userId;
    return 0;
end;