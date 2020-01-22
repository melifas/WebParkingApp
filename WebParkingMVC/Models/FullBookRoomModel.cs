using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParkingMVC.Models
{
    public class FullBookRoomModel
    {
        [Display(Name ="Position")]
        public int ParkingId { get; set; }
        [Display(Name = "Client Last Name")]
        public int ClientId { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date Date")]
        public DateTime EndDate { get; set;}    
        public bool CheckedIn { get; set; }
        [Display(Name = "Total Cost")]
        public decimal TotalPrice { get; set; }
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }      
        public int ParkingNumber { get; set; }
        public int ParkingTypeId { get; set; }
        public string Title { get; set; }
        public string Desription { get; set; }
        public decimal Price { get; set; }


    }
}