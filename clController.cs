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

        clAIPlayer AI = new clAIPlayer();

        public void create(int[,] field) //request to create new game field
        {
            Creator.create_field(field);//Recive new matrix-field and send it to clMain
        }

        public void move(int[,] field, int move)
        {
            Creator.change_position(field, move);
        }
    }
}
