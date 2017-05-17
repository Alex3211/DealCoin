using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Dapper;

namespace DealCoin.DAL
{
    class UserLink
    {
        readonly string _connectionString;

        public UserLink(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetUser()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>("select u.userId, u.email, u.[Password], from dc.users u;");
            }
        }
        public IEnumerable<User> GetGoogleUser()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>("select u.GoogleRefreshToken, u.GoogleId from dc.users u;");
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
    }
}
