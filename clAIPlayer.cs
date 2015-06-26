﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~~~~~ Class for Ai player ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    class clAIPlayer
    {
        public int[,] result = new int[4, 4];

        char[,] open_close = new char[4, 4];//Array wich will contain information about all fields elements - is they opened or closed

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public clAIPlayer()//Constructor
        {
            for (int i = 0, count = 1; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = count++;
            result[3, 3] = 0;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int ai_play(int[,] field)
        {

            int current_token = completion_check(field);
            int result_x = 0, result_y = 0;
            int direction;

            for(int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (result[i, j] == current_token)
                    {
                        result_x = i;
                        result_y = j;
                    }
                }


            for(int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (field[i, j] == current_token)
                    {
                        direction = manhattan_way(i, j, result_x, result_y);

                        switch (direction)
                        {
                            case (int)Direction.up:
                                {
                                    result_y-=1;
                                    break;
                                }
                            case (int)Direction.down:
                                {
                                    result_y+=1;
                                    break;
                                }
                            case (int)Direction.left:
                                {
                                    result_x-=1;
                                    break;
                                }
                            case (int)Direction.right:
                                {
                                    result_x+=1;
                                    break;
                                }
                        }
                        
                        for(int a = 0; a < 4; a++)
                            for (int b = 0; b < 4; b++)
                            {
                                if (field[a, b] == 0)
                                {
                                    return manhattan_way(a, b, result_x, result_y);
                                }
                            }
                    }
                }
            return (int)Direction.stay;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int manhattan_way(int current_x, int current_y, int target_x, int target_y)//universal function wich will search best direction to move by manhattan way to aim location from (x, y) position
        {
            int direction = 0,       //values wich willn't conflict with progam
                current_weight = 99, //weigth is priority for move in that location
                best_weight = 99;
                                                                     

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
            return direction;//Return best direction to move to target location
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int modal_calculate(int current, int target)//For right result in manhattans calculations
        {
            if (current < target)
                return target - current;
            else
                return current - target;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int completion_check(int[,] field)
        {
            int current_token = 0;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (field[i, j] == result[i, j])
                        current_token++;
                    else
                        return current_token;
                }
            return current_token;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void change_position(int[,] field, int move)
        {
            int time_variable, i = 0, j = 0;
            bool flag;

            for (i = 0, flag = false; i < 4 && flag == false; i++)
                for (j = 0; j < 4 && flag == false; j++)
                    if (field[i, j] == 0)
                    {
                        flag = true;
                        i--;
                        j--;
                    }

            switch (move)
            {
                case (int)Direction.up:
                    {
                        time_variable = field[i - 1, j];
                        field[i - 1, j] = field[i, j];
                        field[i, j] = time_variable;
                        break;
                    }
                case (int)Direction.down:
                    {
                        time_variable = field[i + 1, j];
                        field[i + 1, j] = field[i, j];
                        field[i, j] = time_variable;
                        break;
                    }
                case (int)Direction.left:
                    {
                        time_variable = field[i, j - 1];
                        field[i, j - 1] = field[i, j];
                        field[i, j] = time_variable;
                        break;
                    }
                case (int)Direction.right:
                    {
                        time_variable = field[i, j + 1];
                        field[i, j + 1] = field[i, j];
                        field[i, j] = time_variable;
                        break;
                    }
            }
        }
    }
}
