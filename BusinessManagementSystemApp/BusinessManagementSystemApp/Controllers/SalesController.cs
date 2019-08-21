﻿using BusinessManagementSystemApp.BLL.BLL;
using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class SalesController : Controller
    {
        Customer _customer = new Customer();
        Product _product = new Product();
        Sales _sales = new Sales();
        CustomerManager _customerManager = new CustomerManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();
        // GET: Sales
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult SaveSalesProduct()
        {
            var customers = _customerManager.GetCustomers();
            ViewBag.Customers = new SelectList(customers, "Id", "CustomerName");
            var products = _productManager.GetProducts();
            ViewBag.Products = new SelectList(products, "ProductId", "ProductName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveSalesProduct(SalesViewModel salesViewModel)
        {
            _sales.CustomerId = salesViewModel.CustomerId;
            _sales.Date = salesViewModel.Date;
            _sales.DiscountPerCent = salesViewModel.DiscountParcent;
            _sales.DiscountAmount = salesViewModel.DiscountAmount;
            _sales.PayableAmount = salesViewModel.PayableAmount;
            _sales.SalesDetails = salesViewModel.SalesDetails;
            if (_salesManager.SaveSalesProduct(_sales))
            {
                //Update Customer Loyalty Point Start
                _customer.Id = salesViewModel.CustomerId;
                _customer = _customerManager.GetCustomerById(_customer);
                if (_customer != null)
                {
                    if (salesViewModel.DiscountAmount > 0)
                    {
                        int loyaltyPoint = Convert.ToInt32(salesViewModel.GrandTotal / 1000);
                        _customer.LoyaltyPoint = loyaltyPoint;
                    }
                    else
                    {
                        int loyaltyPoint = Convert.ToInt32(salesViewModel.GrandTotal / 1000);
                        _customer.LoyaltyPoint += loyaltyPoint;
                    }
                    if (_customerManager.UpdateCustomer(_customer))
                    {
                        ViewBag.Message = "Saved.";
                        var customers = _customerManager.GetCustomers();
                        ViewBag.Customers = new SelectList(customers, "Id", "CustomerName");
                        var products = _productManager.GetProducts();
                        ViewBag.Products = new SelectList(products, "ProductId", "ProductName");
                        return View();
                    }
                }
                //Update Customer Loyalty Point End
                //ViewBag.Message = "Saved.";
                //var customers = _customerManager.GetCustomers();
                //ViewBag.Customers = new SelectList(customers, "Id", "CustomerName");
                //var products = _productManager.GetProducts();
                //ViewBag.Products = new SelectList(products, "ProductId", "ProductName");
                //return View();
            }
            return View();
        }
        public JsonResult ShowCustomerLoyaltyPoint(int customerId)
        {
            _customer.Id = customerId;
            var aCustomer = _customerManager.GetCustomerById(_customer);
            return Json(aCustomer, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowProductRecords(int productId)
        {
            _product.ProductId = productId;
            int availableQuantity = _salesManager.GetProductAvailableQuantity(_product);
            var aProduct = _purchaseManager.LatestProduct(_product);
            var productName = _productManager.GetProductById(_product);
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.ProductName = productName.ProductName;
            salesViewModel.ReorderLevel = productName.ReorderLevel;
            salesViewModel.AvailabelQuantity = availableQuantity;
            salesViewModel.UnitPrice = aProduct.PreviousMRP;
            return Json(salesViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}