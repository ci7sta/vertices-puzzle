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

            int x1, x2, x3, y1, y2, y3;
            char rowLetter = value.rowLetter;

            // Convert letter to position in alphabet to better work with row numbers
            int rowNumber = char.ToUpper(rowLetter) - 64;

            // Parse column number
            int columnNumber = 0;
            string columnNo = value.columnNo;
            Int32.TryParse(columnNo, out columnNumber);


            // Validate input
            if (columnNumber > 12 || columnNumber < 1)
            {
                return "Invalid column number (accepted range 1-12)";
            }
            else if (rowNumber > 6 || rowNumber < 1)
            {
                return "Invalid row letter (accepted range A-F)";
            }

            // Mathematically calculate position of vertices based on row and column number
            if(columnNumber % 2 == 0)
            {
                y1 = (rowNumber * 10) - 10;
                y2 = y1;
                y3 = y1 + 10;
            }
            else
            {
                y1 = (rowNumber * 10);
                y2 = y1;
                y3 = y1 - 10;
            }

            if(columnNumber % 2 == 0)
            {
                x1 = (columnNumber * 10) / 2;
                x2 = x1 - 10;
                x3 = x1;
            }
            else
            {
                x1 = ((columnNumber - 1)/2) * 10;
                x2 = x1 + 10;
                x3 = x1;
            }


            // Assemble result string

            string coords = "(" + x1 + "," + y1 + ")" +
                " (" + x2 + "," + y2 + ")" +
                " (" + x3 + "," + y3 + ")";


            return coords;
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
