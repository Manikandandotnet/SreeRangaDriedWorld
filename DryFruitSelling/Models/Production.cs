using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class Production
    {

        public int id {  get; set; }


        [Required]
        [Display(Name = "Production ID")]
        public string ProductionID { get; set; }



        [Required]
        [Display(Name = "Fruit Type")]
        public string FruitType {  get; set; }



        [Required]
        [Display(Name = "Processing Stage")]
        public string ProcessingStage { get; set; }



        [Required]
        [Display(Name = "Pakaging Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime PackagingDate { get; set; }





    }
}