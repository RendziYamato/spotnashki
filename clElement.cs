using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~ This class will contain information about elements of field - "Пятнашках" ~~~~~~~~~~~~~~~
    public class clElement
    {
        string name;

        int positionX;
        int positionY;

        public clElement(string new_name, int x, int y) //Constructor
        {
            Name = new_name;
            PositionX = x;
            PositionY = y;
        }

        public string Name
        {
           get { return name; }
           set { name = value; }
        }

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }

        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
    }
}
