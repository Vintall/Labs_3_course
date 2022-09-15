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
    public partial class LibrarianLogin : Form
    {
        public LibrarianLogin()
        {
            InitializeComponent();
            ShowList();
        }

        private void button1_Click(object sender, EventArgs e) //To Main Menu
        {
            FormsController.instance.OpenMainMenuForm();
        }

        private void button2_Click(object sender, EventArgs e) //Login Button
        {
            if (available_choise_listBox.Items.Count == 0)
                return;

            if (available_choise_listBox.SelectedItems.Count != 1)
                return;

            FormsController.instance.OpenLibrarianMainForm(int.Parse(available_choise_listBox.SelectedItem.ToString().Split('[',';')[1]));
        }
        public void ShowList()
        {
            List<(int, int, string, string, string)> list = DatabaseController.GetIdentity("LibraryEmproyees");

            available_choise_listBox.Items.Clear();

            foreach ((int, int, string, string, string) librarian in list)
                available_choise_listBox.Items.Add("[" + librarian.Item1.ToString() + "; " + librarian.Item2.ToString() + "]: " + librarian.Item3 + " " + librarian.Item4 + " " + librarian.Item5);

            available_choise_listBox.Refresh();
        }
        private void available_choise_button_Click(object sender, EventArgs e)
        {
            ShowList();
        }

        private void available_choise_listBox_DoubleClick(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }
    }
}
