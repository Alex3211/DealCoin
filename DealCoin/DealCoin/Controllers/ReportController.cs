using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DealCoin.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DealCoin.Services;
using DealCoin.DAL;
using DealCoin.Models.AccountView;
using System.IO;
using System.Text;

namespace DealCoin.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class ReportController : Controller
    {
        readonly ReportServices _reportController;
        public ReportController(ReportServices ReportService)
        {
            _reportController = ReportService;
        }

        [HttpGet]
        public IActionResult GetAllReports()
        {
            Result<IEnumerable<Report>> result = _reportController.GetAllReport();
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult AddReport([FromBody] ReportViewModel _model)
        {
            
            Result<IEnumerable<Article>> result = _reportController.AddReportS(_model.email, _model.phone, _model.subject, _model.message, _model.response, _model.status);
            return new JsonResult(result);
        }
    }
}