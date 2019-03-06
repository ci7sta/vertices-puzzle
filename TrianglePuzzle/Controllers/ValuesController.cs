using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrianglePuzzle.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

      
        // POST api/values
        public string Post([FromBody]dynamic value)
        {

            Calculator calculator = new Calculator();

            if(value.type == "A" || value.type == "a")
            {
                return calculator.performTaskA(value);
                    
            } else if (value.type == "B" || value.type == "b")
            {
                return calculator.performTaskB(value);
            } else
            {
                return "Unknown Task type. Please supply type field with either 'A' or 'B'";
            } 
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
