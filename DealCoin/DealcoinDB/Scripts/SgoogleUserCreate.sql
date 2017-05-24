create procedure dc.SgoogleUserCreate
(
    @email        nvarchar(64),
    @googleId     NVARCHAR(MAX),
    @refreshToken NVARCHAR(MAX)
)
as
begin
    insert into dc.users(email,Password) values(@email,1);
    declare @userId int;
    select @userId = scope_identity();
    insert into dc.googleUser(userId,  googleId,  refreshToken)
                         values(@userId, @googleId, @refreshToken);
    return 0;
end;