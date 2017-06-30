using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DealCoin.DAL
{
    public class SalesLink
    {
        readonly string _connectionString;

        public SalesLink(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Sales getSales(int _id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Sales>(
                        "select SalesId, email, Password, nom, prenom, phone, addresse,departement,city,postale,role,status,visits,last_login from dc.Saless where email = @Mail ;",
                        new { Id = _id })
                    .FirstOrDefault();
            }
        }
        public IEnumerable<Sales> getAllSales()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Sales>(
                        "select * from dc.orders;"
                        );
            }
        }
        public IEnumerable<SalesProducts> getAllSalesProducts()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<SalesProducts>(
                        "select * from dc.ordersProducts;"
                        );
            }
        }
        
        public IEnumerable<Sales> getAllSaleandProductByUserId(int _id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Sales>(
                        "SELECT * FROM dc.orders  inner JOIN dc.ordersProducts on  orders.ordersId = ordersProducts.ordersId  where orders.usersId = @Id", 
                        new { Id = _id }
                        );
            }
        }
        public void CreateSales(string email, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                   "dc.SpasswordSalesCreate",
                   new { Email = email, Password = password },
                   commandType: CommandType.StoredProcedure);
            }
        }
        

        public void delete(int SalesId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute("dc.SSalesDelete", new { SalesId = SalesId }, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Sales> UpdateSales(int _SalesId, string _nom, string _prenom, string _phone, string _addresse,
            string _departement, string _city, string _postale)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Sales>(
                    "update dc.Saless set nom = @nom, prenom = @prenom, phone = @phone, addresse = @addresse, departement = @departement, city = @city, postale = @postale where SalesId = @SalesId; ",
                new { SalesId = _SalesId, nom = _nom, prenom = _prenom, phone = _phone, addresse = _addresse, departement = _departement, city = _city, postale = _postale });
            }
        }
        
    }
}
