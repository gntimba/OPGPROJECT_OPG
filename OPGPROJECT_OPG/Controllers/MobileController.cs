using OPGPROJECT_OPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OPGPROJECT_OPG.Controllers
{
    public class MobileController : ApiController
    {
        private Context db = new Context();
        // GET api/<controller>
        public IEnumerable<Child> Get()
        {
            return db.Children.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}