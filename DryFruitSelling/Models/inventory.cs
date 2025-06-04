using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class inventory
    {
        
        public int id {  get; set; }

        [Required]
        [Display(Name ="Inventory ID")]
        public string InventoryID { get; set; }


        [Required]
        [Display(Name = "Fruit Type")]
        public string FruitType { get; set; }


        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        [Required]
        [Display(Name = "Preservation Status")]
        public string PreservationStatus {  get; set; }



        [Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime ExpirationDate {  get; set; }


    }
}