using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DealCoin.DAL
{
    public class ReportLink
    {
        readonly string _connectionString;

        public ReportLink(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Report> getAllReport()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Report>(
                        "select * from dc.message;"
                        );
            }
        }

        public IEnumerable<Report> AddReport(string email, string phone, string subject, string message, string response, int status)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Report>(
                    "insert into dc.message([email],[phone],[subject],[message],[response],[status],[posted_date]) " +
                    "values(@Email, @Phone, @Subject, @Message, @Response, @Status, @Date); ",
                    new { Email = email, Phone = phone, Subject = subject, Message = message, Response = response, Status = status, Date = DateTime.Now });
            }
        }

    }
}
