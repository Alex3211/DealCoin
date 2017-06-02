using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DealCoin.DAL
{
    public class ArticleLink
    {
        readonly string _connectionString;

        public ArticleLink(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Article> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Article>("select * from dc.products");
            }
        }
    }
}
