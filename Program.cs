using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[16];

            Program method = new Program();

            method.creator();
        }
            
            public void creator()
            {
                int[] arr = new int[16];

                Random rand = new Random((int)DateTime.Now.Ticks);

                for (int i = 0; i < 16; i++)
                {
                    arr[i] = rand.Next(0, 16);

                    for (int j = 0; j < i; j++)
                    {
                        if (arr[j] == arr[i])
                            i--;
                    }
                }

                Console.WriteLine(arr);
            }
        }
    }
