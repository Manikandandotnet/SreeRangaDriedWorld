using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class SalesModel
    {

        public int id {  get; set; }



        [Required]
        [Display(Name = "Sale ID")]
       public string SaleID { get; set; }


        [Required]
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }



        [Required]
        [Display(Name = "Fruit Type")]

        public string FruitType { get; set; }



        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }




        [Required]
        [Display(Name = "Sales Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        public DateTime SaleDate { get; set; }



        [Required]
        [Display(Name = "Revenue")]
        public Decimal Revenue {  get; set; }
  
    
    
    
    }
}