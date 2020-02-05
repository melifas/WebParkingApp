using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Model
{
    [MetadataType(typeof(FullBookRoomModel_metadata))]
    public partial class FullBookRoomModel
    {
        internal class FullBookRoomModel_metadata
        {
            public int Id { get; set; }
            public Nullable<int> ClientId { get; set; }
            public Nullable<int> ParkingId { get; set; }
            [DisplayName("Απο")]
            public Nullable<System.DateTime> StartDate { get; set; }
            [DisplayName("Εώς")]
            public Nullable<System.DateTime> EndDate { get; set; }
            [DisplayName("Τιμή")]
            public Nullable<decimal> TotalPrice { get; set; }
            public Nullable<bool> CheckedIn { get; set; }
            [DisplayName("Επώνυμο")]
            public string FirstName { get; set; }
            [DisplayName("Όνομα")]
            public string LatName { get; set; }
            [DisplayName("Τηλέφωνο")]
            public int Phone { get; set; }
            public string Email { get; set; }
            [DisplayName("Θέση")]
            public string ParkingNumber { get; set; }           
            public int ParkingTypeId { get; set; }
            [DisplayName("Τύπος Οχήματος")]
            public string Title { get; set; }
            public string Desription { get; set; }
            public decimal Price { get; set; }
        }
    }
}
