using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealCoin.Models
{
    public class SalesProductsViewModel
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
