using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.BLL.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();
        public bool SaveSupplier(Supplier supplier)
        {
            return _supplierRepository.SaveSupplier(supplier);
        }
        public List<Supplier> GetSuppliers()
        {
            return _supplierRepository.GetSuppliers();
        }
        public List<Supplier> SearchSupplier(SupplierViewModel supplierViewModel)
        {
            return _supplierRepository.SearchSupplier(supplierViewModel);
        }
        public Supplier GetSupplierById(Supplier supplier)
        {
            return _supplierRepository.GetSupplierById(supplier);
        }
        public bool UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplier);
        }
        public bool DeleteSupplier(Supplier supplier)
        {
            return _supplierRepository.DeleteSupplier(supplier);
        }
        public bool IsExistSupplier(SupplierViewModel supplierViewModel)
        {
            return _supplierRepository.IsExistSupplier(supplierViewModel);
        }
    }
}
