using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.BLL.Manager
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();
        public int ExpiredProductQuantity(Product product)
        {
            return _stockRepository.ExpiredProductQuantity(product);
        }
    }
}
