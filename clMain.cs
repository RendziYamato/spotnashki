using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~~~~ This is main class, wich contain the most important information about game process ~~~~~~~~~~~~~~~~

    public class clMain
    {
        public int[,] field;//Game field array

        int steps; //Number of steps to win

        public string win;//String wich contain game status

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public clMain()//Constructor
        {
            field = new int[(int)MaxArraySize.x, (int)MaxArraySize.y] { { 1, 2, 3, 7 }, { 12, 8, 0, 4 }, { 9, 5, 15, 6 }, { 13, 11, 14, 10 } };
            steps = 0;
            win = "In process...";
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public string win_check(int[,] result)
        {
            bool flag = false;

            for (int i = 0; i < (int)MaxArraySize.x && flag == false; i++)
                for (int j = 0; j < (int)MaxArraySize.y && flag == false; j++)
                {
                    if (field[i, j] == result[i, j])
                        continue;
                    else
                    {
                        flag = true;
                        win = "Victory!";
                    }
                }
            return win;
        }
    }
}
