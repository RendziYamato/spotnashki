using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~~~~~ Class for Ai player ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class clAIPlayer
    {
        public int[,] result_array = new int[(int)MaxArraySize.x, (int)MaxArraySize.y];
        public int[,] time_result_array = new int[(int)MaxArraySize.x, (int)MaxArraySize.y];

        char[,] open_close = new char[(int)MaxArraySize.x, (int)MaxArraySize.y];//Array wich will contain information about all fields elements - is they opened or closed
        char[,] space_open_close = new char[(int)MaxArraySize.x, (int)MaxArraySize.y];
        string stuck_away_status;

        int[] snake;

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public clAIPlayer()//Constructor
        {
            int i = 0, j = 0, count;
            for (count = 1; i < (int)MaxArraySize.x; i++)
                for (; j < (int)MaxArraySize.y; j++)
                    result_array[i, j] = count++;
            result_array[i-1, j-1] = 0;

            stuck_away_status = "not_active";
            snake = new int[(int)MaxArraySize.y * (int)MaxArraySize.y];
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int ai_play(int[,] field)
        {
            int current_token = completion_check(field);
            int result_j = 0, result_i = 0;
            int head,
                head_i,
                head_j;
            int direction;

            //if (stuck_away_status == "active")
            //{
            //    for (int i = 0; i < (int)MaxArraySize.x; i++)
            //        for (int j = 0; j < (int)MaxArraySize.y; j++)
            //            if (result_array[i, j] == current_token)
            //                head = result_array[i, 0];
            //    for(int i = 0
            //}

            //Search coordinates of target of current element
            for (int i = 0; i < (int)MaxArraySize.x; i++)
                for (int j = 0; j < (int)MaxArraySize.y; j++)
                {
                    if (result_array[i, j] == current_token)
                    {
                        result_j = j;
                        result_i = head_i = i;
                        i = j = 99;//to escape the cicle
                    }
                }

            //Search coordinates of current element and find best direction to move
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

                            for(int a = 0; a < (int)MaxArraySize.x; a++)//Search location of space token on field to move it
                                for (int b = 0; b < (int)MaxArraySize.y; b++)
                                {
                                    if (field[a, b] == 0)
                                    {
                                        if (b == result_j && a == result_i)
                                        {
                                            open_close[i, j] = ' ';
                                            clear_space_open_close();
                                            direction = manhattan_way(b, a, j, i);
                                            if (direction == 0)
                                            {
                                                stuck_away_on();
                                            }
                                            else
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

            return (int)Direction.stay;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int manhattan_way(int current_j, int current_i, int target_j, int target_i)//universal function wich will search best direction to move by manhattan way to aim location from (x, y) position
        {
            int direction = 0,       //values wich willn't conflict with progam
                current_weight = 99, //weigth is priority for move in that location
                best_weight = 99;



            if (current_i - 1 >= 0 && open_close[current_i - 1, current_j] != 'x' && space_open_close[current_i - 1, current_j] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i - 1, target_i)) + check_next_step(current_j, current_i - 1, target_j, target_i);
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.up;
                }
            }
            else
            {
                if (current_i + 1 < (int)MaxArraySize.x && open_close[current_i + 1, current_j] != 'x' && space_open_close[current_i + 1, current_j] != 'x')
                {
                    current_weight = 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i + 1, target_i)) + check_next_step(current_j, current_i + 1, target_j, target_i);
                    if (best_weight > current_weight)
                    {
                        best_weight = current_weight;
                        direction = (int)Direction.down;
                    }
                }
                else
                {
                    if (current_j - 1 >= 0 && open_close[current_i, current_j - 1] != 'x' && space_open_close[current_i, current_j - 1] != 'x')
                    {
                        current_weight = 10 * (modal_calculate(current_j - 1, target_j) + modal_calculate(current_i, target_i)) + check_next_step(current_j - 1, current_i, target_j, target_i);
                        if (best_weight > current_weight)
                        {
                            best_weight = current_weight;
                            direction = (int)Direction.left;
                        }
                    }
                    else
                    {
                        if (current_j + 1 < (int)MaxArraySize.x && open_close[current_i, current_j + 1] != 'x' && space_open_close[current_i, current_j + 1] != 'x')
                        {
                            current_weight = 10 * (modal_calculate(current_j + 1, target_j) + modal_calculate(current_i, target_i)) + check_next_step(current_j + 1, current_i, target_j, target_i);
                            if (best_weight >= current_weight)//It's better to go right than left first
                            {
                                best_weight = current_weight;
                                direction = (int)Direction.right;
                            }
                        }
                        else
                            stuck_away_on(current_i, current_j, target_i, target_j); ;
                    }
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

            if (current_i + 1 < (int)MaxArraySize.x && open_close[current_i + 1, current_j] != 'x' && space_open_close[current_i + 1, current_j] != 'x')
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

            if (current_j + 1 < (int)MaxArraySize.x && open_close[current_i, current_j + 1] != 'x' && space_open_close[current_i, current_j + 1] != 'x')
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
            for (int i = 0; i < (int)MaxArraySize.x; i++)
                for (int j = 0; j < (int)MaxArraySize.y; j++)
                {
                    if (field[i, j] == result_array[i, j])
                    {
                        space_open_close[i, j] = 'x';
                        open_close[i, j] = 'x';
                    }
                    else
                        return result_array[i, j];
                }
            return 99;//if cicle is end and arrays are equal
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        void stuck_away_on(int current_i, int current_j, int target_i, int target_j, int[,] field)
        {
            stuck_away_status = "active";

            for (int i = target_i, j = 0; j < target_j; j++ )
                snake[j] = result_array[i, j];

            snake_move(current_i, current_j, target_i, target_j, field);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int snake_move(int current_i, int current_j, int target_i, int target_j, int[,] field)
        {
            //Search element to move, and then move it
            for(int i = 0; i < (int)MaxArraySize.x; i++)
                for(int j = 0; j < (int)MaxArraySize.y; j++)
                    for(int k = 0; k <  (int)MaxArraySize.x*(int)MaxArraySize.y; k++)
                        if(result_array[i,j] == snake[k] && snake[k] != 99)//If we found snake element in result array, and if its element is not end(tail)
                        {
                            if (j - 1 >= 0 && i < (int)MaxArraySize.x - 1)//At first we try to move snake to left side
                                result_array[i, j - 1] = result_array[i, j];
                            else
                                if (i + 1 < (int)MaxArraySize.x && i < (int)MaxArraySize.x - 1)//If first try wasn't successful we try to move snake to bottom side
                                    result_array[i + 1, j] = result_array[i, j];
                                else
                                    if (j + 1 < (int)MaxArraySize.y && i == (int)MaxArraySize.x - 1)//To right side
                                        result_array[i, j + 1] = result_array[i, j];
                                    else
                                        if (i - 1 >= 0 && i == (int)MaxArraySize.x - 1 && open_close[i - 1, j] != 'x')//And to top side
                                            result_array[i - 1, j] = result_array[i, j];
                                        else
                                            return 0;//If we can not move snake

                        }
            return 1;//Snake was moved
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //This function will end method stuck_away and clean "snake"
        void stuck_away_off()
        {
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        void clear_space_open_close()
        {
            for (int i = 0; i < (int)MaxArraySize.x; i++)
                for (int j = 0; j < (int)MaxArraySize.y; j++)
                    space_open_close[i, j] = ' ';
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void change_position(int[,] field, int move)
        {
            int time_variable, i = 0, j = 0;
            bool flag;

            for (i = 0, flag = false; i < (int)MaxArraySize.x && flag == false; i++)//search space token
                for (j = 0; j < (int)MaxArraySize.y && flag == false; j++)
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
