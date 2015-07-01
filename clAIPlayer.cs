using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotnashki
{
    //~~~~~~~~~~~~~~~~~~~~~~~~ Class for Ai player ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    class clAIPlayer
    {
        public int[,] result_array= new int[4, 4];

        //char[,] open_close = new char[4, 4];//Array wich will contain information about all fields elements - is they opened or closed

        int current_weight = 0, //weigth is priority for move in that location
            best_weight;

        int[] queue_space = new int[30];
        int[] queue_element = new int[30];

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public clAIPlayer()//Constructor
        {
            for (int i = 0, count = 1; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result_array[i, j] = count++;
            result_array[3, 3] = 0;

            for (int i = 0; i < 30; i++)
            {
                queue_space[i] = 0;
                queue_element[i] = 0;
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int ai_play(int[,] field, char[,] open_close)
        {
            int current_element_i = 0,
	            current_element_j = 0,
	            space_i = 0,
	            space_j = 0,
	            target_i = 0,
	            target_j = 0,
	            direction = 0;

            best_weight = 999;
	
	       	//Поиск следующей по порядку фишки не на своем месте
            //And search all coordinates of current token not on its position, space token coordinates and target coordinates for current token
            for (int i = 0, flag = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (field[i, j] == result_array[i, j] && flag == 0)
                        open_close[i, j] = 'x';
                    else
                    {
                        if (flag == 0)//Remember i, j where current token should be placed
                        {
                            target_i = i;
                            target_j = j;
                            flag = 1;
                        }
                        else
                        {
                            if (field[i, j] == result_array[target_i, target_j])//Searching current token not on its position
                            {
                                current_element_i = i;
                                current_element_j = j;
                            }
                            else
                            {
                                if (field[i, j] == 0)//Searching space token
                                {
                                    space_i = i;
                                    space_j = j;
                                }
                            }
                        }
                    }
                }

	        if(result_array[current_element_i, current_element_j] == 0)//Game complete
		        return (int)Direction.stay;
	
	        if(queue_space_check() == "not empty")
		        return queue_space_next();		//Извлекаем из очереди следующее направление движения пустой фишки
	        else
		        if(queue_element_check() == "not empty")
		        {
			        direction = queue_element_next(); //Следующий элемент в очереди направлений для текущего элемента
			        target_i = current_element_i;
			        target_j = current_element_j;
			        target_i = to_coordinates_i(target_i, direction);//НАПИСАТЬ ФУНКЦИЮ преобразовывающие направление в координаты
			        target_j = to_coordinates_j(target_j, direction);

			        find_a_way(space_i, space_j, target_i, target_j, field, open_close, "space");//Запускаем функцию рекурсивного поиска пути в глубину и по завершению загружаем в очередь направления движения для пустой фишки в обратном порядке, для того чтобы функция поняла, что это для пустой фишки пишем строку "спейс"
			
			        //if(queue_space_check() == "not empty")
				    return queue_space_next();//Возвращаем первый элемент в очереди направлений для пустой фишки
			        //else
				        //WTF?!!
		        }
		        else//Просто вставил, не проверял
		        {
			        find_a_way(current_element_i, current_element_j, target_i, target_j, field, open_close, "element");//Запускаем функцию для рекурсивного поиска пути в глубину массива и по завершению поиска загружаем результаты в очередь направлений дивжения для элемента, чтобы функция поняла, что это для элемента отправляем функции строку "элемент"
			
			        if(queue_element_check() == "not empty")
			        {
                        best_weight = 999;
				        direction = queue_element_next(); //Следующий элемент в очереди направлений для текущего элемента
			            target_i = current_element_i;
			            target_j = current_element_j;
                        target_i = to_coordinates_i(target_i, direction);//НАПИСАТЬ ФУНКЦИЮ преобразовывающие направление в координаты
                        target_j = to_coordinates_j(target_j, direction);

			            find_a_way(space_i, space_j, target_i, target_j, field, open_close, "space");//Запускаем функцию рекурсивного поиска пути в глубину и по завершению загружаем в очередь направления движения для пустой фишки в обратном порядке, для того чтобы функция поняла, что это для пустой фишки пишем строку "спейс"
			
			            //if(queue_space_check() == "not empty")
				        return queue_space_next();
			        }
                    return (int)Direction.stay;
		        }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        string queue_space_check()
        {
            for (int i = 0; i < queue_space.Length; i++)
            {
                if (queue_space[i] == 0)
                    continue;
                else
                    return "not empty";
            }
            return "empty";
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        string queue_element_check()
        {
            for (int i = 0; i < queue_element.Length; i++)
            {
                if (queue_element[i] == 0)
                    continue;
                else
                    return "not empty";
            }
            return "empty";
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int queue_space_next()
        {
            for (int i = 1; i < queue_space.Length; i++)
            {
                if (queue_space[i] == 0)
                    continue;
                else
                {
                    int direction = queue_space[i];
                    queue_space[i] = 0;
                    return direction;
                }
            }
            return 0;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int queue_element_next()
        {
            for (int i = 1; i < queue_element.Length; i++)
            {
                if (queue_element[i] == 0)
                    continue;
                else
                {
                    int direction = queue_element[i];
                    queue_element[i] = 0;
                    return direction;
                }
            }
            return 0;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int to_coordinates_i(int i, int direction)
        {
            if (direction == (int)Direction.up)
                i -= 1;
            else
            {
                if (direction == (int)Direction.down)
                    i += 1;
            }
            return i;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int to_coordinates_j(int j, int direction)
        {
            if (direction == (int)Direction.left)
                j -= 1;
            else
            {
                if (direction == (int)Direction.down)
                    j += 1;
            }
            return j;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        string find_a_way(int current_i, int current_j, int target_i, int target_j, int[,] field, char[,] open_close, string type)
        {
            //int direction = 0;       //values wich willn't conflict with progam

            char[,] loc_open_close = new char[4, 4];//local array wich contain status about accessability of elements in field

            loc_open_close = open_close;

            if(current_i == target_i && current_j == target_j)
            {
                return "Success!";
            }
                    
            if(current_weight > best_weight)
            {
                return "Fail...";
            }

            if (current_i - 1 >= 0 && loc_open_close[current_i - 1, current_j] != 'x')
            {
                current_weight += 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i - 1, target_i));

                loc_open_close[current_i, current_j] = 'x';

                string status = find_a_way(current_i - 1, current_j, target_i, target_j, field, loc_open_close, type);

                if(status == "Success!")
                {
                    best_weight = current_weight;

                    if(type == "element")
                        queue_add((int)Direction.up, type);
                    else
                        queue_add((int)Direction.up, type);

                    return status;
                }
                current_weight -= 10;
            }

            if (current_i + 1 < 4 && loc_open_close[current_i + 1, current_j] != 'x')
            {
                current_weight += 10 * (modal_calculate(current_j, target_j) + modal_calculate(current_i + 1, target_i));

                loc_open_close[current_i, current_j] = 'x';

                string status = find_a_way(current_i + 1, current_j, target_i, target_j, field, loc_open_close, type);

                if(status == "Success!")
                {
                    best_weight = current_weight;

                    if(type == "element")
                        queue_add((int)Direction.down, type);
                    else
                        queue_add((int)Direction.down, type);

                    return status;
                }
                current_weight -= 10;
            }

            if (current_j - 1 >= 0 && loc_open_close[current_i, current_j - 1] != 'x')
            {
                current_weight += 10 * (modal_calculate(current_j - 1, target_j) + modal_calculate(current_i, target_i));

                loc_open_close[current_i, current_j] = 'x';

                string status = find_a_way(current_i, current_j - 1, target_i, target_j, field, loc_open_close, type);

                if(status == "Success!")
                {
                    best_weight = current_weight;

                    if(type == "element")
                        queue_add((int)Direction.left, type);
                    else
                        queue_add((int)Direction.left, type);

                    return status;
                }
                current_weight -= 10;
            }

            if (current_j + 1 < 4 && loc_open_close[current_i, current_j + 1] != 'x')
            {
                current_weight += 10 * (modal_calculate(current_j + 1, target_j) + modal_calculate(current_i, target_i));

                loc_open_close[current_i, current_j] = 'x';

                string status = find_a_way(current_i, current_j + 1, target_i, target_j, field, loc_open_close, type);

                if(status == "Success!")
                {
                    best_weight = current_weight;

                    if(type == "element")
                        queue_add((int)Direction.right, type);
                    else
                        queue_add((int)Direction.right, type);

                    return status;
                }
                current_weight -= 10;
            }
            current_weight -= 10;
            return "Fail...";
        }
                        //else
                        //    return queue_element_check();

            //return direction;//Return best direction to move to target location
            //if(
            //direction = find_a_way(next_i, next_j, target_i, target_j);
            //if(type == "space")
            //    queue_space_add(direction);
            //else
            //    if(type == "element")
            //        queue_element_add(direction);
                //else error

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        void queue_add(int direction, string type)
        {
            if (type == "element")
            {
                for (int i = 1; i < queue_element.Length; i++)
                {
                    if (queue_element[i] == 0 && i < queue_element.Length - 1)
                        continue;
                    else
                    {
                        if (queue_element[i] != 0)
                        {
                            queue_element[i - 1] = direction;
                            break;
                        }
                        else
                        {
                            queue_element[i] = direction;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (type == "space")
                {
                    for (int i = 1; i < queue_space.Length; i++)
                    {
                        if (queue_space[i] == 0 && i < queue_space.Length - 1)
                            continue;
                        else
                        {
                            if (queue_space[i] != 0)
                            {
                                queue_space[i - 1] = direction;
                                break;
                            }
                            else
                            {
                                queue_space[i] = direction;
                                break;
                            }
                        }
                    }
                    
                }
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //public int manhattan_way(int current_x, int current_y, int target_x, int target_y)//universal function wich will search best direction to move by manhattan way to aim location from (x, y) position
        //{
        //    int direction = 0,       //values wich willn't conflict with progam
        //        current_weight = 99, //weigth is priority for move in that location
        //        best_weight = 99;
            
                                                         

        //    if (current_y - 1 >= 0 && open_close[current_y - 1, current_x] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y - 1, target_y)) + check_next_step(current_x, current_y - 1, target_x, target_y);
        //        if (best_weight > current_weight)
        //        {
        //            best_weight = current_weight;
        //            direction = (int)Direction.up;
        //        }
        //    }

        //    if (current_y + 1 < 4 && open_close[current_y + 1, current_x] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y + 1, target_y)) + check_next_step(current_x, current_y + 1, target_x, target_y);
        //        if (best_weight > current_weight)
        //        {
        //            best_weight = current_weight;
        //            direction = (int)Direction.down;
        //        }
        //    }

        //    if (current_x - 1 >= 0 && open_close[current_y, current_x - 1] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x - 1, target_x) + modal_calculate(current_y, target_y)) + check_next_step(current_x - 1, current_y, target_x, target_y);
        //        if (best_weight > current_weight)
        //        {
        //            best_weight = current_weight;
        //            direction = (int)Direction.left;
        //        }
        //    }

        //    if (current_x + 1 < 4 && open_close[current_y, current_x + 1] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x + 1, target_x) + modal_calculate(current_y, target_y)) + check_next_step(current_x + 1, current_y, target_x, target_y);
        //        if (best_weight > current_weight)
        //        {
        //            best_weight = current_weight;
        //            direction = (int)Direction.right;
        //        }
        //    }
        //    return direction;//Return best direction to move to target location
        //}

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //int check_next_step(int current_x,int current_y,int target_x,int target_y)
        //{
        //    int current_weight = 99, //weigth is priority for move in that location
        //        best_weight = 99;                                            

        //    if (current_y - 1 >= 0 && open_close[current_y - 1, current_x] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y - 1, target_y));
       
        //        if (best_weight > current_weight)
        //            best_weight = current_weight;

        //    }

        //    if (current_y + 1 < 4 && open_close[current_y + 1, current_x] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x, target_x) + modal_calculate(current_y + 1, target_y));
        //        if (best_weight > current_weight)
        //            best_weight = current_weight;
        //    }

        //    if (current_x - 1 >= 0 && open_close[current_y, current_x - 1] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x - 1, target_x) + modal_calculate(current_y, target_y));
        //        if (best_weight > current_weight)
        //            best_weight = current_weight;
        //    }

        //    if (current_x + 1 < 4 && open_close[current_y, current_x + 1] != 'x')
        //    {
        //        current_weight = 10 * (modal_calculate(current_x + 1,target_x) + modal_calculate(current_y, target_y));
        //        if (best_weight > current_weight)
        //            best_weight = current_weight;
        //    }

        //    return best_weight;
        //}
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int modal_calculate(int current, int target)//For right result in manhattans calculations
        {
            if (current < target)
                return target - current;
            else
                return current - target;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //int completion_check(int[,] field, char[,] open_close)
        //{
        //    for (int i = 0; i < 4; i++)
        //        for (int j = 0; j < 4; j++)
        //        {
        //            if (field[i, j] == result_array[i, j])
        //                open_close[i, j] = 'x';
        //            else
        //                return result_array[i, j];
        //        }
        //    return 99;//if cicle is end and arrays is equal
        //}

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
