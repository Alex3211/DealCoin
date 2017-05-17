using System;
using Microsoft.AspNetCore.Builder;

namespace DealCoin.Authentication
{
    public static class GoogleAppBuilderExtensions
    {
        public static IApplicationBuilder UseGoogleAuthentication( this IApplicationBuilder app, Action<GoogleOptions> configuration )
        {
            GoogleOptions options = new GoogleOptions();
            configuration( options );
            app.UseGoogleAuthentication( options );
            return app;
        }
    }
}
