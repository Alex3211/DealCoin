using System;
using System.Collections.Generic;
using System.Text;

namespace DealCoin.DAL
{
    public class Category
    {
        public int categoriesId { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public int type { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public int position { get; set; }
        public DateTime posted_date { get; set; }
    }
}
