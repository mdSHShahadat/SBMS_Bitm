using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class SupplierRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool SaveSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            return db.SaveChanges() > 0;
        }
        public List<Supplier> GetSuppliers()
        {
            return db.Suppliers.Where(c => c.IsActive == "True").ToList();
        }
        public List<Supplier> SearchSupplier(SupplierViewModel supplierViewModel)
        {
            var suppliers = db.Suppliers.Where(c => c.SupplierName.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.SupplierCode.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Address.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Email.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Contact.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.ContactPerson.ToLower().Contains(supplierViewModel.SearchText.ToLower()) && c.IsActive == "True").ToList();
            return suppliers;
        }
        public Supplier GetSupplierById(Supplier supplier)
        {
            return db.Suppliers.Where(c => c.SupplierId== supplier.SupplierId&& c.IsActive == "True").FirstOrDefault();
        }
        public bool UpdateSupplier(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteSupplier(Supplier supplier)
        {
            db.Suppliers.Remove(supplier);
            return db.SaveChanges() > 0;
        }
        public bool IsExistSupplier(SupplierViewModel supplierViewModel)
        {
            if (supplierViewModel.ActionType == "Insert")
            {
                var aSupplier = db.Suppliers.Where(c => c.SupplierName.ToLower() == supplierViewModel.SupplierName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aSupplier!= null)
                {
                    return true;
                }
            }
            if (supplierViewModel.ActionType == "Update")
            {
                var aSupplier = db.Suppliers.Where(c => c.SupplierName.ToLower() == supplierViewModel.SupplierName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aSupplier != null)
                {
                    if (aSupplier.SupplierId== supplierViewModel.SupplierId)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
