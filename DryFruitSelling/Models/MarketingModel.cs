using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class MarketingModel
    {
        [Key]
        public int id {  get; set; }

        [Required]
        [Display(Name = "Campaign  ID")]

        public string CampaignID { get; set; }

        [Required]
        [Display(Name = "Campaign Name")]

        public string CampaignName { get; set; }


        [Required]
        [Display(Name = "Start Date")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }



        [Required]
        [Display(Name = "Budget")]

        public string Budget { get; set; }



        [Required]
        [Display(Name = "OutCome")]

        public string Outcome { get; set; }





    }
}