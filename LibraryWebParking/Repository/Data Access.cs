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

        public List<Parkings> getParkings() 
        {      
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                var parkings= db.Parkings.ToList();
                return parkings;
            }
        }

        public List<ParkingTypes> getParkingsType()
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                List<ParkingTypes> parkingsType = db.ParkingTypes.ToList();
                return parkingsType;
            }
        }


       /* public List<spgetparkings_Result> AvailableParkings(DateTime startDate, DateTime endDate)
        {
            List<spgetparkings_Result> results = null;

            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                results = db.spgetAvailableparkingsType(startDate, endDate).ToList();
                return results;
            }
        }*/

        public List<ParkingTypes> AvailableParkings(DateTime startDate, DateTime endDate)
        {
            List<ParkingTypes> results = null;

            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                results = db.spgetAvailableparkingsType(startDate, endDate).ToList();
                return results;
            }
        }


        public List<FullBookRoomModel> SearchBookings(string lastName)
        {
            List<FullBookRoomModel> bookSearchResults = null;
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                bookSearchResults = db.spBookingsSearch(lastName).ToList();
                return bookSearchResults;
            }

        }


        public void CheckInClient( int bookingId) 
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {

                db.spBookingsCheckIn(bookingId);
                db.SaveChanges();
            }
            
        }


        public void BookClient(string firstName,string lastName, string ImagePath,string email,string Phone ,DateTime startDate, DateTime endDate,int ParkingTypeId) 
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {

                ParkingTypes parkingtype =  db.ParkingTypes.Where(x => x.Id == ParkingTypeId).FirstOrDefault();

                spInsertClient_Result client = db.spInsertClient(firstName, lastName, ImagePath,email,Phone).FirstOrDefault();

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

        public Bookings BookingDetails(string firstName, string lastName, string ImagePath, string email, string Phone, DateTime startDate, DateTime endDate, int ParkingTypeId)
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {

                ParkingTypes parkingtype = db.ParkingTypes.Where(x => x.Id == ParkingTypeId).FirstOrDefault();

                spInsertClient_Result client = db.spInsertClient(firstName, lastName, ImagePath, email, Phone).FirstOrDefault();

                TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

                List<spGetAvailableParkingPositions_Result> availableParkingPositions = db.spGetAvailableParkingPositions(startDate, endDate, ParkingTypeId).ToList();

                Bookings booking = new Bookings()
                {
                    ClientId = client.Id,
                    ParkingId = availableParkingPositions.First().Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalPrice = timeStaying.Days * parkingtype.Price
                };
                return booking;
            }

        }

        public Clients ClientDetails(int id) 
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                return db.Clients.Where(x => x.Id == id).FirstOrDefault();               
            }
        }
    }
}
