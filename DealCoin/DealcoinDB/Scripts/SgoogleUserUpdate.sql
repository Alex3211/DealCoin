create procedure dc.SgoogleUserUpdate
(
    @googleId varchar(32),
    @refreshToken varchar(64)
)
as
begin
    update dc.googleUser set refreshToken = @refreshToken where googleId = @googleId;
    return 0;
end;