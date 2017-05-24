create procedure dc.SuserAddGoogleToken
(
    @userId       int,
    @googleId     NVARCHAR(MAX),
    @refreshToken NVARCHAR(MAX)
)
as
begin
    insert into dc.googleUser(userId,  googleId,  refreshToken)
                         values(@userId, @googleId, @refreshToken);
    return 0;
end;