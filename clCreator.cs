using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~ Class for creating new game field ~~~~~~~~~~~~~~~~~~~
    class clCreator
    {            
        public int[] create_field(int[] array) //Method wich will fill our array by random numbers
        {
            foreach(int element in array) // Clear all field
            {
                array[element] = 99;//Number, which will not break our game, also each numbers from (-infinity;0)U(15;+infinity)
            }

            Random rand = new Random((int)DateTime.Now.Ticks);// Generator of random numbers
            
            for (int i = 0; i < 15; i++)
            {
                array[i] = rand.Next(0, 16);

                for (int j = 0; j < i; j++)//Check for exists nubers
                {
                    if (array[j] == array[i])
                    {
                        i--;
                        break;
                    }
                }
            }

            return array;//Return ready matrix with game field to clController
        }
    }
}
