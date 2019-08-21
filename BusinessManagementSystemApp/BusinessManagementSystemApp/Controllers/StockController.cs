using BusinessManagementSystemApp.BLL.BLL;
using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class StockController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();
        StockManager _stockManager = new StockManager();
        Product _product = new Product();

        public ActionResult Index()
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(ProductViewModel productViewModel)
        {
            _product.ProductId = productViewModel.ProductId;
            _product = _productManager.GetProductById(_product);
            ProductViewModel model = _purchaseManager.LatestProduct(_product);
            int productAvailableQuantity = _salesManager.GetProductAvailableQuantity(_product);
            productViewModel.ProductId = _product.ProductId;
            productViewModel.ProductName = _product.ProductName;
            productViewModel.ProductCode = _product.ProductCode;
            productViewModel.CategoryName = _product.Category.CategoryName;
            productViewModel.ReorderLevel = _product.ReorderLevel;
            productViewModel.ExpireDate = model.ExpireDate;
            productViewModel.ExpiredQuantity = _stockManager.ExpiredProductQuantity(_product);
            


            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(productViewModel);

        }
        public JsonResult GetProductsByCategory(int categoryId)
        {
            List<Product> productList = new List<Product>();
            var products = _productManager.GetProducts().Where(c => c.CategoryId == categoryId).ToList();
            foreach (var product in products)
            {
                Product aProduct = new Product();
                aProduct.ProductId = product.ProductId;
                aProduct.ProductName = product.ProductName;
                aProduct.ProductCode = product.ProductCode;
                aProduct.ReorderLevel = product.ReorderLevel;
                productList.Add(aProduct);
            }

            return Json(productList, JsonRequestBehavior.AllowGet);
        }
    }
}