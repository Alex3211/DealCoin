using System;
using DealCoin.DAL;
using System.Collections.Generic;

namespace DealCoin.Services
{
    public class ReportServices
    {
        readonly ReportLink _ReportLink;
        public ReportServices(ReportLink reportLink)
        {
            _ReportLink = reportLink;
        }

        public Result<IEnumerable<Report>> GetAllReport()
        {
            return Result.Success(Status.Ok, _ReportLink.getAllReport());
        }

        public Result<IEnumerable<Report>> AddReportS(string email, string phone, string subject, string message, string response, int status)
        {
            return Result.Success(Status.Ok, _ReportLink.AddReport(email, phone, subject, message, response, status));
        }

    }
}
