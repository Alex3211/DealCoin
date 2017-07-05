using System;

namespace DealCoin.DAL
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public string GoogleRefreshToken { get; set; }

        public string GoogleId { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string phone { get; set; }
        public string Addresse { get; set; }
        public string Departement { get; set; }
        public string City { get; set; }
        public string Postale { get; set; }
        public string role { get; set; }
        public string adresse_bitcoin { get; set; }
        public int status { get; set; }
        public int Visites { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime First_Login { get; set; }

    }
}
