using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DealCoin.Authentication;
using DealCoin.Services;
using DealCoin.DAL;
using DealCoin.Models;

namespace DealCoin.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class SalesController : Controller
    {
        readonly SalesService _salesService;

        public SalesController(SalesService SalesService)
        {
            _salesService = SalesService;
        }

        [HttpGet("{id}")]
        public IActionResult GetSales(int id)
        {
            Result<Sales> result = _salesService.getSales(id);
            return new JsonResult(result);
        }
        [HttpGet("All/")]
        public IActionResult GetAllSales()
        {
            Result<IEnumerable<Sales>> result = _salesService.getAllSales();
            return new JsonResult(result);
        }
        [HttpGet("AllProducts/")]
        public IActionResult GetAllSalesProducts()
        {
            Result<IEnumerable<SalesProducts>> result = _salesService.getAllSalesProducts();
            return new JsonResult(result);
        }
        [HttpGet("AllSaleandProductByUserId/{id}")]
        public IActionResult GetAllSaleandProductByUserId(int id)
        {
            Result<IEnumerable<Sales>> result = _salesService.getAllSaleandProductByUserId(id);
            return new JsonResult(result);
        }

        //[HttpPut("{model}")]
        //public IActionResult UpdateSales([FromBody] SalesViewModel _model)
        //{
        //    Result<IEnumerable<Sales>> result = _salesService.UpdateSales(_model.SalesId, _model.nom, _model.prenom, _model.phone,
        //    _model.addresse, _model.departement, _model.city, _model.postale);
        //    return new JsonResult(result);
        //}
        [HttpDelete("{Id}")]
        public bool DeleteEvent(int Id)
        {
            _salesService.DeleteSales(Id);
            return (true);
        }
    }
}