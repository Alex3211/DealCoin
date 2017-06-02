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
    }
}
