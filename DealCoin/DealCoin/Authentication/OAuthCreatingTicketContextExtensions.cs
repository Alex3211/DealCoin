﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace DealCoin.Authentication
{
    public static class OAuthCreatingTicketContextExtensions
    {
        public static string GetEmail( this OAuthCreatingTicketContext @this )
        {
            return @this.Identity.FindFirst( c => c.Type == ClaimTypes.Email ).Value;
        }

        public static string GetGoogleId( this OAuthCreatingTicketContext @this )
        {
            return @this.GetNameIdentifier();
        }

        public static int GetGithubId( this OAuthCreatingTicketContext @this )
        {
            return int.Parse( @this.GetNameIdentifier() );
        }

        static string GetNameIdentifier( this OAuthCreatingTicketContext @this )
        {
            return @this.Identity.FindFirst( c => c.Type == ClaimTypes.NameIdentifier ).Value;
        }
    }
}
