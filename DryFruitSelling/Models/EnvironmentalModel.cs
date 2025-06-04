using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class EnvironmentalModel
    {
        public int id {  get; set; }


        [Required]
        [Display(Name = "Sustainability PracticeID")]
       public string SustainabilityPracticeID { get; set; }



        [Required]
        [Display(Name = "PracticeDescription")]
        public string PracticeDescription { get; set; }


        [Required]
        [Display(Name = "Implementation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime ImplementationDate { get; set; }





        [Required]
        [Display(Name = "Impact")]

        public string Impact {  get; set; }














    }
}