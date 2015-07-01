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

        public char[,] open_close;

        int steps; //Number of steps to win

        public string win;//String wich contain game status

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public clMain()//Constructor
        {
            field = new int[4, 4];
            steps = 0;
            win = "In process...";

            open_close = new char[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    open_close[i, j] = ' ';
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

            for(int i = 0; i < 4 && flag == false; i++)
                for (int j = 0; j < 4 && flag == false; j++)
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
