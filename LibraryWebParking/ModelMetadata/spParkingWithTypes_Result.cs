using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Model
{
    [MetadataType(typeof(spgetAvailableparkingsTypeCount_metadata))]
    public partial class spParkingWithTypes_Result
    {
        internal class spgetAvailableparkingsTypeCount_metadata
        {
            [Display(Name ="Αριθμός Θέσης")]
            public string ParkingNumber { get; set; }
            [Display(Name ="Τύπος Οχήματος")]
            public string Title { get; set; }
            public int Id { get; set; }
            public int ParkingTypeId { get; set; }
            public string Desription { get; set; }
            public decimal Price { get; set; }

        }
    }
}
