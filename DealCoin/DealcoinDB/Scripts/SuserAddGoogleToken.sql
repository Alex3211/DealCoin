create procedure dc.SuserAddGoogleToken
(
    @userId       int,
    @googleId     varchar(32),
    @refreshToken varchar(64)
)
as
begin
    insert into dc.googleUser(userId,  googleId,  refreshToken)
                         values(@userId, @googleId, @refreshToken);
    return 0;
end;