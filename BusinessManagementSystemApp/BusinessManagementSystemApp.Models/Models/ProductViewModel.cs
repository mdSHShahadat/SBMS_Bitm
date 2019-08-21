﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Products = new List<ProductViewModel>();    
        }
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Please insert product name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please insert product code")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Please insert product reorder level")]
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<Category> Categories { get; set; }
        public string SearchText { get; set; }
        public string ActionType { get; set; }
        public decimal PreviousCostPrice { get; set; }
        public decimal PreviousMRP { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ExpiredQuantity { get; set; }
        public bool CheckReorder { get; set; }
        public bool ExpireProduct { get; set; }
        public decimal TotalCostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Profit { get; set; }

    }
}
