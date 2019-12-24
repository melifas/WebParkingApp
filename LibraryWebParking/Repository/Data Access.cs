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
               return results = db.spgetparkings(startDate, endDate).ToList();
            }
        }

        public void BookClient(string firstName,string lastName, DateTime startDate, DateTime endDate,int ParkingTypeId) 
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {

                ParkingTypes parkingtype =  db.ParkingTypes.Where(x => x.Id == ParkingTypeId).FirstOrDefault();

                spInsertClient_Result client = db.spInsertClient(firstName, lastName).FirstOrDefault();

                TimeSpan timeStaying =  endDate.Date.Subtract(startDate.Date);

                List<spGetAvailableParkingPositions_Result> availableParkingPositions =  db.spGetAvailableParkingPositions(startDate, endDate, ParkingTypeId).ToList();

                Bookings booking = new Bookings()
                {
                    ClientId = client.Id,
                    ParkingId = availableParkingPositions.First().Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalPrice = timeStaying.Days * parkingtype.Price
                };
                db.Bookings.Add(booking);
                db.SaveChanges();
            }

        }

    }
}
