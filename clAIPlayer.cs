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

            //int current_token = completion_check(field);//Check for completion of game, how equal 2 arrays: target and current

            //if (current_token == 99)//Check for end of game
            //    return (int)Direction.stay;

            //int result_x = 0, result_y = 0;
            //int direction;

            //for(int i = 0; i < 4; i++)
            //    for (int j = 0; j < 4; j++)
            //    {
            //        if (result[i, j] == current_token)
            //        {
            //            result_x = j;
            //            result_y = i;
            //            i = j = 99;//to escape the cicle
            //        }
            //    }


            //for(int i = 0; i < 4; i++)
            //    for (int j = 0; j < 4; j++)
            //    {
            //        if (field[i, j] == current_token)
            //        {
            //            direction = manhattan_way(j, i, result_x, result_y);

            //            switch (direction)//Change coordinates of target to space token
            //            {
            //                case (int)Direction.up:
            //                    {
            //                        result_y = i - 1;
            //                        break;
            //                    }
            //                case (int)Direction.down:
            //                    {
            //                        result_y = i + 1;
            //                        break;
            //                    }
            //                case (int)Direction.left:
            //                    {
            //                        result_x = j - 1;
            //                        break;
            //                    }
            //                case (int)Direction.right:
            //                    {
            //                        result_x = j + 1;
            //                        break;
            //                    }
            //            }
                        
            //            for(int a = 0; a < 4; a++)//Search location of space token on field to move it
            //                for (int b = 0; b < 4; b++)
            //                {
            //                    if (field[a, b] == 0)
            //                    {
            //                        return manhattan_way(b, a, result_x, result_y);
            //                    }
            //                }
            //        }
            //    }

            int current_token = completion_check(field);
            int result_x = 0, result_y = 0;//Coordinates field[2,3], were will be "snakes head"
            int direction;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (result[i, j] == current_token)
                    {
                        result_x = j;
                        result_y = i;
                        i = j = 99;//to escape the cicle
                    }
                }

            if (current_token != 10)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if (field[i, j] == current_token)
                        {
                            open_close[i, j] = 'x';
                            direction = manhattan_way(j, i, result_x, result_y);

                            switch (direction)//Change coordinates of target to space token
                            {
                                case (int)Direction.up:
                                    {
                                        result_y = i - 1;
                                        result_x = j;
                                        break;
                                    }
                                case (int)Direction.down:
                                    {
                                        result_y = i + 1;
                                        result_x = j;
                                        break;
                                    }
                                case (int)Direction.left:
                                    {
                                        result_x = j - 1;
                                        result_y = i;
                                        break;
                                    }
                                case (int)Direction.right:
                                    {
                                        result_x = j + 1;
                                        result_y = i;
                                        break;
                                    }
                            }

                            for(int a = 0; a < 4; a++)//Search location of space token on field to move it
                                for (int b = 0; b < 4; b++)
                                {
                                    if (field[a, b] == 0)
                                    {
                                        if (b == result_x && a == result_y)
                                        {
                                            open_close[i, j] = 'o';
                                            direction = manhattan_way(b, a, j, i);
                                            return direction; 
                                        }
                                        else
                                        {
                                            return manhattan_way(b, a, result_x, result_y);
                                        }
                                    }    
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
            
                                                         

            if (current_y - 1 >= 0 && open_close[current_y - 1, current_x] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y - 1, target_y)) + check_next_step(current_x, current_y - 1, target_x, target_y);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.up;
                }
            }

            if (current_y + 1 < 4 && open_close[current_y + 1, current_x] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y + 1, target_y)) + check_next_step(current_x, current_y + 1, target_x, target_y);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.down;
                }
            }

            if (current_x - 1 >= 0 && open_close[current_y, current_x - 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x - 1, target_x) + modal_calculate(current_y, target_y)) + check_next_step(current_x - 1, current_y, target_x, target_y);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.left;
                }
            }

            if (current_x + 1 < 4 && open_close[current_y, current_x + 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x + 1, target_x) + modal_calculate(current_y, target_y)) + check_next_step(current_x + 1, current_y, target_x, target_y);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.right;
                }
            }
            return direction;//Return best direction to move to target location
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int check_next_step(int current_x,int current_y,int target_x,int target_y)
        {
            int current_weight = 99, //weigth is priority for move in that location
                best_weight = 99;                                            

            if (current_y - 1 >= 0 && open_close[current_y - 1, current_x] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y - 1, target_y));
       
                if (best_weight > current_weight)
                    best_weight = current_weight;

            }

            if (current_y + 1 < 4 && open_close[current_y + 1, current_x] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y + 1, target_y));
                if (best_weight > current_weight)
                    best_weight = current_weight;
            }

            if (current_x - 1 >= 0 && open_close[current_y, current_x - 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x - 1, target_x) + modal_calculate(current_y, target_y));
                if (best_weight > current_weight)
                    best_weight = current_weight;
            }

            if (current_x + 1 < 4 && open_close[current_y, current_x + 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_x + 1,target_x) + modal_calculate(current_y, target_y));
                if (best_weight > current_weight)
                    best_weight = current_weight;
            }

            return best_weight;
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
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (field[i, j] == result[i, j])
                        open_close[i, j] = 'x';
                    else
                        return result[i, j];
                }
            return 99;//if cicle is end and arrays is equal
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void change_position(int[,] field, int move)
        {
            int time_variable, i = 0, j = 0;
            bool flag;

            for (i = 0, flag = false; i < 4 && flag == false; i++)//search space token
                for (j = 0; j < 4 && flag == false; j++)
                    if (field[i, j] == 0)
                    {
                        flag = true;//for exit cicle
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

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int snake_move(int[,] field)
        {
            return 1;
        }
    }
}
