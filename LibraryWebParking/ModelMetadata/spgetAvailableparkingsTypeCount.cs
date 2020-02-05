using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Model
{

    [MetadataType(typeof(spgetAvailableparkingsTypeCount_metadata))]
    public partial class spgetAvailableparkingsTypeCount
    {
        internal class spgetAvailableparkingsTypeCount_metadata
        {
            public int Id { get; set; }
            [DisplayName("Τύπος Οχήματος")]
            public string Title { get; set; }
            [DisplayName("Περιγραφή")]
            public string Desription { get; set; }
            [DisplayName("Ημερήσια Τιμή")]
            public decimal Price { get; set; }
            [DisplayName("Διαθέσιμες Θέσεις")]
            public Nullable<int> remainingPositions { get; set; }
        }

    }
}