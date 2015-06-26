using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~~~~ This is main class, wich contain the most important information about game process ~~~~~~~~~~~~~~~~

    public class clField
    {
        public int[,] field = new int[4,4];

        int steps = 0; //Number of steps to win

        public int Steps
        {
            get { return steps; }
            set { steps = value; }
        }
    }
}
