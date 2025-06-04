using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class Supplier
    {

        public int id {  get; set; }

        [Required]
        [Display(Name ="Supplier ID")]
        public string SupplierID { get; set; }

        [Required]
        [Display(Name = "Suplier Nmae")]
        public string SupplierName {  get; set; }


        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }



        [Required]
        [Display(Name = "Order History")]
        public string OrderHistory { get; set; }




    }
}