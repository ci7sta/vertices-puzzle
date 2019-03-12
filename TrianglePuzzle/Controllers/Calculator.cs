using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrianglePuzzle.Controllers
{
    public class Calculator
    {

        public Calculator() {
        }
        public string performTaskA(dynamic value)
        {

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

            List<Tuple<int, int>> coordList = getCoords(rowNumber, columnNumber);
            string coords = "";


            for (int i = 0; i < coordList.Count; i++)
            {
                coords += coordList[i].ToString();
            }


            return coords;

        }

   

        public List<Tuple<int, int>> getCoords(int rowNumber, int columnNumber)
        {

            int x1, x2, x3, y1, y2, y3;

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            // Mathematically calculate position of vertices based on row and column number
            
            // NOTE: The instances of "10" here would be better suited as a variable so that the dimensions of the
            // triangles could be changed
            if (columnNumber % 2 == 0)
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

            if (columnNumber % 2 == 0)
            {
                x1 = (columnNumber * 10) / 2;
                x2 = x1 - 10;
                x3 = x1;
            }
            else
            {
                x1 = ((columnNumber - 1) / 2) * 10;
                x2 = x1 + 10;
                x3 = x1;
            }

            // Create coordinates and add them to the list

            list.Add(Tuple.Create(x1, y1));
            list.Add(Tuple.Create(x2, y2));
            list.Add(Tuple.Create(x3, y3));
            return list;
        }

        public string performTaskB(dynamic value)
        {

            // Define grid size so that we can change the size of the grid if we like
            int rows = 6;
            int columns = 12;

            int[] vertexCoords = new int[6];
          

            // Parse coordinates from JSON

            Int32.TryParse((string) value.v1x, out vertexCoords[0]);
            Int32.TryParse((string) value.v2x, out vertexCoords[1]);
            Int32.TryParse((string) value.v3x, out vertexCoords[2]);
            Int32.TryParse((string) value.v1y, out vertexCoords[3]);
            Int32.TryParse((string) value.v2y, out vertexCoords[4]);
            Int32.TryParse((string) value.v3y, out vertexCoords[5]);

            Tuple<int, int> v1, v2, v3;

            v1 = Tuple.Create(vertexCoords[0], vertexCoords[3]);
            v2 = Tuple.Create(vertexCoords[1], vertexCoords[4]);
            v3 = Tuple.Create(vertexCoords[2], vertexCoords[5]);

            // Iterate over the grid to find a match for a given triangle lable given the 3 sets of vertex coordinates

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    List<Tuple<int, int>> coordsList = getCoords(i, j);

                    if (coordsList.Contains(v1) && coordsList.Contains(v2) && coordsList.Contains(v3))
                    {
                        return ((char)(i + 64) + "" + j);
                    }
                }
            }

            return "not found";

        }
    }
}
