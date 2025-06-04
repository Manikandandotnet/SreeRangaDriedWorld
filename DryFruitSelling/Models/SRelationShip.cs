using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class SRelationShip
    {
        [Key]
        public int id {  get; set; }



        [Required]
        [Display(Name = "SupplierEngagement ID")]
        public string SupplierEngagementID { get; set; }




        [Required]
        [Display(Name = "Supplier ID")]
        public string SupplierID {  get; set; }


        [Required]
        [Display(Name = "Engagement Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]

        public DateTime EngagementDate {  get; set; }




        [Required]
        [Display(Name = "Engagement Type")]


        public string EngagementType {  get; set; }


        [Required]
        [Display(Name = "Notes")]
        public string Notes { get; set; }






    }
}