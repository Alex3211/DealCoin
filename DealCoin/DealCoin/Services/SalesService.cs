using DealCoin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealCoin.Services
{
    public class SalesService
    {
        readonly SalesLink _SalesLink;
        readonly PasswordHasher _passwordHasher;

        public SalesService(SalesLink SalesLink, PasswordHasher passwordHasher)
        {
            _SalesLink = SalesLink;
            _passwordHasher = passwordHasher;
        }
        public Result<Sales> getSales(int id)
        {
            Sales Sales = _SalesLink.getSales(id);
            return Result.Success(Status.Ok, Sales);
        }

        public Result<IEnumerable<Sales>> getAllSales()
        {
            return Result.Success(Status.Ok, _SalesLink.getAllSales());
        }
        public Result<IEnumerable<SalesProducts>> getAllSalesProducts()
        {
            return Result.Success(Status.Ok, _SalesLink.getAllSalesProducts());
        }
        
        public Result<IEnumerable<Sales>> getAllSaleandProductByUserId(int _id)
        {
            return Result.Success(Status.Ok, _SalesLink.getAllSaleandProductByUserId(_id));
        }
        public void DeleteSales(int _id)
        {
            _SalesLink.delete(_id);
        }

        public Result<IEnumerable<Sales>> UpdateSales(int SalesId, string nom, string prenom, string phone, string addresse,
            string departement, string city, string postale)
        {
            return Result.Success(Status.Ok, _SalesLink.UpdateSales(SalesId, nom, prenom, phone, addresse, departement,
            city, postale));
        }
        
    }
}
