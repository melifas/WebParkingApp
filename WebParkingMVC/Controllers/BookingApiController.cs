using LibraryWebParking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebParkingMVC.Controllers
{
    public class BookingApiController : ApiController
    {
        // GET: api/BookingApi
        //[Route("api/bookings/{start:DateTime}/{end:DateTime}/{ParkingTypeId:int}")]
        //[HttpGet]
        /*public List<spGetAvailableParkingPositions_Result> Get(DateTime start, DateTime end, int ParkingTypeId)
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                return db.spGetAvailableParkingPositions(start, end, ParkingTypeId).ToList();
            }
        }*/

        // GET: api/BookingApi/5
        //[Route("api/book")]
        //[HttpGet]
        public string Get()
        {
            return "value";
        }

        // POST: api/BookingApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BookingApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BookingApi/5
        public void Delete(int id)
        {
        }
    }
}
