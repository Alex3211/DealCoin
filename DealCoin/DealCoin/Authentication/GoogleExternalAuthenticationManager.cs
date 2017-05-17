using DealCoin.DAL;
using DealCoin.Services;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace DealCoin.Authentication
{
    public class GoogleExternalAuthenticationManager : IExternalAuthenticationManager
    {
        readonly UserService _userService;

        public GoogleExternalAuthenticationManager( UserService userService )
        {
            _userService = userService;
        }

        public void CreateOrUpdateUser( OAuthCreatingTicketContext context )
        {
            if( context.RefreshToken != null )
            {
                _userService.CreateOrUpdateGoogleUser( context.GetEmail(), context.GetGoogleId(), context.RefreshToken );
            }
        }

        public User FindUser( OAuthCreatingTicketContext context )
        {
            return _userService.FindGoogleUser( context.GetGoogleId() );
        }
    }
}
