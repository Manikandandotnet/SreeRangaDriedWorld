using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class Finance
    {
        public int id {  get; set; }


        [Required]
        [Display(Name ="Transaction ID")]
        public string TransactionID { get; set; }


        [Required]
        [Display(Name = "Transaction Type")]

        public string TransactionType {  get; set; }


        [Required]
        [Display(Name = "Amount")]

        public Decimal Amount {  get; set; }



        [Required]
        [Display(Name = "Today Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime TodayDate { get; set; }

    }
}