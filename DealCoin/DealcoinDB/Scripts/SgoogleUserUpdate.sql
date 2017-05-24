create procedure dc.SgoogleUserUpdate
(
    @googleId NVARCHAR(MAX),
    @refreshToken NVARCHAR(MAX)
)
as
begin
    update dc.googleUser set refreshToken = @refreshToken where googleId = @googleId;
    return 0;
end;