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
    public class CustomerRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool SaveCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            return db.SaveChanges() > 0;
        }
        public List<Customer> GetCustomers()
        {
            return db.Customers.Where(c => c.IsActive == "True").ToList();
        }
        public List<Customer> SearchCustomers(CustomerViewModel customerViewModel)
        {
            var customers = db.Customers.Where(c => c.CustomerName.ToLower().Contains(customerViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.CustomerCode.ToLower().Contains(customerViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Address.ToLower().Contains(customerViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Email.ToLower().Contains(customerViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Contact.ToLower().Contains(customerViewModel.SearchText.ToLower()) && c.IsActive == "True").ToList();
            return customers;
        }
        public Customer GetCustomerById(Customer customer)
        {
            return db.Customers.Where(c => c.Id== customer.Id&& c.IsActive == "True").FirstOrDefault();
        }
        public bool UpdateCustomer(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteCustomer(Customer customer)
        {
            db.Customers.Remove(customer);
            return db.SaveChanges() > 0;
        }
        public bool IsExistCustomer(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.ActionType == "Insert")
            {
                var aCustomer = db.Customers.Where(c => c.CustomerName.ToLower() == customerViewModel.CustomerName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aCustomer!= null)
                {
                    return true;
                }
            }
            if (customerViewModel.ActionType == "Update")
            {
                var aCustomer = db.Customers.Where(c => c.CustomerName.ToLower() == customerViewModel.CustomerName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aCustomer != null)
                {
                    if (aCustomer.Id== customerViewModel.Id)
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
