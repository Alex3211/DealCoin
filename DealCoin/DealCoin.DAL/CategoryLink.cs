using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DealCoin.DAL
{
    public class CategoryLink
    {
        readonly string _connectionString;

        public CategoryLink(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Category>("select * from dc.categories");
            }
        }
    }
}