using AutoMapper;
using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class CustomerController : Controller
    {
        Customer _customer = new Customer();
        string _fileName = "";
        CustomerManager _customerManager = new CustomerManager();

        public ActionResult Index()
        {
            List<CustomerViewModel> customers = _customerManager.GetCustomers().Select(c => new CustomerViewModel
            {
                Id = c.Id,
                CustomerName = c.CustomerName,
                CustomerCode = c.CustomerCode,
                Address = c.Address,
                Email = c.Email,
                Contact = c.Contact,
                LoyaltyPoint = c.LoyaltyPoint
            }).ToList();
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = customers;
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Index(CustomerViewModel customerViewModel)
        {
            if(customerViewModel.SearchText!=string.Empty && customerViewModel.SearchText != null)
            {
                var customers = _customerManager.SearchCustomers(customerViewModel).Select(c => new CustomerViewModel
                {
                    Id = c.Id,
                    CustomerName = c.CustomerName,
                    CustomerCode = c.CustomerCode,
                    Address = c.Address,
                    Email = c.Email,
                    Contact = c.Contact,
                    LoyaltyPoint = c.LoyaltyPoint
                }).ToList();
                CustomerViewModel aCustomer = new CustomerViewModel();
                aCustomer.Customers = customers;
                return View(aCustomer);
            }
            else
            {
                List<CustomerViewModel> customers = _customerManager.GetCustomers().Select(c => new CustomerViewModel
                {
                    Id = c.Id,
                    CustomerName = c.CustomerName,
                    CustomerCode = c.CustomerCode,
                    Address = c.Address,
                    Email = c.Email,
                    Contact = c.Contact,
                    LoyaltyPoint = c.LoyaltyPoint
                }).ToList();
                CustomerViewModel aCustomerViewModel = new CustomerViewModel();
                aCustomerViewModel.Customers = customers;
                return View(aCustomerViewModel);
            }
        }
        public ActionResult SaveCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCustomer(CustomerViewModel customerViewModel,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    _fileName = Path.GetFileNameWithoutExtension(image.FileName);
                    string extension = Path.GetExtension(image.FileName);
                    _fileName = _fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    customerViewModel.ImagePath= "~/Resourses/" + _fileName;
                }
                customerViewModel.ActionType = "Insert";
                if (_customerManager.IsExistCustomer(customerViewModel) == false)
                {
                    _customer = Mapper.Map<Customer>(customerViewModel);
                    if (_customerManager.SaveCustomer(_customer))
                    {
                        _fileName = Path.Combine(Server.MapPath("~/Resourses/"), _fileName);
                        image.SaveAs(_fileName);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Message = "This Customer Is Already Exist!";
                }
            }
            return View(customerViewModel);
        }
        public ActionResult UpdateCustomer(int id)
        {
            _customer.Id = id;
            var aCustomer = _customerManager.GetCustomerById(_customer);
            if (aCustomer == null)
            {
                ViewBag.Message = "No Customer Found!";
                return View();
            }
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel = Mapper.Map<CustomerViewModel>(aCustomer);
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(CustomerViewModel customerViewModel,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    _fileName = Path.GetFileNameWithoutExtension(image.FileName);
                    string extension = Path.GetExtension(image.FileName);
                    _fileName = _fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    customerViewModel.ImagePath = "~/Resourses/" + _fileName;
                }
                customerViewModel.ActionType = "Update";
                if (_customerManager.IsExistCustomer(customerViewModel)==false)
                {
                    _customer.Id = customerViewModel.Id;
                    _customer = _customerManager.GetCustomerById(_customer);
                    if (_customer != null)
                    {
                        //_customer = Mapper.Map<Customer>(customerViewModel);
                        _customer.Id = customerViewModel.Id;
                        _customer.CustomerName = customerViewModel.CustomerName;
                        _customer.CustomerCode = customerViewModel.CustomerCode;
                        _customer.Address = customerViewModel.Address;
                        _customer.Email = customerViewModel.Email;
                        _customer.Contact = customerViewModel.Contact;
                        _customer.LoyaltyPoint = customerViewModel.LoyaltyPoint;
                        _customer.ImagePath = customerViewModel.ImagePath;
                        _customer.Date = customerViewModel.Date;
                        _customer.IsActive = customerViewModel.IsActive;
                        if (_customerManager.UpdateCustomer(_customer))
                        {
                            _fileName = Path.Combine(Server.MapPath("~/Resourses/"), _fileName);
                            image.SaveAs(_fileName);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Message = "Opps! Your Current Operation Failed.";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Customer Not Found!";
                    }
                }
                else
                {
                    ViewBag.Message = "This Customer Is Already Exist!";
                }
            }
            return View(customerViewModel);
        }
        public ActionResult CustomerDetails(int id)
        {
            _customer.Id = id;
            var aCustomer = _customerManager.GetCustomerById(_customer);
            if (aCustomer == null)
            {
                ViewBag.Message = "No Customer Found!";
                return View();
            }
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel = Mapper.Map<CustomerViewModel>(aCustomer);
            return View(customerViewModel);
        }
        public ActionResult DeleteCustomer(int id)
        {
            _customer.Id = id;
            var aCustomer = _customerManager.GetCustomerById(_customer);
            if (aCustomer == null)
            {
                ViewBag.Message = "No Customer Found!";
                return View();
            }
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel = Mapper.Map<CustomerViewModel>(aCustomer);
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult DeleteCustomer(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Id > 0)
            {
                _customer.Id = customerViewModel.Id;
                _customer = _customerManager.GetCustomerById(_customer);
                if (_customer != null)
                {
                    _customer.IsActive = customerViewModel.IsActive;
                    _customer.Date = customerViewModel.Date;
                    if (_customerManager.DeleteCustomer(_customer))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Opps! Operation Failed...";
                    }
                }
                else
                {
                    ViewBag.Message = "No Customer Found!";
                }
            }
            else
            {
                ViewBag.Message = "Operation Failed!";
            }
            return View(customerViewModel);
        }
    }
}