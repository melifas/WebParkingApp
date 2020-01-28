using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParkingMVC.Models
{
    public class BookRoomModel
    {
        public int ParkingId { get; set; }

        public int ParkingtypeId { get; set; }

        [Required]
        [Display(Name = "Start Date")]  
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime startDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime endDate { get; set; }

        [Required(ErrorMessage ="Please give Your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please give Your Last Name ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please give Your Last Name ")]
        [Display(Name = "Contact Phone")]
        
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Please give Your Email ")]
        [Display(Name = "Enail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        
    }
}