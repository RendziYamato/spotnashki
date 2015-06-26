using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Resources;

namespace Spotnashki
{
    enum Direction { up = 1, down, left, right, stay };

    public partial class frmMainScreen : Form
    {
        

        clController Controller = new clController();

        clField Field = new clField();//Main class wich will contain all information about game field: number of steps, status and field status

        public frmMainScreen()
        {
            InitializeComponent();
            Controller.create(Field.field);//We create new game field in matrix form
        }

        void first_draw()
        {
            int no_moving_object = 99;
            int no_direction = 99;
            draw(Field.field, no_moving_object, no_direction);
        }

        public void draw(int[,] array, int moving_object, int move)
        {
            Graphics game_field = this.panel.CreateGraphics();//For drawing game field

            for (int i = 0, y = 0; i < 4; i++)
            {
                y = i * 100;

                for (int j = 0, x = 0; j < 4; j++)
                {
                    Bitmap temp;
                    string name = " ";

                    x = j * 100;

                    switch (array[i, j])
                    {
                        case 0: 
                            {
                                name = "space";
                                break;
                            }
                        case 1:
                            {
                                name = "one";
                                break;
                            }
                        case 2:
                            {
                                name = "two";
                                break;
                            }
                        case 3:
                            {
                                name = "three";
                                break;
                            }
                        case 4:
                            {
                                name = "four";
                                break;
                            }
                        case 5:
                            {
                                name = "five";
                                break;
                            }
                        case 6:
                            {
                                name = "six";
                                break;
                            }
                        case 7:
                            {
                                name = "seven";
                                break;
                            }
                        case 8:
                            {
                                name = "eight";
                                break;
                            }
                        case 9:
                            {
                                name = "nine";
                                break;
                            }
                        case 10:
                            {
                                name = "ten";
                                break;
                            }
                        case 11:
                            {
                                name = "eleven";
                                break;
                            }
                        case 12:
                            {
                                name = "twelve";
                                break;
                            }
                        case 13:
                            {
                                name = "thirteen";
                                break;
                            }
                        case 14:
                            {
                                name = "fourteen";
                                break;
                            }
                        case 15:
                            {
                                name = "fifteen";
                                break;
                            }
                    }

                    temp = new Bitmap(@"pictures\" + name + ".bmp");

                    if (array[i, j] == moving_object)
                    {
                        Bitmap space = new Bitmap(@"pictures\space.bmp");

                        switch (move)//Check for moving and direction
                        {
                            case (int)Direction.stay:
                                {
                                    break;
                                }
                            case (int)Direction.up:
                                {
                                    for (int a = 0; a <= 100; a++)
                                    {
                                        timer.Enabled = true;
                                        game_field.DrawImage(space, x, y);
                                        game_field.DrawImage(space, x, y + 100);
                                        game_field.DrawImage(temp, x, y + a);
                                    }
                                    timer.Enabled = false;

                                    space.Dispose();
                                    break;
                                }
                            case (int)Direction.down:
                                {
                                    for (int a = 0; a <= 100; a++)
                                    {
                                        timer.Enabled = true;
                                        game_field.DrawImage(space, x, y);
                                        game_field.DrawImage(space, x, y - 100);
                                        game_field.DrawImage(temp, x, y - a);
                                    }
                                    timer.Enabled = false;

                                    space.Dispose();
                                    break;
                                }
                            case (int)Direction.left:
                                {
                                    for (int a = 0; a <= 100; a++)
                                    {
                                        timer.Enabled = true;
                                        game_field.DrawImage(space, x, y);
                                        game_field.DrawImage(space, x + 100, y);
                                        game_field.DrawImage(temp, x + a, y);
                                    }
                                    timer.Enabled = false;

                                    space.Dispose();
                                    break;
                                }
                            case (int)Direction.right:
                                {
                                    for (int a = 0; a <= 100; a++)
                                    {
                                        timer.Enabled = true;
                                        game_field.DrawImage(space, x, y);
                                        game_field.DrawImage(space, x - 100, y);
                                        game_field.DrawImage(temp, x - a, y);
                                    }
                                    timer.Enabled = false;

                                    space.Dispose();
                                    break;
                                }
                        }
                        temp.Dispose();
                        break;

                    }
                    else
                    {
                        game_field.DrawImage(temp, x, y);
                        temp.Dispose();
                        break;
                    }


                    //for (int i = 0, y = 0; i < 4; i++)
                    //{
                    //    y = i * 100;

                    //    for (int j = 0, x = 0; j < 4; j++)
                    //    {
                    //        x = j * 100;

                    //        switch (array[i, j])
                    //        {
                    //            case 0:
                    //                {
                    //                    Bitmap space = new Bitmap(@"pictures\space.bmp");
                    //                    game_field.DrawImage(space, x, y);
                    //                    space.Dispose();
                    //                    break;
                    //                }
                    //            case 1:
                    //                {
                    //                    Bitmap one = new Bitmap(@"pictures\one.bmp");

                    //                    if (array[i, j] == moving_object)
                    //                    {
                    //                        Bitmap space = new Bitmap(@"pictures\space.bmp");

                    //                        switch (move)//Check for moving and direction
                    //                        {
                    //                            case (int)Direction.stay:
                    //                                {
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.up:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x, y + 100);
                    //                                        game_field.DrawImage(one, x, y + a);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.down:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x, y - 100);
                    //                                        game_field.DrawImage(one, x, y - a);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.left:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x + 100, y);
                    //                                        game_field.DrawImage(one, x + a, y);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.right:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x - 100, y);
                    //                                        game_field.DrawImage(one, x - a, y);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                        }
                    //                        one.Dispose();
                    //                        break;

                    //                    }
                    //                    else
                    //                    {
                    //                        game_field.DrawImage(one, x, y);
                    //                        one.Dispose();
                    //                        break;
                    //                    }
                    //                }
                    //            case 2:
                    //                {
                    //                    Bitmap two = new Bitmap(@"pictures\two.bmp");

                    //                    if (array[i, j] == moving_object)
                    //                    {
                    //                        Bitmap space = new Bitmap(@"pictures\space.bmp");

                    //                        switch (move)//Check for moving and direction
                    //                        {
                    //                            case (int)Direction.stay:
                    //                                {
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.up:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x, y + 100);
                    //                                        game_field.DrawImage(two, x, y + a);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.down:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x, y - 100);
                    //                                        game_field.DrawImage(two, x, y - a);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.left:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x + 100, y);
                    //                                        game_field.DrawImage(two, x + a, y);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                            case (int)Direction.right:
                    //                                {
                    //                                    for (int a = 0; a <= 100; a++)
                    //                                    {
                    //                                        timer.Enabled = true;
                    //                                        game_field.DrawImage(space, x, y);
                    //                                        game_field.DrawImage(space, x - 100, y);
                    //                                        game_field.DrawImage(two, x - a, y);
                    //                                    }
                    //                                    timer.Enabled = false;

                    //                                    space.Dispose();
                    //                                    break;
                    //                                }
                    //                        }
                    //                        two.Dispose();
                    //                        break;

                    //                    }
                    //                    else
                    //                    {
                    //                        game_field.DrawImage(two, x, y);
                    //                        two.Dispose();
                    //                        break;
                    //                    }

                    //                    game_field.DrawImage(two, x, y);
                    //                    two.Dispose();
                    //                    break;
                    //                }
                    //            case 3:
                    //                {
                    //                    Bitmap three = new Bitmap(@"pictures\three.bmp");
                    //                    game_field.DrawImage(three, x, y);
                    //                    three.Dispose();
                    //                    break;
                    //                }
                    //            case 4:
                    //                {
                    //                    Bitmap four = new Bitmap(@"pictures\four.bmp");
                    //                    game_field.DrawImage(four, x, y);
                    //                    four.Dispose();
                    //                    break;
                    //                }
                    //            case 5:
                    //                {
                    //                    Bitmap five = new Bitmap(@"pictures\five.bmp");
                    //                    game_field.DrawImage(five, x, y);
                    //                    five.Dispose();
                    //                    break;
                    //                }
                    //            case 6:
                    //                {
                    //                    Bitmap six = new Bitmap(@"pictures\six.bmp");
                    //                    game_field.DrawImage(six, x, y);
                    //                    six.Dispose();
                    //                    break;
                    //                }
                    //            case 7:
                    //                {
                    //                    Bitmap seven = new Bitmap(@"pictures\seven.bmp");
                    //                    game_field.DrawImage(seven, x, y);
                    //                    seven.Dispose();
                    //                    break;
                    //                }
                    //            case 8:
                    //                {
                    //                    Bitmap eight = new Bitmap(@"pictures\eight.bmp");
                    //                    game_field.DrawImage(eight, x, y);
                    //                    eight.Dispose();
                    //                    break;
                    //                }
                    //            case 9:
                    //                {
                    //                    Bitmap nine = new Bitmap(@"pictures\nine.bmp");
                    //                    game_field.DrawImage(nine, x, y);
                    //                    nine.Dispose();
                    //                    break;
                    //                }
                    //            case 10:
                    //                {
                    //                    Bitmap ten = new Bitmap(@"pictures\ten.bmp");
                    //                    game_field.DrawImage(ten, x, y);
                    //                    ten.Dispose();
                    //                    break;
                    //                }
                    //            case 11:
                    //                {
                    //                    Bitmap eleven = new Bitmap(@"pictures\eleven.bmp");
                    //                    game_field.DrawImage(eleven, x, y);
                    //                    eleven.Dispose();
                    //                    break;
                    //                }
                    //            case 12:
                    //                {
                    //                    Bitmap twelve = new Bitmap(@"pictures\twelve.bmp");
                    //                    game_field.DrawImage(twelve, x, y);
                    //                    twelve.Dispose();
                    //                    break;
                    //                }
                    //            case 13:
                    //                {
                    //                    Bitmap thirteen = new Bitmap(@"pictures\thirteen.bmp");
                    //                    game_field.DrawImage(thirteen, x, y);
                    //                    thirteen.Dispose();
                    //                    break;
                    //                }
                    //            case 14:
                    //                {
                    //                    Bitmap fourteen = new Bitmap(@"pictures\fourteen.bmp");
                    //                    game_field.DrawImage(fourteen, x, y);
                    //                    fourteen.Dispose();
                    //                    break;
                    //                }
                    //            case 15:
                    //                {
                    //                    Bitmap fifteen = new Bitmap(@"pictures\fifteen.bmp");
                    //                    game_field.DrawImage(fifteen, x, y);
                    //                    fifteen.Dispose();
                    //                    break;
                    //                }
                    //        }
                    //    }
                    //}
                    game_field.Dispose();
                }
            }
        }

        //Function is done faster than form is show
        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            first_draw();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            first_draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            draw(Field.field, 1, (int)Direction.up);
            Controller.move(Field.field, (int)Direction.up);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
