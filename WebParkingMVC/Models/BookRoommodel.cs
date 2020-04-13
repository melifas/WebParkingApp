using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParkingMVC.Models
{
    public class BookRoomModel
    {
        public int Id{ get; set; }
        [Display(Name = "Επιλογή Θέσης")]
        public int ParkingId { get; set; }

        public int ParkingtypeId { get; set; }

        [Required]
        [Display(Name = "Απο")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime startDate { get; set; }

        [Required]
        [Display(Name = "Εως")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime endDate { get; set; }

        [Required]
        [Display(Name = "Όνομα")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Επίθετο")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Τηλέφωνο")]
        public string Phone { get; set; }

        [Display(Name = "Διεύθυνση mail")]
        [Required(ErrorMessage = "H διεύθυνση mail είναι υποχρεωτική")]
        [EmailAddress(ErrorMessage = "Μη έγκυρη μορφή διεύθυνσης email")]
        public string Email { get; set; }

        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public bool isChecked { get; set; }
    }
}