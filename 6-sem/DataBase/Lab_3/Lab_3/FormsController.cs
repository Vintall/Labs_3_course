using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    internal class FormsController
    {
        public static FormsController instance;
        MainForm main_form;
        LibrarianLogin librarian_login_form;
        LibrarianMain librarian_main_form;
        MainMenu main_menu_form;
        BookHandle book_handle_form;

        public MainForm MainForm
        {
            get
            {
                return main_form;
            }
        }
        public BookHandle BookHandle
        {
            get
            {
                return book_handle_form;
            }
        }
        public LibrarianLogin LibrarianLoginForm
        {
            get
            {
                return librarian_login_form;
            }
        }
        public LibrarianMain LibrarianMainForm
        {
            get
            {
                return librarian_main_form;
            }
        }
        public MainMenu MainMenuForm
        {
            get
            {
                return main_menu_form;
            }
        }
        public FormsController()
        {
            instance = this;
            OpenMainMenuForm();
        }
        public void CloseAllForms()
        {
            if (main_menu_form != null)
                main_menu_form.Close();

            if (main_form != null)
                main_form.Close();

            if (librarian_login_form != null)
                librarian_login_form.Close();

            if (librarian_main_form != null)
                librarian_main_form.Close();

            if (book_handle_form != null)
                book_handle_form.Close();
        }
        public void OpenBookHandleForm(int librarian, BookHandle.CardType type, int id)
        {
            CloseAllForms();
            book_handle_form = new BookHandle(librarian, type, id);
            book_handle_form.Show();
        }
        public void OpenMainMenuForm()
        {
            CloseAllForms();
            main_menu_form = new MainMenu();
            main_menu_form.Show();
        }
        public void OpenMainForm()
        {
            CloseAllForms();
            main_form = new MainForm();
            main_form.Show();
        }
        public void OpenLibrarianLoginForm()
        {
            CloseAllForms();
            librarian_login_form = new LibrarianLogin();
            librarian_login_form.Show();
        }
        public void OpenLibrarianMainForm(int librarian)
        {
            CloseAllForms();
            librarian_main_form = new LibrarianMain(librarian);
            librarian_main_form.Show();
        }

        public static void CustomQuery(string query)
        {
            DatabaseController.Query(query);
        }
        public static void DisplayTableQuery(string query)
        {
            DatabaseController.DisplayTable(query);
        }
        public static void DisplayTable()
        {

        }
        public static void ShowAvailableChoise(string table_name)
        {
            instance.MainForm.AvailableListBox.Items.Clear();
            List<int> all_id_list = DatabaseController.GetAllId(table_name);

            foreach(int id in all_id_list)
            {
                instance.MainForm.AvailableListBox.Items.Add(id.ToString());
            }
        }
        public static void StaticClearDataGridView()
        {
            instance.ClearDataGridView();
        }
        void ClearDataGridView()
        {
            main_form.ClearDataGridView();
        }
        public static DataGridView StaticGetDataGridView()
        {
            return instance.GetDataGridView();   
        }
        DataGridView GetDataGridView()
        {
            return main_form.GetDataGridView();
        }
        
        public static void ErrorMessage(string error)
        {
            instance.ShowErrorMessage(error);
        }
        void ShowErrorMessage(string error)
        {
            MessageBox.Show(error);
        }
    }
}
