﻿using LibraryWebParking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public List<spBookingDetails_Result> getBookingDetails()
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                List<spBookingDetails_Result>results  = db.spBookingDetails().ToList();
                return results;
            }
        }

        public List<spParkingPositionsNotBooked_Result1> getPositionsNotBooked() 
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                List<spParkingPositionsNotBooked_Result1> result = db.spParkingPositionsNotBooked().ToList();
                return result;
            }
        }


        public List<spParkingWithTypes_Result> getParkingWithTypes()
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                var results = db.spParkingWithTypes().ToList();
                return results;
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

        public void AddParking(string ParkingNum,int ParkTypeId)
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                Parkings park = new Parkings()
                {
                    ParkingNumber = ParkingNum,
                    ParkingTypeId = ParkTypeId
                };
                db.Parkings.Add(park);
                db.SaveChanges();
            }
        }

        public Parkings FindParking(string PNumber)
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                Parkings parking = db.Parkings.Where(x => x.ParkingNumber == PNumber).FirstOrDefault();
                return parking;
            }
        }

        public List<spGetAvailableParkingPositions_Result> getAvailableParkingPositions(DateTime start , DateTime end , int ParkingTypeId)
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                List<spGetAvailableParkingPositions_Result> positionsempty =  db.spGetAvailableParkingPositions(start, end, ParkingTypeId).ToList();
                return positionsempty;
            }
        }





        public List<spgetAvailableparkingsTypeCount> AvailableParkings(DateTime startDate, DateTime endDate)
        {
            List<spgetAvailableparkingsTypeCount> parkingTypes = null;

            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                parkingTypes = db.spgetAvailableparkingsType(startDate, endDate).ToList();

                return parkingTypes;
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

        public void BookingFromAdmin(DateTime startDate, DateTime endDate, int ParkingId,int ClientId) 
        {

            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                //ParkingTypes parkingtype = db.ParkingTypes.Where(x => x.Id == ParkingTypeId).FirstOrDefault();
                TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);


                Bookings booking = new Bookings()
                {
                    ClientId = ClientId,
                    ParkingId = ParkingId,
                    StartDate = startDate,
                    EndDate = endDate,
                    //TotalPrice = timeStaying.Days * parkingtype.Price
                };
                db.Bookings.Add(booking);
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
       
        public Clients ClientDetails(int id) 
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                return db.Clients.Where(x => x.Id == id).FirstOrDefault();               
            }
        }

        public List<Clients> getListofCustomers() 
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                return db.Clients.ToList();
            }
        }
    }
}
