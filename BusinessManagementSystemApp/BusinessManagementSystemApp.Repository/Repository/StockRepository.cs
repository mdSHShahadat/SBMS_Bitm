using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class StockRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public int ExpiredProductQuantity(Product product)
        {
            int expiredProductQuantity = 0;
            int salesQuantity = 0;
            DateTime today = DateTime.Now;
            var aProducts=db.PurchaseDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach(var aProduct in aProducts)
            {
                if (aProduct.ExpireDate < today)
                {
                    expiredProductQuantity += aProduct.Quantity;
                }
            }
            var sales = db.SalesDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach(var sale in sales)
            {
                salesQuantity += sale.Quantity;
            }
            expiredProductQuantity -= salesQuantity;
            if (expiredProductQuantity < 0)
            {
                expiredProductQuantity = 0;
            }
            return expiredProductQuantity;
        }
    }
}
