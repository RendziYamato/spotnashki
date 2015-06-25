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

        clMain Main = new clMain();//Main class wich will contain all information about game: number of steps, status and field status

        public frmMainScreen()
        {
            InitializeComponent();
            Main.Field = Controller.create(Main.Field);//We create new game field in matrix form
        }

        void first_draw()
        {
            draw(Main.Field);
        }

        void draw(int[] array)
        {
            Graphics game_field = this.panel.CreateGraphics();//For drawing game field

            Bitmap one = new Bitmap(@"pictures\one.bmp");
            //Bitmap two = new Bitmap(@"figurs\two.bmp");
            //Bitmap three = new Bitmap(@"figurs\three.bmp");
            //Bitmap four = new Bitmap(@"figurs\four.bmp");
            //Bitmap five = new Bitmap(@"figurs\five.bmp");
            //Bitmap six = new Bitmap(@"figurs\six.bmp");
            //Bitmap seven = new Bitmap(@"figurs\seven.bmp");
            //Bitmap eight = new Bitmap(@"figurs\eight.bmp");
            //Bitmap nine = new Bitmap(@"figurs\nine.bmp");
            //Bitmap ten = new Bitmap(@"figurs\ten.bmp");
            //Bitmap eleven = new Bitmap(@"figurs\eleven.bmp");
            //Bitmap twelve = new Bitmap(@"figurs\twelve.bmp");
            //Bitmap thirteen = new Bitmap(@"figurs\thirteen.bmp");
            //Bitmap fourteen = new Bitmap(@"figurs\fourteen.bmp");
            //Bitmap fivteen = new Bitmap(@"figurs\fivteen.bmp");

           // Bitmap temp;
            game_field.DrawImage(one, 0, 0);

            one.Dispose();

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
