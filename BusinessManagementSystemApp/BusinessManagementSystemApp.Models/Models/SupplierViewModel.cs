using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }
        [Required(ErrorMessage ="Please enter supplier name")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Please enter supplier code")]
        public string SupplierCode { get; set; }
        [Required(ErrorMessage = "Please enter supplier address")]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter supplier contact number")]
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
        public string LogoPath { get; set; }
        public string IsActive { get; set; }
        public string Date { get; set; }
        public string ActionType { get; set; }
        public string SearchText { get; set; }
        public List<SupplierViewModel> Suppliers { get; set; }
        //public List<PurchaseSummary> PurchaseSummaries { get; set; }
    }
}
