using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class ReportingRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public List<SalesDetails> PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            List<SalesDetails> salesDetails = new List<SalesDetails>();
            var saleProducts = db.Sales.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
             foreach(var product in saleProducts)
            {
                var saleProduct = db.SalesDetails.Include(c => c.Product).Where(c => c.SalesId == product.Id).FirstOrDefault();
                salesDetails.Add(saleProduct);
            }
            return salesDetails;
        }
        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductViewModel productViewModel)
        {
            List<PurchaseDetails> purchaseDetails= new List<PurchaseDetails>();
            var purchaseProducts = db.Purchases.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in purchaseProducts)
            {
                var purchaseProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.PurchaseId == product.Id).FirstOrDefault();
                purchaseDetails.Add(purchaseProduct);
            }
            return purchaseDetails;
        }
    }
}
