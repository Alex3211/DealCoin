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

        public IEnumerable<Article> GetAllArticleById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Article>("select * from dc.products where userId = @Id",
                new { Id = id});

            }
        }

        public IEnumerable<Article> AddArticlesR(int userId, int categorieId, string title, string photo, string desc1, string price)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Article>(
                    "insert into dc.products([userId],[categoriesId],[title],[photo],[desc1],[price],[posted_date],[created],[created_pk],[created_ip],[updated],[updated_pk],[updated_ip]) " +
                    "values(@UserId, @categorieId, @title, @photo, @desc1, @price,null,null,null,null,null,null,null); ",
                    new { UserId = userId, categorieId = categorieId, title = title, photo = photo, desc1 = desc1, price = price });
            }
        }

        public IEnumerable<Article> UpdateArticlesR(int userId, int categorieId, string title, string photo, string desc1, string price, int productsId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Article>(
                    "UPDATE [dc].[products] SET [userId] = @UserId, [categoriesId] = @categorieId, [title] = @title, [photo] = @photo, [desc1] = @desc1, [price] = @price WHERE [productsId] = @ProductsId;",
                    new { UserId = userId, categorieId = categorieId, title = title, photo = photo, desc1 = desc1, price = price, ProductsId = productsId });
            }
        }

        public IEnumerable<Article> DeleteArticlesR(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Article>(
                    "DELETE FROM [dc].[products] WHERE productsId = @ID",
                    new { ID = id });
            }
        }
    }
}
