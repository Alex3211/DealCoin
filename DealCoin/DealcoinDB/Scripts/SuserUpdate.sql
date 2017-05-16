create procedure dc.SuserUpdate
(
    @userId int,
    @email  nvarchar(64)
)
as
begin
    update dc.users
    set email = @email
    where userId = @userId;
    return 0;
end;