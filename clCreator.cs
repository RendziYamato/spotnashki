using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~ Class for creating new game field ~~~~~~~~~~~~~~~~~~~
    class clCreator
    {            
        public void create_field(int[,] array) //Method wich will fill our array by random numbers
        {
            //for (int i = 0; i < 16; i++) // Clear all field
            //    array[i] = 99;//Number, which will not break our game, also each numbers from (-infinity;0)U(15;+infinity)

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    array[i, j] = 99;

            Random rand = new Random((int)DateTime.Now.Ticks);// Generator of random numbers

            for(int i1 = 0; i1 < 4; i1++)
                for (int j1 = 0; j1 < 4; j1++)
                {
                    array[i1, j1] = rand.Next(0, 16);

                    for (int i2 = 0; i2 <= i1; i2++)
                    {
                        for (int j2 = 0; j2 < 4 && i2+j2 < i1+j1; j2++)
                        {
                            if (array[i2, j2] == array[i1, j1])
                            {
                                if (j1 == 0)
                                {
                                    i1--;
                                    j1 = 3;
                                }
                                else
                                    j1--;
                            }
                        }
                    }
                }
                       
            
            //for (int i = 0; i < 16; i++)
            //{
            //    array[i] = rand.Next(0, 16);

            //    for (int j = 0; j < i; j++)//Check for exists nubers
            //    {
            //        if (array[j] == array[i])
            //        {
            //            i--;
            //            break;
            //        }
            //    }
            //}

            //return array;//Return ready matrix with game field to clController
        }
    }
}
