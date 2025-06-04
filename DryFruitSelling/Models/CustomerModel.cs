using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class CustomerModel
    {
        public int id {  get; set; }

        [Required]
        [Display(Name ="Customer ID")]
        public string CustomerID { get; set; }


        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }


        [Required]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }



        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }



        [Required]
        [Display(Name = "Customer Address")]
        public string Address { get; set; }

    }
}