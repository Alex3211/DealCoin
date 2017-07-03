using System;
using System.Collections.Generic;
using System.Text;

namespace DealCoin.DAL
{
    public class Report
    {
        public string email { get; set; }
        public string phone { get; set; }
        public string subject { get; set; }
        public string response { get; set; }
        public string message { get; set; }
        public int status { get; set; }
        public DateTime posted_date { get; set; }
    }
}
