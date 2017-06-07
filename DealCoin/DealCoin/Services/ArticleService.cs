using System;
using DealCoin.DAL;
using System.Collections.Generic;

namespace DealCoin.Services
{
    public class ArticleService
    {
        readonly ArticleLink _articleLink;
        public ArticleService(ArticleLink articleLink)
        {
            _articleLink = articleLink;
        }

        public Result<IEnumerable<Article>> GetAllArticles() {
            return Result.Success(Status.Ok, _articleLink.GetAll());
        }

        public Result<IEnumerable<Article>> AddArticles(int userId, int categorieId, string title, string photo, string desc1, string price)
        {
            return Result.Success(Status.Ok, _articleLink.AddArticlesR(userId, categorieId, title, photo, desc1, price));
        }
    }
}
