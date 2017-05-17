﻿using System;
using Microsoft.IdentityModel.Tokens;

namespace DealCoin.Authentication
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays( 5 );

        public SigningCredentials SigningCredentials { get; set; }
    }
}