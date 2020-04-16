using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Model
{
    [MetadataType(typeof(BookingsNotBooked))]
    public partial class spBookingsNotBooked_Result
    {
        internal class BookingsNotBooked
        {
            public int Id { get; set; }

            public Nullable<int> ClientId { get; set; }
            public Nullable<int> ParkingId { get; set; }

            [DisplayName("Έναρξη κράτησης")]
            public Nullable<System.DateTime> StartDate { get; set; }

            [DisplayName("Τέλος κράτησης")]
            public Nullable<System.DateTime> EndDate { get; set; }

            [DisplayName("Συνολικό ποσό πληρωμής")]
            public Nullable<decimal> TotalPrice { get; set; }

            [DisplayName("Είναι πληρωμένη?")]
            public bool CheckedIn { get; set; }

            [DisplayName("Όνομα Πελάτη")]
            public string FirstName { get; set; }

            [DisplayName("Επώνυμο Πελάτη")]
            public string LatName { get; set; }

            [DisplayName("Τηλέφωνο")]
            public Nullable<int> Phone { get; set; }
            public string Email { get; set; }

            [DisplayName("Θέση")]
            public string ParkingNumber { get; set; }
        }


    }
}
