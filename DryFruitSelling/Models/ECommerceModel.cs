using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class ECommerceModel
    {
        [Key]
        public int id { get; set; }


        [Required]
        [Display(Name = "Online Order ID")]
        public string OnlineOrderID { get; set; }


        [Required]
        [Display(Name = "Customer ID")]

        public string CustomerID { get; set; }



        [Required]
        [Display(Name = "Fruit Type")]

        public string FruitType {  get; set; }


        [Required]
        [Display(Name = "Quantity")]


        public int Quantity {  get; set; }


        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }



        [Required]
        [Display(Name ="Payment Status")]
     public string PaymentStatus { get; set; }








    }
}