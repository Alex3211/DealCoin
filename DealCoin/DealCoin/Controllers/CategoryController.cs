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
    public class CategoryController : Controller
    {
        readonly CategoryServices _CategoryService;
        public CategoryController(CategoryServices CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            Result<IEnumerable<Category>> result = _CategoryService.GetAllCategory();
            return new JsonResult(result);
        }
    }
}