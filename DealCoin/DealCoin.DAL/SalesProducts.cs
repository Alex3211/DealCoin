using System;
using System.Collections.Generic;
using System.Text;

namespace DealCoin.DAL
{
    public class SalesProducts
    {
        public int orderProductsId { get; set; }
        public int ordersId { get; set; }
        public int productsId { get; set; }
        public string title { get; set; }
        public string photo { get; set; }
        public string desc1 { get; set; }
        public string price { get; set; }
    }
}
