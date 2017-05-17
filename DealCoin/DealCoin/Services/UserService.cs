using System;
using System.Collections.Generic;
using DealCoin.DAL;

namespace DealCoin.Services
{
    public class UserService
    {
        readonly UserLink _userLink;
        readonly PasswordHasher _passwordHasher;

        public UserService( UserLink userLink, PasswordHasher passwordHasher )
        {
            _userLink = userLink;
            _passwordHasher = passwordHasher;
        }

        public bool CreatePasswordUser( string email, string password )
        {
            if(_userLink.FindByEmail( email ) != null ) return false;
            _userLink.CreatePasswordUser( email, _passwordHasher.HashPassword( password ) );
            return true;
        }

        public bool CreateOrUpdateGoogleUser( string email, string googleId, string refreshToken )
        {
            if(_userLink.FindByGoogleId( googleId ) != null )
            {
                _userLink.UpdateGoogleToken( googleId, refreshToken );
                return false;
            }
            User user = _userLink.FindByEmail( email );
            if( user != null )
            {
                _userLink.AddGoogleToken( user.UserId, googleId, refreshToken );
                return false;
            }
            _userLink.CreateGoogleUser( email, googleId, refreshToken );
            return true;
        }

        public User FindUser( string email, string password )
        {
            User user = _userLink.FindByEmail( email );
            if( user != null && _passwordHasher.VerifyHashedPassword( user.Password, password ) == PasswordVerificationResult.Success )
            {
                return user;
            }

            return null;
        }

        public User FindUser( string email )
        {
            return _userLink.FindByEmail( email );
        }

        public User FindGoogleUser( string googleId )
        {
            return _userLink.FindByGoogleId( googleId );
        }

        public User FindGithubUser( int githubId )
        {
            return _userLink.FindByGithubId( githubId );
        }

        public IEnumerable<string> GetAuthenticationProviders( string userId )
        {
            return _userLink.GetAuthenticationProviders( userId );
        }
    }
}
