using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class DRearchModel
    {
        public int id {  get; set; }



        [Required]
        [Display(Name = "ResearchDevelopment ID")]
        public string RnDProjectID { get; set; }



        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName {  get; set; }
        [Required]
        [Display(Name ="Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
      public DateTime StartDate {  get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime EndDate { get; set; }


        [Required]
        [Display(Name = "Priject Status")]

        public String ProjectStatus {  get; set; }



        [Required]
        [Display(Name = "Notes")]
        public string Notes {  get; set; }




    }
}