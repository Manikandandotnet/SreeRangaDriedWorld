using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class Register
    {
        [Key]
        public int id {  get; set; }


        [Required]
        [Display(Name ="User ID")]
        public string UserID { get; set; }


        [Required]
        [Display(Name = "User Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "User Name Should be above 3 Characters!")]
        public string UserName {  get; set; }


        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }



        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber {  get; set; }



        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password {  get; set; }




        [Required]
        [Display(Name = "Conform Password")]
        [DataType(DataType.Password)]
        public string CPassword {  get; set; }



        [Required]
        [Display(Name = "Address")]

        public string Address {  get; set; }






    }
}