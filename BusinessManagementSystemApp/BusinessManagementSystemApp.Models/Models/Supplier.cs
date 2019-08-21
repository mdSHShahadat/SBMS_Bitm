using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required]
        public string SupplierName { get; set; }
        public string SupplierCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
        public string LogoPath { get; set; }
        public string IsActive { get; set; }
        public string Date { get; set; }
    }
}
