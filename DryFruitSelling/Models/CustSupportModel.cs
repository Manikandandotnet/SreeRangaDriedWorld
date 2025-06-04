using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class CustSupportModel
    {
        [Key]
        public int id {  get; set; }


        [Required]
        [Display(Name = "Support Ticket ID")]

        public string SupportTicketID { get; set; }


        [Required]
        [Display(Name = "Customer ID")]
     
        public string CustomerID {  get; set; }




        [Required]
        [Display(Name = "Issue Description")]
     
        public string IssueDescription { get; set; }



        [Required]
        [Display(Name = "Resolution Status")]
       

        public string ResolutionStatus {  get; set; }

        [Required]
        [Display(Name ="Resolution Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime ResolutionDate {  get; set; }





    }
}