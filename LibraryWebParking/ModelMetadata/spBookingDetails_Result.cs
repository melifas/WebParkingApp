using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Model
{
    [MetadataType(typeof(Booking_metadata))]
    public partial class spBookingDetails_Result
    {
        internal class Booking_metadata
        {
            [DisplayName("Έναρξη κράτησης")]
            public Nullable<System.DateTime> StartDate { get; set; }
            [DisplayName("Τέλος κράτησης")]
            public Nullable<System.DateTime> EndDate { get; set; }
            [DisplayName("Επώνυμο Πελάτη")]
            public string LatName { get; set; }
            [DisplayName("Όνομα Πελάτη")]
            public string FirstName { get; set; }
            [DisplayName("Τηλέφωνο Πελάτη")]
            public Nullable<int> Phone { get; set; }
            [DisplayName("Ενοικιαζόμενη Θέση")]
            public string ParkingNumber { get; set; }
            public int Id { get; set; }
            public Nullable<int> ClientId { get; set; }
            public Nullable<int> ParkingId { get; set; }
            public Nullable<decimal> TotalPrice { get; set; }
            public Nullable<bool> CheckedIn { get; set; }
            public string Email { get; set; }
        }
    }
}
