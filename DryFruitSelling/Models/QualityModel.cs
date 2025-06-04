using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class QualityModel
    {
        public int id {  get; set; }

        [Required]
        [Display(Name ="QualityChecking ID")]
        public string QualityCheckID { get; set; }



        [Required]
        [Display(Name = "Producrion ID")]
        public string ProductionID { get; set; }




        [Required]
        [Display(Name = "Inspection Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InspectionDate { get; set; }



        [Required]
        [Display(Name = "Inspector Name")]
        public string InspectorName { get; set; }




        [Required]
        [Display(Name = "Inspection OutCome")]
        public string InspectionOutcome {  get; set; }





        [Required]
        [Display(Name = "Comments")]
        public string Comments { get; set; }







    }
}