using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DealCoin.Models.AccountView
{
    public class ArticleViewModel
    {
        public int UserId { get; set; }

        [Required]
        public int CategoriesId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string Desc1 { get; set; }

        [Required]
        public string Price { get; set; }

        public DateTime posted_date { get; set; }
        public DateTime created { get; set; }
        public DateTime created_pk { get; set; }
        public DateTime updated { get; set; }
        public DateTime updated_pk { get; set; }
        public DateTime updated_ip { get; set; }
    }
}
