using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dziekanat.


namespace Dziekanat.UI
{
    public partial class Form1 : Form
    {
        StudentContext studentContext = new StudentContext();

        public Form1()
        {
            Dziekanat.DAL.StudentContext sc;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
