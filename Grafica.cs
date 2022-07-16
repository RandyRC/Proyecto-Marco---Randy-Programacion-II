using System.Collections.Generic;

namespace Domino
{
    public class Grafica
    {
        public string Left {get; set; }
        public string Right {get; set; }
        public (int, int) Coordinates {get; set; }

        public Grafica(string left, string right, (int, int) coordinates)
        {
            Left = left;
            Right = right;
            Coordinates = coordinates;
        }
    }
}