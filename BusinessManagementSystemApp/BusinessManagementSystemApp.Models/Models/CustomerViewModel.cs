using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Customer Name Required!")]
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Customer Email Address Required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Contact { get; set; }
        public int LoyaltyPoint { get; set; }
        public string ImagePath { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        public string SearchText { get; set; }
        public string ActionType { get; set; }
        public List<CustomerViewModel> Customers{ get; set; }
    }
}
