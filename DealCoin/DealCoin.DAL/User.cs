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

        public int Nom { get; set; }

        public int Prenom { get; set; }

        public int Tel { get; set; }

        public int Adresse { get; set; }
        public int Departement { get; set; }
        public int City { get; set; }
        public int Postal { get; set; }
        public string role { get; set; }
        public int Statut { get; set; }
        public int Visites { get; set; }
        public int LastLogin { get; set; }

    }
}
