using LibraryWebParking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebParking.Repository
{
    public class Data_Access
    {
        public List<spgetparkings_Result> AvailableParkings(DateTime startDate, DateTime endDate)
        {
            List<spgetparkings_Result> results = null;
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                results = db.spgetparkings(startDate, endDate).ToList();
            }
            return results;
        }
    }
}
