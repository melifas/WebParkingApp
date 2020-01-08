using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebParkingMVC.Models
{
    public class FullBookRoomModel
    {
        public int Id { get; set; }
        public int ParkingId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}    
        public bool CheckedIn { get; set; }
        public decimal TotalPrice { get; set; }
        public int MyProperty { get; set; }
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