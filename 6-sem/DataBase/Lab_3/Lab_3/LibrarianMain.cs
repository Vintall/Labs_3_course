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
    public partial class LibrarianMain : Form
    {
        int current_librarian;
        public LibrarianMain(int librarian)
        {
            InitializeComponent();
            current_librarian = librarian;

            List<(int, int, string, string, string)> list = DatabaseController.GetIdentity("LibraryEmproyees");

            foreach((int, int, string, string, string) lib in list)
            {
                if (lib.Item1 != current_librarian)
                    continue;

                label7.Text = lib.Item3 + " " + lib.Item4 + " " + lib.Item5;
                break;
            }

            

            button2_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e) //To Main Menu
        {
            FormsController.instance.OpenMainMenuForm();
        }
        private void button2_Click(object sender, EventArgs e) //Search Button
        {
            List<(int, int, string, string, string)> students_list = DatabaseController.GetIdentity("Students");
            List<(int, int, string, string, string)> teachers_list = DatabaseController.GetIdentity("Teachers");

            display_table_datagridview.Rows.Clear();
            display_table_datagridview.Columns.Clear();

            display_table_datagridview.Columns.Add("Type", "Type");
            display_table_datagridview.Columns.Add("Id", "Id");
            display_table_datagridview.Columns.Add("FirstName",  "FirstName");
            display_table_datagridview.Columns.Add("MiddleName", "MiddleName");
            display_table_datagridview.Columns.Add("SecondName", "SecondName");


            if (checkBox4.Checked)
                foreach ((int, int, string, string, string) student in students_list)
                {
                    if (checkBox1.Checked)
                        if (student.Item3 != textBox1.Text)
                            continue;

                    if (checkBox2.Checked)
                        if (student.Item4 != textBox2.Text)
                            continue;

                    if (checkBox3.Checked)
                        if (student.Item5 != textBox3.Text)
                            continue;

                    display_table_datagridview.Rows.Add("Student", "[" + student.Item1 + "; " + student.Item2 + "]", student.Item3, student.Item4, student.Item5);
                }
            if (checkBox5.Checked)
                foreach ((int, int, string, string, string) teacher in teachers_list)
                {
                    if (checkBox1.Checked)
                        if (teacher.Item3 != textBox1.Text)
                            continue;

                    if (checkBox2.Checked)
                        if (teacher.Item4 != textBox2.Text)
                            continue;

                    if (checkBox3.Checked)
                        if (teacher.Item5 != textBox3.Text)
                            continue;

                    display_table_datagridview.Rows.Add("Teacher", "[" + teacher.Item1 + "; " + teacher.Item2 + "]", teacher.Item3, teacher.Item4, teacher.Item5);
                }
            display_table_datagridview.AutoResizeColumns();
            display_table_datagridview.AutoResizeRows();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (display_table_datagridview.SelectedRows.Count != 1)
                return;

            BookHandle.CardType type = BookHandle.CardType.Student;

            string type_cell = display_table_datagridview.SelectedRows[0].Cells[0].Value.ToString();
            string[] splitted = display_table_datagridview.SelectedRows[0].Cells[1].Value.ToString().Split('[', ';');
            int id_cell = int.Parse(splitted[1]);

            if (type_cell == "Student")
                type = BookHandle.CardType.Student;
            else 
            if (type_cell == "Teacher")
                type = BookHandle.CardType.Teacher;

            FormsController.instance.OpenBookHandleForm(current_librarian, type, id_cell);
        }
    }
}
