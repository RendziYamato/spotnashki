using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~ Class for creating new game field ~~~~~~~~~~~~~~~~~~~
    class clCreator
    {
        public void create_field(int[,] array) //Method wich will fill our array by random numbers when program is just launched
        {
            //array = new int[,] { { 1, 2, 3, 7 }, { 12, 8, 0, 4 }, { 9, 5, 15, 6 }, { 13, 11, 14, 10 } };


            //do//Cicle for build field wich have solution
            //{
            //    //Fill our array by digits which willn't confilct with field constructor
            //    for (int i = 0; i < (int)MaxArraySize.x; i++)
            //        for (int j = 0; j < (int)MaxArraySize.y; j++)
            //            array[i, j] = 99;

            //    Random rand = new Random((int)DateTime.Now.Ticks);// Generator of random digits

            //    //Begin array filling
            //    for (int i1 = 0; i1 < (int)MaxArraySize.x; i1++)
            //        for (int j1 = 0; j1 < (int)MaxArraySize.y; j1++)
            //        {
            //            array[i1, j1] = rand.Next(0, 16); //Generates new random digits

            //            for (int i2 = 0; i2 <= i1; i2++) //Check for equal digits in array
            //            {
            //                for (int j2 = 0; j2 < (int)MaxArraySize.y; j2++)
            //                {
            //                    if (i2 == i1 && j2 == j1)//Is this current element?
            //                        break;
            //                    if (array[i2, j2] == array[i1, j1])//Check
            //                    {
            //                        if (j1 == 0)//Is this first digit in string?
            //                        {   //Move our generator back on one step to generate new last random digit
            //                            i1--;
            //                            j1 = 3;
            //                            break;
            //                        }
            //                        else
            //                        {   //Move our generator back on one step to generate new last random digit
            //                            j1--;
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //} while (have_solution(array));//Check for having solution
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        bool have_solution(int[,] field)//Method wich return false if field have solution, to exit from cicle, and true if field havn't got solution
        {
            int inversion = 0;
            int[] loc_field = new int[16];

            for (int i = 0, time = 0; i < (int)MaxArraySize.x; i++)
                for (int j = 0; j < (int)MaxArraySize.y; j++)
                {
                    loc_field[time] = field[i, j];
                    time++;
                }

            for (int i = 0; i < (int)MaxArraySize.x * (int)MaxArraySize.y; i++)
                        for (int j = 0; j < i; j++)
                            if (loc_field[j] > loc_field[i])
                                inversion++;

            for (int i = 0; i < (int)MaxArraySize.x * (int)MaxArraySize.y; i++)
                if (loc_field[i] == 0)
                    inversion += 1 + i/4;

            if (inversion % 2 == 0)
                return false;
            else
                return true;
        }
        
    }

    
}
