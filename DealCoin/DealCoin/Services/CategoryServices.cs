using System;
using DealCoin.DAL;
using System.Collections.Generic;

namespace DealCoin.Services
{
    public class CategoryServices
    {
        readonly CategoryLink _CategoryLink;
        public CategoryServices(CategoryLink articleLink)
        {
            _CategoryLink = articleLink;
        }

        public Result<IEnumerable<Category>> GetAllCategory()
        {
            return Result.Success(Status.Ok, _CategoryLink.GetAll());
        }

    }
}
