using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Model
{
    [MetadataType(typeof(Clients_metadata))]
    public partial class Clients
    {
        internal class Clients_metadata
        {
            
            public int Id { get; set; }
            [DisplayName("Όνομα")]
            public string FirstName { get; set; }
            [DisplayName("Επίθετο")]
            public string LatName { get; set; }
            [DisplayName("Τηλέφωνο")]
            public Nullable<int> Phone { get; set; }
            public string Email { get; set; }
            [DisplayName("Foto Πελάτη")]
            public string ImagePath { get; set; }

        }
    }
}
