using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Model
{
    [MetadataType(typeof(Parking_metadata))]
    public partial class Parkings
    {
        internal class Parking_metadata
        {
            public int Id { get; set; }
            [DisplayName("Θέση Parking")]
            public string ParkingNumber { get; set; }
            [DisplayName("Τύπος Parking")]
            public int ParkingTypeId { get; set; }

        }
    }
}
