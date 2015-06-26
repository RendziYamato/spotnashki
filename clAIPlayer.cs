using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~~~~~
    class clAIPlayer
    {
        int[,] result = new int[4, 4];

        char[,] open_close = new char[4, 4];//Array wich will contain information about all fields elements - is they opened or closed

        public clAIPlayer()//Constructor
        {
            for (int i = 0, count = 1; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = count++;
        }

        public void ai_play(int[,] field)
        {
            int current_token = 1;

            for(int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (field[i, j] == current_token)
                    {


                        current_token++;
                    }
                }
        }

        public int manhattan_way(int current_x, int current_y, int target_x, int target_y)//universal function wich will search best direction to move by manhattan way to aim location from (x, y) position
        {
            int direction = 0, current_weight = 99, best_weight = 99;//values wich willn't conflict with progam
                                                                     //weigth is priority for move in that location

            if (current_y - 1 >= 0 && open_close[current_x, current_y - 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y - 1, target_y));
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.up;
                }
            }
            if (current_y + 1 < 4 && open_close[current_x, current_y + 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y + 1, target_y));
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.down;
                }
            }
            if (current_x - 1 >= 0 && open_close[current_x - 1, current_y] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x - 1, target_x) + modal_calculate(current_y, target_y));
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.left;
                }
            }
            if (current_x + 1 < 4 && open_close[current_x + 1, current_y] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x + 1,target_x) + modal_calculate(current_y, target_y));
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.right;
                }
            }
            
            return direction;
        }
        

        int modal_calculate(int current, int target)//For right result in manhattans calculations
        {
            if (current < target)
                return target - current;
            else
                return current - target;
        }

    }
}
