﻿using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();
        public bool InsertPurchaseProduct(Purchase purchase)
        {
            return _purchaseRepository.InsertPurchaseProduct(purchase);
        }
        public ProductViewModel LatestProduct(Product product)
        {
            return _purchaseRepository.LatestProduct(product);
        }
        public List<PurchaseDetails> GetPurchaseProducts()
        {
            return _purchaseRepository.GetPurchaseProducts();
        }
        public int GetSalesProductQuantity(Product product)
        {
            return _purchaseRepository.GetSalesProductQuantity(product);
        }
    }
}
