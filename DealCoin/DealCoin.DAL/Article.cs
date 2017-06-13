using System;
using System.Collections.Generic;
using System.Text;

namespace DealCoin.DAL
{
    public class Article
    {
        public int productsId { get; set; }
        public int userId { get; set; }
        public int categoriesId { get; set; }
        public string title{ get; set; }
        public string photo { get; set; }
        public string desc1 { get; set; }
        public string price { get; set; }
        public string visits { get; set; }
        public DateTime posted_date { get; set; }
        public DateTime created{ get; set; }
        public DateTime created_pk { get; set; }
        public DateTime updated {get; set; }
        public DateTime updated_pk { get; set; }
        public DateTime updated_ip { get; set; }
    }
}
