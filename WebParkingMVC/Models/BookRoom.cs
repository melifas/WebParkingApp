using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParkingMVC.Models
{
    public class BookRoom
    {
        public int BookRoomId { get; set; }
        [Display(Name ="Your First Name")]
        [Required(ErrorMessage ="You must give your FirstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}