create procedure dc.SpasswordUserCreate
(
    @email    nvarchar(64),
    @Password varbinary(128)
)
as
begin
    insert into dc.users(email,[Password]) values(@email,@Password);
    return 0;
end;