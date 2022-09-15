using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Admin
        {
            FormsController.instance.OpenMainForm();
        }

        private void button2_Click(object sender, EventArgs e) //Librarian
        {
            FormsController.instance.OpenLibrarianLoginForm();
        }

        private void button3_Click(object sender, EventArgs e) //Exit
        {
            Application.Exit();
        }
    }
}
