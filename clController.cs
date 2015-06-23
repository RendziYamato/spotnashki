using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~ Class wich will contain all operations among classes ~~~~~~~~~~~~~~~~~~~~~~

    public class clController
    {
        clCreator Creator = new clCreator();//Create creator of game field

        clMain Main = new clMain();//Main class wich will contain all information about game: number of steps, status and field status

        public void create() //request to create new game field
        {
            Main.Field = Creator.create_field(Main.Field);//Recive new matrix-field and send it to clMain
        }
    }
}
