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
        public IEnumerable<spAvailableParkingsToday_Result> Get()
        {
            using (WebParkingDBContex db =new WebParkingDBContex() )
            {
                return db.spAvailableParkingsToday().ToList();
            }            
        }

        // GET: api/BookingApi/5
        public string Get(int id)
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
