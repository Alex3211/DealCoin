using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealCoin.DAL
{
    public class ReportViewModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string response { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public int status { get; set; }
        [Required]
        public DateTime posted_date { get; set; }
    }
}
