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
    public class ArticleController : Controller
    {
        readonly ArticleService _articleService;
        readonly ArticleViewModel _model;
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

        [HttpGet("Id/{id}")]
        public IActionResult GetArticles(int id)
        {
            Result<IEnumerable<Article>> result = _articleService.GetArticlesById(id);
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult AddArticles([FromBody] ArticleViewModel _model)
        {
            Result<IEnumerable<Article>> result = _articleService.AddArticles(_model.UserId, _model.CategoriesId, _model.Title, _model.Photo, _model.Desc1, _model.Price);
            return new JsonResult(result);
        }
    }
}