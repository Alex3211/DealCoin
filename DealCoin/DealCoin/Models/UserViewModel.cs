using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DealCoin.Models
{
    public class UserViewModel
    {
        [Required]
        public int userId { get; set; }

        [Required]
        public string nom { get; set; }

        [Required]
        public string prenom { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string addresse { get; set; }

        [Required]
        public string departement { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string postale { get; set; }
    }
}
