﻿using LibraryWebParking.Model;
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


        public List<spgetparkings_Result> AvailableParkings(DateTime startDate, DateTime endDate)
        {
            List<spgetparkings_Result> results = null;

            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                results = db.spgetparkings(startDate, endDate).ToList();
                return results;
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
