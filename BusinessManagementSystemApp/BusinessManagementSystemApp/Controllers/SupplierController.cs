using BusinessManagementSystemApp.BLL.BLL;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class SupplierController : Controller
    {
        public string fileName = "";
        Supplier supplier = new Supplier();
        SupplierManager _supplierManager = new SupplierManager();

        public ActionResult Index()
        {
            List<SupplierViewModel> suppliers = _supplierManager.GetSuppliers().Select(c => new SupplierViewModel { SupplierId = c.SupplierId, SupplierName = c.SupplierName, SupplierCode = c.SupplierCode, Address = c.Address, Email = c.Email, Contact = c.Contact, ContactPerson = c.ContactPerson, LogoPath = c.LogoPath, IsActive = c.IsActive, Date = c.Date }).ToList();
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = suppliers;
            return View(supplierViewModel);
        }
        [HttpPost]
        public ActionResult Index(SupplierViewModel supplierViewModel)
        {
            if (supplierViewModel.SearchText != string.Empty && supplierViewModel.SearchText != null)
            {
                List<SupplierViewModel> suppliers = _supplierManager.SearchSupplier(supplierViewModel).Select(c => new SupplierViewModel { SupplierId = c.SupplierId, SupplierName = c.SupplierName, SupplierCode = c.SupplierCode, Address = c.Address, Email = c.Email, Contact = c.Contact, ContactPerson = c.ContactPerson, LogoPath = c.LogoPath, IsActive = c.IsActive, Date = c.Date }).ToList();
                SupplierViewModel aSupplierViewModel = new SupplierViewModel();
                aSupplierViewModel.Suppliers = suppliers;
                return View(aSupplierViewModel);
            }
            else
            {
                List<SupplierViewModel> suppliers = _supplierManager.GetSuppliers().Select(c => new SupplierViewModel { SupplierId = c.SupplierId, SupplierName = c.SupplierName, SupplierCode = c.SupplierCode, Address = c.Address, Email = c.Email, Contact = c.Contact, ContactPerson = c.ContactPerson, LogoPath = c.LogoPath, IsActive = c.IsActive, Date = c.Date }).ToList();
                SupplierViewModel supplierViewModel1 = new SupplierViewModel();
                supplierViewModel1.Suppliers = suppliers;
                return View(supplierViewModel1);
            }
        }
        public ActionResult SaveSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveSupplier(SupplierViewModel supplierViewModel, HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                if (logo != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(logo.FileName);
                    string extension = Path.GetExtension(logo.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    supplierViewModel.LogoPath = "~/Resourses/" + fileName;
                }
                supplierViewModel.ActionType = "Insert";
                if (_supplierManager.IsExistSupplier(supplierViewModel) == false)
                {
                    supplier.SupplierId = supplierViewModel.SupplierId;
                    supplier.SupplierName = supplierViewModel.SupplierName;
                    supplier.SupplierCode = supplierViewModel.SupplierCode;
                    supplier.Address = supplierViewModel.Address;
                    supplier.Email = supplierViewModel.Email;
                    supplier.Contact = supplierViewModel.Contact;
                    supplier.ContactPerson = supplierViewModel.ContactPerson;
                    supplier.LogoPath = supplierViewModel.LogoPath;
                    supplier.IsActive = supplierViewModel.IsActive;
                    supplier.Date = supplierViewModel.Date;
                    if (_supplierManager.SaveSupplier(supplier))
                    {
                        fileName = Path.Combine(Server.MapPath("~/Resourses/"), fileName);
                        logo.SaveAs(fileName);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Operation Failed!";
                    }
                }
                else
                {
                    ViewBag.Message = "This supplier is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input validation error!";
            }
            return View(supplierViewModel);
        }
        public ActionResult UpdateSupplier(int id)
        {
            if (id > 0)
            {
                supplier.SupplierId = id;
                var aSupplier = _supplierManager.GetSupplierById(supplier);
                SupplierViewModel supplierViewModel = new SupplierViewModel();
                supplierViewModel.SupplierId = aSupplier.SupplierId;
                supplierViewModel.SupplierName = aSupplier.SupplierName;
                supplierViewModel.SupplierCode = aSupplier.SupplierCode;
                supplierViewModel.Address = aSupplier.Address;
                supplierViewModel.Email = aSupplier.Email;
                supplierViewModel.Contact = aSupplier.Contact;
                supplierViewModel.ContactPerson = aSupplier.ContactPerson;
                supplierViewModel.LogoPath = aSupplier.LogoPath;
                supplierViewModel.IsActive = aSupplier.IsActive;
                supplierViewModel.Date = aSupplier.Date;
                return View(supplierViewModel);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult UpdateSupplier(SupplierViewModel supplierViewModel,HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (logo != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(logo.FileName);
                    string extension = Path.GetExtension(logo.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    supplierViewModel.LogoPath = "~/Resourses/" + fileName;
                }
                supplierViewModel.ActionType = "Update";
                if (_supplierManager.IsExistSupplier(supplierViewModel) == false)
                {
                    supplier.SupplierId = supplierViewModel.SupplierId;
                    supplier = _supplierManager.GetSupplierById(supplier);
                    if (supplier != null)
                    {
                        supplier.SupplierId = supplierViewModel.SupplierId;
                        supplier.SupplierName = supplierViewModel.SupplierName;
                        supplier.SupplierCode = supplierViewModel.SupplierCode;
                        supplier.Address = supplierViewModel.Address;
                        supplier.Email = supplierViewModel.Email;
                        supplier.Contact = supplierViewModel.Contact;
                        supplier.ContactPerson = supplierViewModel.ContactPerson;
                        supplier.LogoPath = supplierViewModel.LogoPath;
                        supplier.IsActive = supplierViewModel.IsActive;
                        supplier.Date = supplierViewModel.Date;
                        if (_supplierManager.UpdateSupplier(supplier))
                        {
                            fileName = Path.Combine(Server.MapPath("~/Resourses/"), fileName);
                            logo.SaveAs(fileName);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Message = "Operation Failed!";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Supplier Not Found!";
                    }
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Error!";
            }
            return View(supplierViewModel);
        }
        public ActionResult SupplierDetails(int id)
        {
            if (id > 0)
            {
                supplier.SupplierId = id;
                var aSupplier = _supplierManager.GetSupplierById(supplier);
                if (aSupplier != null)
                {
                    SupplierViewModel supplierViewModel = new SupplierViewModel();
                    supplierViewModel.SupplierId = aSupplier.SupplierId;
                    supplierViewModel.SupplierName = aSupplier.SupplierName;
                    supplierViewModel.SupplierCode = aSupplier.SupplierCode;
                    supplierViewModel.Address = aSupplier.Address;
                    supplierViewModel.Email = aSupplier.Email;
                    supplierViewModel.Contact = aSupplier.Contact;
                    supplierViewModel.ContactPerson = aSupplier.ContactPerson;
                    supplierViewModel.LogoPath = aSupplier.LogoPath;
                    supplierViewModel.IsActive = aSupplier.IsActive;
                    supplierViewModel.Date = aSupplier.Date;
                    return View(supplierViewModel);
                }
                else
                {
                    ViewBag.Message = "Supplier Not Found!";
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }
        public ActionResult DeleteSupplier(int id)
        {
            if (id > 0)
            {
                supplier.SupplierId = id;
                var aSupplier = _supplierManager.GetSupplierById(supplier);
                if (aSupplier != null)
                {
                    SupplierViewModel supplierViewModel = new SupplierViewModel();
                    supplierViewModel.SupplierId = aSupplier.SupplierId;
                    supplierViewModel.SupplierName = aSupplier.SupplierName;
                    supplierViewModel.SupplierCode = aSupplier.SupplierCode;
                    supplierViewModel.Address = aSupplier.Address;
                    supplierViewModel.Email = aSupplier.Email;
                    supplierViewModel.Contact = aSupplier.Contact;
                    supplierViewModel.ContactPerson = aSupplier.ContactPerson;
                    supplierViewModel.LogoPath = aSupplier.LogoPath;
                    supplierViewModel.IsActive = aSupplier.IsActive;
                    supplierViewModel.Date = aSupplier.Date;
                    return View(supplierViewModel);
                }
                else
                {
                    ViewBag.Message = "Supplier Not Found!";
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSupplier(SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                if (supplierViewModel.SupplierId > 0)
                {
                    supplier.SupplierId = supplierViewModel.SupplierId;
                    supplier = _supplierManager.GetSupplierById(supplier);
                    if (supplier != null)
                    {
                        supplier.IsActive = supplierViewModel.IsActive;
                        supplier.Date= supplierViewModel.Date;
                        if (_supplierManager.DeleteSupplier(supplier))
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Message = "Operation Failed!";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Supplier Not Found!";
                    }
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ViewBag.Message = "Operation Failed!";
            }
            return View(supplierViewModel);
        }
    }
}