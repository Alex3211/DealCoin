﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealCoin.Models
{
    public class SalesViewModel
    {
        public int ordersId { get; set; }
        public int userId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string phone { get; set; }
        public string addresse { get; set; }
        public string departement { get; set; }
        public string city { get; set; }
        public string postale { get; set; }
        public string delivery_fname { get; set; }
        public string delivery_lname { get; set; }
        public string delivery_phone { get; set; }
        public string fdelivery_addresse { get; set; }
        public string delivery_departement { get; set; }
        public string delivery_city { get; set; }
        public string delivery_postale { get; set; }
        public float shipping_cost { get; set; }
    }
}
