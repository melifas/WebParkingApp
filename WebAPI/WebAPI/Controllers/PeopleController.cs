using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PeopleController : ApiController
    {

        List<Person> persons = new List<Person>();

        public PeopleController()
        {
            persons.Add(new Person { FirstName = "meletis", LastName = "Fasoulis", Id=1 });
            persons.Add(new Person { FirstName = "george", LastName = "cap", Id=2 });
            persons.Add(new Person { FirstName = "stacy", LastName = "poutou", Id=3 });
        }
        // GET: api/People
        public List<Person> Get()
        {
            return persons;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return persons.Where(x=>x.Id==id).FirstOrDefault();
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
