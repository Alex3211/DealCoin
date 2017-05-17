using DealCoin.DAL;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace DealCoin.Authentication
{
    public interface IExternalAuthenticationManager
    {
        void CreateOrUpdateUser( OAuthCreatingTicketContext context );

        User FindUser( OAuthCreatingTicketContext context );
    }
}