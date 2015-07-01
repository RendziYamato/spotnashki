using System;
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
        char[,] space_open_close = new char[4, 4];

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
            int result_j = 0, result_i = 0;//Coordinates field[2,3], were will be "snakes head"
            int direction;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (result[i, j] == current_token)
                    {
                        result_j = j;
                        result_i = i;
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
                            direction = manhattan_way(j, i, result_j, result_i);

                            switch (direction)//Change coordinates of target to space token
                            {
                                case (int)Direction.up:
                                    {
                                        result_i = i - 1;
                                        result_j = j;
                                        break;
                                    }
                                case (int)Direction.down:
                                    {
                                        result_i = i + 1;
                                        result_j = j;
                                        break;
                                    }
                                case (int)Direction.left:
                                    {
                                        result_j = j - 1;
                                        result_i = i;
                                        break;
                                    }
                                case (int)Direction.right:
                                    {
                                        result_j = j + 1;
                                        result_i = i;
                                        break;
                                    }
                            }

                            for(int a = 0; a < 4; a++)//Search location of space token on field to move it
                                for (int b = 0; b < 4; b++)
                                {
                                    if (field[a, b] == 0)
                                    {
                                        if (b == result_j && a == result_i)
                                        {
                                            open_close[i, j] = 'o';
                                            clear_space_open_close();
                                            direction = manhattan_way(b, a, j, i);
                                            return direction;
                                        }
                                        else
                                        {
                                            space_open_close[a, b] = 'x';
                                            direction = manhattan_way(b, a, result_j, result_i);
                                            return direction;
                                        }
                                    }    
                                }
                        }
                    }
            }

            return (int)Direction.stay;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int manhattan_way(int current_j, int current_i, int target_j, int target_i)//universal function wich will search best direction to move by manhattan way to aim location from (x, y) position
        {
            int direction = 0,       //values wich willn't conflict with progam
                current_weight = 99, //weigth is priority for move in that location
                best_weight = 99;
            
                                                         

            if (current_i - 1 >= 0 && open_close[current_i - 1, current_j] != 'x' && space_open_close[current_i-1, current_j] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i - 1, target_i)) + check_next_step(current_j, current_i - 1, target_j, target_i);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.up;
                }
            }

            if (current_i + 1 < 4 && open_close[current_i + 1, current_j] != 'x' && space_open_close[current_i + 1, current_j] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i + 1, target_i)) + check_next_step(current_j, current_i + 1, target_j, target_i);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.down;
                }
            }

            if (current_j - 1 >= 0 && open_close[current_i, current_j - 1] != 'x' && space_open_close[current_i, current_j - 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j - 1, target_j) + modal_calculate(current_i, target_i)) + check_next_step(current_j - 1, current_i, target_j, target_i);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.left;
                }
            }

            if (current_j + 1 < 4 && open_close[current_i, current_j + 1] != 'x' && space_open_close[current_i, current_j + 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j + 1, target_j) + modal_calculate(current_i, target_i)) + check_next_step(current_j + 1, current_i, target_j, target_i);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.right;
                }
            }
            return direction;//Return best direction to move to target location
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int check_next_step(int current_j,int current_i,int target_j,int target_i)
        {
            int current_weight = 99, //weigth is priority for move in that location
                best_weight = 99;

            if (current_i == target_i && current_j == target_j)
                return 0;

            if (current_i - 1 >= 0 && open_close[current_i - 1, current_j] != 'x' && space_open_close[current_i - 1, current_j] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i - 1, target_i));
       
                if (best_weight > current_weight)
                    best_weight = current_weight;

            }

            if (current_i + 1 < 4 && open_close[current_i + 1, current_j] != 'x' && space_open_close[current_i + 1, current_j] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i + 1, target_i));
                if (best_weight > current_weight)
                    best_weight = current_weight;
            }

            if (current_j - 1 >= 0 && open_close[current_i, current_j - 1] != 'x' && space_open_close[current_i, current_j - 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j - 1, target_j) + modal_calculate(current_i, target_i));
                if (best_weight > current_weight)
                    best_weight = current_weight;
            }

            if (current_j + 1 < 4 && open_close[current_i, current_j + 1] != 'x' && space_open_close[current_i, current_j + 1] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j + 1,target_j) + modal_calculate(current_i, target_i));
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
                    {
                        space_open_close[i, j] = 'x';
                        open_close[i, j] = 'x';
                    }
                    else
                        return result[i, j];
                }
            return 99;//if cicle is end and arrays are equal
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        void clear_space_open_close()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    space_open_close[i, j] = ' ';
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
