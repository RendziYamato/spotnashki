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

        clMain Main = new clMain();//Main class wich will contain all information about game field: number of steps, status and field status

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void create() //request to create new game field
        {
            Creator.create_field(Main.field);//Recive new matrix-field and send it to clMain
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void move(int[,] field, int move)
        {
            AI.change_position(field, move);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public string win_check()
        {
            return Main.win_check(AI.result_array);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int[,] game_field()
        {
            return Main.field;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int next_step()
        {
            return AI.ai_play(Main.field);
        }
    }
}
