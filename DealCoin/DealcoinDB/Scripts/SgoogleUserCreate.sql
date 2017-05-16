create procedure dc.SgoogleUserCreate
(
    @email        nvarchar(64),
    @googleId     varchar(32),
    @refreshToken varchar(64)
)
as
begin
    insert into dc.users(email) values(@email);
    declare @userId int;
    select @userId = scope_identity();
    insert into dc.googleUser(userId,  googleId,  refreshToken)
                         values(@userId, @googleId, @refreshToken);
    return 0;
end;