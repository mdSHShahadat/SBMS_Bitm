using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.BLL.Manager
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool SaveCustomer(Customer customer)
        {
            return _customerRepository.SaveCustomer(customer);
        }
        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
        public List<Customer> SearchCustomers(CustomerViewModel customerViewModel)
        {
            return _customerRepository.SearchCustomers(customerViewModel);
        }
        public Customer GetCustomerById(Customer customer)
        {
            return _customerRepository.GetCustomerById(customer);
        }
        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }
        public bool DeleteCustomer(Customer customer)
        {
            return _customerRepository.DeleteCustomer(customer);
        }
        public bool IsExistCustomer(CustomerViewModel customerViewModel)
        {
            return _customerRepository.IsExistCustomer(customerViewModel);
        }
    }
}
