﻿using System;
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

        public Result<IEnumerable<Article>> GetAllArticles()
        {
            return Result.Success(Status.Ok, _articleLink.GetAll());
        }
        public Result<IEnumerable<Article>> GetArticlesById(int id)
        {
            return Result.Success(Status.Ok, _articleLink.GetAllArticleById(id));
        }

        public Result<IEnumerable<Article>> AddArticles(int userId, int categorieId, string title, string photo, string desc1, string price)
        {
            return Result.Success(Status.Ok, _articleLink.AddArticlesR(userId, categorieId, title, photo, desc1, price));
        }

        public Result<IEnumerable<Article>> UpdateArticles(int userId, int categorieId, string title, string photo, string desc1, string price, int productsId)
        {
            return Result.Success(Status.Ok, _articleLink.UpdateArticlesR(userId, categorieId, title, photo, desc1, price, productsId));
        }

        public Result<IEnumerable<Article>> DeleteArticles(int id)
        {
            return Result.Success(Status.Ok, _articleLink.DeleteArticlesR(id));
        }

        public bool UpdateNbVisits(int _userId, int _visits)
        {
            _articleLink.UpdateNbVisits(_userId, _visits);
            return (true);
        }
    }
}
