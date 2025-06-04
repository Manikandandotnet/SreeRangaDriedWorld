using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class ReportingModel
    {
        public int id {  get; set; }




        [Required]

        [Display(Name = "Report ID")]

        public string ReportID {  get; set; }



        [Required]

        [Display(Name = "Report Name")]
        public string ReportName { get; set; }


        [Required]

        [Display(Name = "Generated Date")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]

        public DateTime GeneratedDate { get; set; }


        [Required]

        [Display(Name = "Report Typ")]


        public string ReportType {  get; set; }





        [Required]

        [Display(Name = "Data Range")]

        public string DataRange { get; set; }




        [Required]

        [Display(Name = "GeneratedBy")]

        public string GeneratedBy {  get; set; }


        [Required]

        [Display(Name = "Notes")]

      public string Notes {  get; set; }








    }
}