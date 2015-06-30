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

        char[,] open_close = new char[4, 4];//Array wich will contain information about all fields elements - is they opened or closed

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public clAIPlayer()//Constructor
        {
            for (int i = 0, count = 1; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result_array[i, j] = count++;
            result_array[3, 3] = 0;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int ai_play(int[,] field)
        {
            int current_element_i = 0,
	            current_element_j = 0,
	            space_i = 0,
	            space_j = 0,
	            target_i = 0,
	            target_j = 0,
	            direction = 0;
	
	       	//Поиск следующей по порядку фишки не на своем месте
            for(int i = 0; i < 4; i++)
			        for(int j =  0; j < 4; j++)
				        if(field[i,j] == result_array[i,j])
					        open_close[i,j] = 'x';
				        else
                        {
					        if(result_array[i,j] == 0)
                            {
                                i = 99;
                                j = 99;
                            }
					        else
					        {			
						        target_i = i;
						        target_j = j;
						        i = 99;
						        j = 99;
					        }		
				        }

		        for(int i = 0; i < 4; i++)
			        for(int j = 0; j < 4; j++)
				        if(field[i,j] == result_array[target_i, target_j])
				        {
					        current_element_i = i;
					        current_element_j = j;
					        i = 99;
					        j = 99;
				        }
	        

	        //Поиск пустой фишки
	         for(int i = 0; i < 4; i++)
			        for(int j = 0; j < 4; j++)
				        if(field[i,j] == 0)
				        {
					        space_i = i;
					        space_j = j;
					        break;
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

			        find_a_way(space_i, space_j, target_i, target_j, field, "space");//Запускаем функцию рекурсивного поиска пути в глубину и по завершению загружаем в очередь направления движения для пустой фишки в обратном порядке, для того чтобы функция поняла, что это для пустой фишки пишем строку "спейс"
			
			        if(queue_space_check() == "not empty")
				        return queue_space_next();//Возвращаем первый элемент в очереди направлений для пустой фишки
			        //else
				        //WTF?!!
		        }
		        else//Просто вставил, не проверял
		        {
			        find_a_way(current_element_i, current_element_j, target_i, target_j, field, "element");//Запускаем функцию для рекурсивного поиска пути в глубину массива и по завершению поиска загружаем результаты в очередь направлений дивжения для элемента, чтобы функция поняла, что это для элемента отправляем функции строку "элемент"
			
			        if(queue_element_check() == "not empty")
			        {
				        direction = queue_element_next(); //Следующий элемент в очереди направлений для текущего элемента
			            target_i = current_element_i;
			            target_j = current_element_j;
                        target_i = to_coordinates_i(target_i, direction);//НАПИСАТЬ ФУНКЦИЮ преобразовывающие направление в координаты
                        target_j = to_coordinates_j(target_j, direction);

			            find_a_way(space_i, space_j, target_i, target_j, field, "space");//Запускаем функцию рекурсивного поиска пути в глубину и по завершению загружаем в очередь направления движения для пустой фишки в обратном порядке, для того чтобы функция поняла, что это для пустой фишки пишем строку "спейс"
			
			            if(queue_space_check() == "not empty")
				        return queue_space_next();
			        }
				
		        }

            //int current_token = completion_check(field);
            //int result_x = 0, result_y = 0;//Coordinates field[2,3], were will be "snakes head"
            //int direction;

            //for (int i = 0; i < 4; i++)
            //    for (int j = 0; j < 4; j++)
            //    {
            //        if (result[i, j] == current_token)
            //        {
            //            result_x = j;
            //            result_y = i;
            //            i = j = 99;//to escape the cicle
            //        }
            //    }

            //if (current_token != 10)
            //{
            //    for (int i = 0; i < 4; i++)
            //        for (int j = 0; j < 4; j++)
            //        {
            //            if (field[i, j] == current_token)
            //            {
            //                open_close[i, j] = 'x';
            //                direction = manhattan_way(j, i, result_x, result_y);

            //                switch (direction)//Change coordinates of target to space token
            //                {
            //                    case (int)Direction.up:
            //                        {
            //                            result_y = i - 1;
            //                            result_x = j;
            //                            break;
            //                        }
            //                    case (int)Direction.down:
            //                        {
            //                            result_y = i + 1;
            //                            result_x = j;
            //                            break;
            //                        }
            //                    case (int)Direction.left:
            //                        {
            //                            result_x = j - 1;
            //                            result_y = i;
            //                            break;
            //                        }
            //                    case (int)Direction.right:
            //                        {
            //                            result_x = j + 1;
            //                            result_y = i;
            //                            break;
            //                        }
            //                }

            //                for(int a = 0; a < 4; a++)//Search location of space token on field to move it
            //                    for (int b = 0; b < 4; b++)
            //                    {
            //                        if (field[a, b] == 0)
            //                        {
            //                            if (b == result_x && a == result_y)
            //                            {
            //                                open_close[i, j] = 'o';
            //                                direction = manhattan_way(b, a, j, i);
            //                                return direction; 
            //                            }
            //                            else
            //                            {
            //                                return manhattan_way(b, a, result_x, result_y);
            //                            }
            //                        }    
            //                    }
            //            }
            //        }
            //}

            //return (int)Direction.stay;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        string queue_space_check()
        {
            return "empty";
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        string queue_element_check()
        {
            return "empty";
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int queue_space_next()
        {
            return 1;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int queue_element_next()
        {
            return 1;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int to_coordinates_i(int i, int direction)
        {
            return 1;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int to_coordinates_j(int j, int direction)
        {
            return 1;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        int find_a_way(int current_i, int current_j, int target_i, int target_j, int[,] field, string type)
        {
            int direction = 0,       //values wich willn't conflict with progam
                current_weight = 99, //weigth is priority for move in that location
                best_weight = 99,
                next_i = 0,
                next_j = 0;
            char[,] loc_open_close = new char[4, 4];//local array wich contain status about accessability of elements in field

            loc_open_close = open_close;



            if (current_i - 1 >= 0 && loc_open_close[current_i - 1, current_j] != 'x')
            {
                current_weight = 10 * (modal_calculate(current_i, target_j) + modal_calculate(current_i - 1, target_j));
                if (best_weight > current_weight)
                {
                    best_weight = current_weight;
                    direction = (int)Direction.up;
                    next_i = current_i - 1;
                    next_j = current_j;
                }
            }
            else
            {
                if (current_i + 1 < 4 && loc_open_close[current_i + 1, current_j] != 'x')
                {
                    current_weight = 10 * (modal_calculate(current_i, target_j) + modal_calculate(current_i + 1, target_j));
                    if (best_weight > current_weight)
                    {
                        best_weight = current_weight;
                        direction = (int)Direction.down;
                        next_i = current_i + 1;
                        next_j = current_j;
                    }
                }
                else
                {
                    if (current_j - 1 >= 0 && loc_open_close[current_i, current_j - 1] != 'x')
                    {
                        current_weight = 10 * (modal_calculate(current_j - 1, target_j) + modal_calculate(current_i, target_i));
                        if (best_weight > current_weight)
                        {
                            best_weight = current_weight;
                            direction = (int)Direction.left;
                            next_i = current_i;
                            next_j = current_j - 1;
                        }
                    } 
                    else
                    {

                        if (current_j + 1 < 4 && loc_open_close[current_i, current_j + 1] != 'x')
                        {
                            current_weight = 10 * (modal_calculate(current_j + 1, target_j) + modal_calculate(current_i, target_j));
                            if (best_weight > current_weight)
                            {
                                best_weight = current_weight;
                                direction = (int)Direction.right;
                                next_i = current_i;
                                next_j = current_j + 1;
                            }
                        }
                        else
                            return queue_element_check();
                    }
                }
            }
            //return direction;//Return best direction to move to target location
            if(
            direction = find_a_way(next_i, next_j, target_i, target_j);
            if(type == "space")
                queue_space_add(direction);
            else
                if(type == "element")
                    queue_element_add(direction);
                //else error
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
