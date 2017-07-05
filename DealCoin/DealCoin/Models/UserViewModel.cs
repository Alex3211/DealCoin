using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DealCoin.Models
{
    public class UserViewModel
    {
        public string email { get; set; }

        public string password { get; set; }

        public byte[] passwordb { get; set; }

        public int userId { get; set; }
        
        public string nom { get; set; }
       
        public string prenom { get; set; }
     
        public string phone { get; set; }
       
        public string addresse { get; set; }
   
        public string departement { get; set; }
        
        public string city { get; set; }
        public string adresse_bitcoin { get; set; }

        public string postale { get; set; }
    }
}
