using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DryFruitSelling.Models
{
    public class LogisticsModel
    {
        public int id {  get; set; }


        [Required]
        [Display(Name = "Shipment ID")]
        public string ShipmentID {  get; set; }




        [Required]
        [Display(Name = "Fruit Type")]
        public string FruitType { get; set; }




        [Required]
        [Display(Name = "Quantity")]
        public int Quantity {  get; set; }




        [Required]
        [Display(Name = "Destination")]
        public string Destination { get; set; }



        [Required]
        [Display(Name = "ShipmentDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]

        public DateTime ShipmentDate {  get; set; }




        [Required]
        [Display(Name = "Delivery Status")]
        public string DeliveryStatus { get; set; }



    }
}