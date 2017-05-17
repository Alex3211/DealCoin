using System;

namespace DealCoin.DAL
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public string Departement { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public int Statut { get; set; }
        public int Visites { get; set; }
        public string Role { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
