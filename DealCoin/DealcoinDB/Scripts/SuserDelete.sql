create procedure dc.SuserDelete
(
    @userId int
)
as
begin
    delete from dc.googleUser where userId = @userId;
    delete from dc.users where userId = @userId;
    return 0;
end;