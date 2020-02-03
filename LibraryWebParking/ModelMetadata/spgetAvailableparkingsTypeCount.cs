using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.ModelMetadata
{
    [MetadataType(typeof(spgetAvailableparkingsTypeCount_metadata))]
    public partial class spgetAvailableparkingsTypeCount
    {
        internal class spgetAvailableparkingsTypeCount_metadata
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Desription { get; set; }
            public decimal Price { get; set; }
            [DisplayName("Free Postitions")]
            public Nullable<int> remainingPositions { get; set; }
        }

    }
}
