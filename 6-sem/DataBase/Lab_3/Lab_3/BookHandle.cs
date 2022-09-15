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
    public partial class BookHandle : Form
    {
        int current_librarian;
        CardType type;
        int current_user;
        public BookHandle(int librarian, CardType type, int id)
        {
            InitializeComponent();
            current_librarian = librarian;
            this.type = type;
            current_user = id;
            List<(int, int, string, string, string)> list = DatabaseController.GetIdentity("LibraryEmproyees");

            foreach ((int, int, string, string, string) lib in list)
            {
                if (lib.Item1 != current_librarian)
                    continue;

                label3.Text = lib.Item3 + " " + lib.Item4 + " " + lib.Item5;
                break;
            }
            if (type == CardType.Student)
            {
                list = DatabaseController.GetIdentity("Students");
                label6.Text = "[Student]";
            }
            else
            {
                list = DatabaseController.GetIdentity("Teachers");
                label6.Text = "[Teacher]";
            }

            foreach ((int, int, string, string, string) lib in list)
            {
                if (lib.Item1 != id)
                    continue;

                label4.Text = lib.Item3 + " " + lib.Item4 + " " + lib.Item5;
                break;
            }
            button2_Click_1(null, null);
        }
        public enum CardType
        {
            Student,
            Teacher
        }
        private void button1_Click(object sender, EventArgs e) //To main menu
        {
            FormsController.instance.OpenMainMenuForm();
        }
        bool table_mode = false; // ....FALSE - books in library.... // ....TRUE - books in card.... //
        
        void ChangedToLibrary()
        {
            label8.Text = "Library Books";
            button2.Text = "Change to Card Books";
            button3.Text = "Give The Book";
            

            List<(int, string, bool, string)> list = DatabaseController.GetBooks();


            display_table_datagridview.Rows.Clear();
            display_table_datagridview.Columns.Clear();

            display_table_datagridview.Columns.Add("id", "id");
            display_table_datagridview.Columns.Add("name", "name");
            display_table_datagridview.Columns.Add("author", "author");
            display_table_datagridview.Columns.Add("taken", "taken");

            foreach((int, string, bool, string) book in list)
            {

                display_table_datagridview.Rows.Add(book.Item1, book.Item2, book.Item4, book.Item3);
            }
        }
        void ChangedToCard()
        {
            label8.Text = "Card Books";
            button2.Text = "Change to Library Books";
            button3.Text = "Take The Book Back";

            List<(int, string, bool, string)> list = DatabaseController.GetBooks();
            List<List<(Type, string)>> lib_cards_and_books = DatabaseController.GetTable("LibraryCardsAndBooks");

            display_table_datagridview.Rows.Clear();
            display_table_datagridview.Columns.Clear();

            display_table_datagridview.Columns.Add("id", "id");
            display_table_datagridview.Columns.Add("name", "name");
            display_table_datagridview.Columns.Add("author", "author");

            if (type == CardType.Student)
            {
                List<List<(Type, string)>> list_students_cards = DatabaseController.GetTable("StudentCards");

                int student_card = -1;
                for (int i = 0; i < list_students_cards.Count; i++)
                {
                    if (int.Parse(list_students_cards[i][2].Item2) != current_user)
                        continue;
                    student_card = int.Parse(list_students_cards[i][0].Item2);
                    break;
                }

                for (int i = 0; i < lib_cards_and_books.Count; i++)
                {
                    if (int.Parse(lib_cards_and_books[i][1].Item2) != student_card)
                        continue;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Item1 != int.Parse(lib_cards_and_books[i][3].Item2))
                            continue;

                        

                        display_table_datagridview.Rows.Add(list[j].Item1, list[j].Item2, list[j].Item4, list[j].Item3);

                        break;
                    }
                }
            }
            else
            {
                List<List<(Type, string)>> list_teachers_cards = DatabaseController.GetTable("TeacherCards");

                int teacher_card = -1;
                for (int i = 0; i < list_teachers_cards.Count; i++)
                {
                    if (int.Parse(list_teachers_cards[i][1].Item2) != current_user)
                        continue;
                    teacher_card = int.Parse(list_teachers_cards[i][0].Item2);
                    break;
                }

                for (int i = 0; i < lib_cards_and_books.Count; i++)
                {
                    if (int.Parse(lib_cards_and_books[i][2].Item2) != teacher_card)
                        continue;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Item1 != int.Parse(lib_cards_and_books[i][3].Item2))
                            continue;

                        display_table_datagridview.Rows.Add(list[j].Item1, list[j].Item2, list[j].Item4, list[j].Item3);

                        break;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //Take-give book button
        {
            if (display_table_datagridview.SelectedRows.Count != 1)
                return;

            if (table_mode) // LibraryCard
            {
                List<List<(Type, string)>> library_cards_and_books = DatabaseController.GetTable("LibraryCardsAndBooks");
                int book_id = int.Parse(display_table_datagridview.SelectedRows[0].Cells[0].Value.ToString());

                foreach (List<(Type, string)> lib_card in library_cards_and_books)
                {
                    if (int.Parse(lib_card[3].Item2) != book_id)
                        continue;

                    int lib_card_id = int.Parse(lib_card[0].Item2);
                    DatabaseController.RemoveLine("LibraryCardsAndBooks", lib_card_id);
                    DatabaseController.ChangeData("Books", book_id, "taken", "FALSE");
                    break;
                }
            }
            else  //Library
            {
                if (display_table_datagridview.SelectedRows[0].Cells[3].ToString() != "False" &&
                    (bool)(display_table_datagridview.SelectedRows[0].Cells[3].Value) != false) 
                    return;
                int book_id = int.Parse(display_table_datagridview.SelectedRows[0].Cells[0].Value.ToString());
                DatabaseController.ChangeData("Books", book_id, "taken", "TRUE");

                if (type == CardType.Student)
                {
                    List<List<(Type, string)>> list_students_cards = DatabaseController.GetTable("StudentCards");
                    int student_card;

                    for (int i = 0; i < list_students_cards.Count; i++)
                    {
                        if (int.Parse(list_students_cards[i][2].Item2) != current_user)
                            continue;

                        student_card = int.Parse(list_students_cards[i][0].Item2);
                        DatabaseController.Query("INSERT INTO LibraryCardsAndBooks VALUES (" + student_card.ToString() + ",NULL," + book_id.ToString() + "," + current_librarian+")");
                        break;
                    }
                }
                else
                {
                    List<List<(Type, string)>> list_teachers_cards = DatabaseController.GetTable("TeacherCards");

                    int teacher_card;

                    for (int i = 0; i < list_teachers_cards.Count; i++)
                    {
                        if (int.Parse(list_teachers_cards[i][1].Item2) != current_user)
                            continue;

                        teacher_card = int.Parse(list_teachers_cards[i][0].Item2);
                        DatabaseController.Query("INSERT INTO LibraryCardsAndBooks VALUES (NULL," + teacher_card.ToString() + "," + book_id.ToString() + "," + current_librarian + ")");
                        break;
                    }
                }

            }
        }

        private void button2_Click_1(object sender, EventArgs e) //Change table mode
        {
            table_mode = !table_mode;

            if (table_mode)
            {
                ChangedToCard();
            }
            else
            {
                ChangedToLibrary();
            }
        }
    }
}
