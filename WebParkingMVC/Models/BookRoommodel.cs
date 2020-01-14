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

        [Required]
        [Display(Name = "Start Date")]  
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime startDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime endDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}