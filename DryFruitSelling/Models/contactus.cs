using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class contactus
    {


       public int id {  get; set; }


        [Required]
        [Display(Name=" customer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }

        [Required]
        [Display(Name="phone Number")]
        [DataType(DataType.PhoneNumber)]        
        public string Phone {  get; set; }



        [Required]
        [Display(Name="Message")]
        [DataType(DataType.MultilineText)]
       public string Message { get; set; }












    }
}