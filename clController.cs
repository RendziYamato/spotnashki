using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~ Class wich will be contain all operations among classes ~~~~~~~~~~~~~~~~~~~~~~

    public class clController
    {
        clCreator Creator = new clCreator();//Create creator of game field

        public void create(int[,] field) //request to create new game field
        {
            Creator.create_field(field);//Recive new matrix-field and send it to clMain
        }
    }
}
