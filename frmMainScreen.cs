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
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public frmMainScreen()
        {
            InitializeComponent();
            Controller.create();//We create new game field in matrix form
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        void first_draw()
        {
            draw(Controller.game_field(), (int)Direction.stay);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //public void draw(int[,] array, int moving_object, int move)
        public void draw(int[,] array, int move)
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

                    //if (array[i, j] == moving_object)
                    if(move != (int)Direction.stay)
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
                    }
                    else
                    {
                        game_field.DrawImage(temp, x, y);
                        temp.Dispose();
                    }
                }
            }
                    game_field.Dispose();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //Function is done faster than form is show
        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            first_draw();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnStart_Click(object sender, EventArgs e)
        {
            Controller.create();//We create new game field in matrix form

            first_draw();

            

            //while (Controller.win_check() != "In process...")
            //{
            //    Controller.next_step();
            //}
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void button2_Click(object sender, EventArgs e)
        {
            int direction = Controller.next_step();
            draw(Controller.game_field(), direction);
            Controller.move(Controller.game_field(), direction);
            draw(Controller.game_field(), (int)Direction.stay);

        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
