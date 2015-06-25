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
    public partial class frmMainScreen : Form
    {
        clController Controller = new clController();

        clField Main = new clField();//Main class wich will contain all information about game: number of steps, status and field status

        public frmMainScreen()
        {
            InitializeComponent();
            Controller.create(Main.field);//We create new game field in matrix form
        }

        void first_draw()
        {
            draw(Main.field);
        }

        void draw(int[,] array)
        {
            
            Graphics game_field = this.panel.CreateGraphics();//For drawing game field

            for (int i = 0, y = 0; i < 4; i++)
            {
                y = i * 100;

                for (int j = 0, x = 0; j < 4; j++)
                {
                    x = j * 100;

                    switch (array[i, j])
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                Bitmap one = new Bitmap(@"pictures\one.bmp");
                                game_field.DrawImage(one, x, y);
                                one.Dispose();
                                break;
                            }
                        case 2:
                            {
                                Bitmap two = new Bitmap(@"pictures\two.bmp");
                                game_field.DrawImage(two, x, y);
                                two.Dispose();
                                break;
                            }
                        case 3:
                            {
                                Bitmap three = new Bitmap(@"pictures\three.bmp");
                                game_field.DrawImage(three, x, y);
                                three.Dispose();
                                break;
                            }
                        case 4:
                            {
                                Bitmap four = new Bitmap(@"pictures\four.bmp");
                                game_field.DrawImage(four, x, y);
                                four.Dispose();
                                break;
                            }
                        case 5:
                            {
                                Bitmap five = new Bitmap(@"pictures\five.bmp");
                                game_field.DrawImage(five, x, y);
                                five.Dispose();
                                break;
                            }
                        case 6:
                            {
                                Bitmap six = new Bitmap(@"pictures\six.bmp");
                                game_field.DrawImage(six, x, y);
                                six.Dispose();
                                break;
                            }
                        case 7:
                            {
                                Bitmap seven = new Bitmap(@"pictures\seven.bmp");
                                game_field.DrawImage(seven, x, y);
                                seven.Dispose();
                                break;
                            }
                        case 8:
                            {
                                Bitmap eight = new Bitmap(@"pictures\eight.bmp");
                                game_field.DrawImage(eight, x, y);
                                eight.Dispose();
                                break;
                            }
                        case 9:
                            {
                                Bitmap nine = new Bitmap(@"pictures\nine.bmp");
                                game_field.DrawImage(nine, x, y);
                                nine.Dispose();
                                break;
                            }
                        case 10:
                            {
                                Bitmap ten = new Bitmap(@"pictures\ten.bmp");
                                game_field.DrawImage(ten, x, y);
                                ten.Dispose();
                                break;
                            }
                        case 11:
                            {
                                Bitmap eleven = new Bitmap(@"pictures\eleven.bmp");
                                game_field.DrawImage(eleven, x, y);
                                eleven.Dispose();
                                break;
                            }
                        case 12:
                            {
                                Bitmap twelve = new Bitmap(@"pictures\twelve.bmp");
                                game_field.DrawImage(twelve, x, y);
                                twelve.Dispose();
                                break;
                            }
                        case 13:
                            {
                                Bitmap thirteen = new Bitmap(@"pictures\thirteen.bmp");
                                game_field.DrawImage(thirteen, x, y);
                                thirteen.Dispose();
                                break;
                            }
                        case 14:
                            {
                                Bitmap fourteen = new Bitmap(@"pictures\fourteen.bmp");
                                game_field.DrawImage(fourteen, x, y);
                                fourteen.Dispose();
                                break;
                            }
                        case 15:
                            {
                                Bitmap fifteen = new Bitmap(@"pictures\fifteen.bmp");
                                game_field.DrawImage(fifteen, x, y);
                                fifteen.Dispose();
                                break;
                            }
                    }
                }
            }
            game_field.Dispose();
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            first_draw();
            MessageBox.Show("Все оке", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            first_draw();
        }
    }
}
