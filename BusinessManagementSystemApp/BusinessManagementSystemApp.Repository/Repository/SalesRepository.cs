using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class SalesRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public int GetProductAvailableQuantity(Product product)
        {
            int availableQuantity = 0;
            int purchaseQuantity = 0;
            int salesQuantity = 0;
            var purchaseProducts = db.PurchaseDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach(var purchaseProduct in purchaseProducts)
            {
                purchaseQuantity += purchaseProduct.Quantity;
            }
            var salesProducts = db.SalesDetails.Where(c => c.ProductId == product.ProductId).ToList();
            foreach(var salesProduct in salesProducts)
            {
                salesQuantity += salesProduct.Quantity;
            }
            availableQuantity = purchaseQuantity - salesQuantity;
            return availableQuantity;
        }
        public bool SaveSalesProduct(Sales sales)
        {
            db.Sales.Add(sales);
            return db.SaveChanges() > 0;
        }
    }
}
