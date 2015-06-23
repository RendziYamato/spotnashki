using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spotnashki
{
    public partial class frmMainScreen : Form
    {
        clController Controller = new clController();

        public frmMainScreen()
        {
            InitializeComponent();
            Controller.create();

        }
    }
}
