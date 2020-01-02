using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParkingMVC.Models
{
    public class BookRoomModel
    {
        public int ParkingtypeId { get; set; }

        public DateTime startDate { get; set; }
       
        public DateTime endDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}