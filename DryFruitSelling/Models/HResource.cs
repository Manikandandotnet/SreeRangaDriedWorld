using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class HResource
    {
        [Key]
        public int id {  get; set; }

        [Required]
        [Display(Name ="Employee ID")]
        public string EmployeeID {  get; set; }



        [Required]
        [Display(Name = "Employee Name")]
        public string EmployeeName {  get; set; }




        [Required]
        [Display(Name = "Position")]
        public string Position {  get; set; }




        [Required]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime HireDate { get; set; }



        [Required]
        [Display(Name = "Salary")]
        public Decimal Salary {  get; set; }


        [Required]
        [Display(Name = "Performance Rating")]
        public string PerformanceRating {  get; set; }


        [Required]
        [Display(Name = "Attendance")]
        public string Attendance {  get; set; }





    }
}