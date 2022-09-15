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
        public MainForm MainForm
        {
            get
            {
                return main_form;
            }
            set
            {
                main_form = value;
            }
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
        public FormsController()
        {
            instance = this;
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
