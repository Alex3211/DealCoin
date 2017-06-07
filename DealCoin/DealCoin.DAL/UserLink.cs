using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Dapper;

namespace DealCoin.DAL
{
    public class UserLink
    {
        readonly string _connectionString;

        public UserLink(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>("select u.userId, u.email, u.[Password], from dc.users u;");
            }
        }
        public User getUser(string _Mail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select userId, email, Password, nom, prenom, phone, addresse,departement,city,postale,role,status,visits,last_login from dc.users where email = @Mail ;",
                        new { Mail = _Mail })
                    .FirstOrDefault();
            }
        }
        public IEnumerable<User> getAllUser()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select userId, email, Password, nom, prenom, phone, addresse,departement,city,postale,role,status,visits,last_login from dc.users;"
                        );
            }
        }
        public IEnumerable<User> GetGoogleUser()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>("select refreshToken, googleId from dc.userGoogle;");
            }
        }
        public User FindByEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select u.UserId, u.Email, u.[Password] from dc.users u where u.email = @Email",
                        new { Email = email })
                    .FirstOrDefault();
            }
        }
        public User FindByGoogleId(string googleId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select  dc.users.email, googleId,refreshToken from dc.googleUser JOIN dc.users ON dc.googleUser.userId = dc.users.userId where googleId = @GoogleId",
                        new { GoogleId = googleId })
                    .FirstOrDefault();
            }
        }
        public void AddGoogleToken(int userId, string googleId, string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query<User>(
                    "insert into dc.googleUser(UserId,  GoogleId,  RefreshToken) values(@UserId, @GoogleId, @RefreshToken); ",
                    new { UserId = userId, GoogleId = googleId, RefreshToken = refreshToken })
                    .FirstOrDefault();
            }
        }
        public void CreatePasswordUser(string email, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                   "dc.SpasswordUserCreate",
                   new { Email = email, Password = password },
                   commandType: CommandType.StoredProcedure);
            }
        }

        public void CreateGoogleUser(string email, string googleId, string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dc.SgoogleUserCreate",
                    new { Email = email, GoogleId = googleId, RefreshToken = refreshToken },
                    commandType: CommandType.StoredProcedure);
            }

        }
        public IEnumerable<string> GetAuthenticationProviders(string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<string>(
                    "select p.ProviderName from dc.vAuthenticationProvider p where p.UserId = @userId",
                    new { UserId = userId });
            }
        }

        public void Delete(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute("dc.SuserDelete", new { UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateEmail(int userId, string email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dc.SuserUpdate",
                    new { UserId = userId, Email = email },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePassword(int userId, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "dc.SpasswordUserUpdate",
                    new { UserId = userId, Password = password },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateGoogleToken(string googleId, string refreshToken)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query<string>(
                    "update dc.googleUser set refreshToken = @RefreshToken where googleId = @GoogleId;",
                    new { GoogleId = googleId, RefreshToken = refreshToken });
            }
        }

        public IEnumerable<User> UpdateUser(int _userId,string _nom, string _prenom, string _phone, string _addresse,
            string _departement, string _city, string _postale)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                    "update dc.users set nom = @nom, prenom = @prenom, phone = @phone, addresse = @addresse, departement = @departement, city = @city, postale = @postale where userId = @userId; ",
                new { userId=_userId, nom = _nom, prenom = _prenom, phone = _phone, addresse = _addresse, departement = _departement, city = _city, postale = _postale });
            }
        }
    }
}
