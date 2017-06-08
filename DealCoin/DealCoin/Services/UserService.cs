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
        public Result<User> getUser(string email)
        {
            User user = _userLink.getUser(email);
            return Result.Success(Status.Ok, user);
        }
        public Result<IEnumerable<User>> getAllUser()
        {
            return Result.Success(Status.Ok, _userLink.getAllUser());
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

        public IEnumerable<string> GetAuthenticationProviders( string userId )
        {
            return _userLink.GetAuthenticationProviders( userId );
        }

        public Result<IEnumerable<User>> UpdateUser(int userId,string nom, string prenom, string phone, string addresse,
            string departement, string city, string postale)
        {
            return Result.Success(Status.Ok, _userLink.UpdateUser(userId,nom,prenom,phone,addresse,departement,
            city,postale));
        }
        public void DeleteUser(int _id)
        {
            _userLink.delete(_id);
        }
    }
}
