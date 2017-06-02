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

namespace DealCoin.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class ArticleController : Controller
    {
        readonly ArticleService _articleService;
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetArticles()
        {
            Result<IEnumerable<Article>> result = _articleService.GetAllArticles();
            return new JsonResult(result);
        }
    }
}