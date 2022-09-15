using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Lab_2
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            
        }
        public void ClearDataGridView()
        {
            if (this.display_table_datagridview.DataSource != null)
            {
                this.display_table_datagridview.DataSource = null;
            }
            else
            {
                this.display_table_datagridview.Rows.Clear();
                this.display_table_datagridview.Columns.Clear();
            }
        }
        public DataGridView GetDataGridView()
        {
            return display_table_datagridview;
        }
        public ListBox AvailableListBox
        {
            get
            {
                return available_choise_listBox;
            }
        }

        private void command_line_confirm_button_Click(object sender, EventArgs e)
        {
            FormsController.CustomQuery(command_line_textbox.Text);
            DatabaseController.DisplayTable(display_table_combobox.SelectedItem.ToString());
        }

        private void display_table_confirm_button_Click(object sender, EventArgs e)
        {
            if (display_table_combobox.SelectedItem.ToString() != "")
                FormsController.DisplayTableQuery(display_table_combobox.SelectedItem.ToString());
            DatabaseController.DisplayTable(display_table_combobox.SelectedItem.ToString());
        }

        private void display_table_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (display_table_combobox.SelectedItem.ToString() != "")
                FormsController.DisplayTableQuery(display_table_combobox.SelectedItem.ToString());
            DatabaseController.DisplayTable(display_table_combobox.SelectedItem.ToString());
        }

        private void display_table_datagridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = display_table_datagridview.CurrentCell.RowIndex;
            int column_index = display_table_datagridview.CurrentCell.ColumnIndex;

            if (display_table_datagridview[column_index, row_index].Value != null)
            {
                DatabaseController.ChangeData(display_table_combobox.SelectedItem.ToString(),
                    int.Parse(display_table_datagridview[0, row_index].Value.ToString()),
                    display_table_datagridview[column_index, 0].OwningColumn.Name.ToString(),
                    display_table_datagridview[column_index, row_index].Value.ToString());
            }
            else
            {
                DatabaseController.ChangeData(display_table_combobox.SelectedItem.ToString(),
                                    int.Parse(display_table_datagridview[0, row_index].Value.ToString()),
                                    display_table_datagridview[column_index, 0].OwningColumn.Name.ToString());
            }
            DatabaseController.DisplayTable(display_table_combobox.SelectedItem.ToString());
        }

        private void add_new_row_button_Click(object sender, EventArgs e)
        {
            DatabaseController.AddData(display_table_combobox.SelectedItem.ToString());
            DatabaseController.DisplayTable(display_table_combobox.SelectedItem.ToString());
        }

        private void remove_current_row_button_Click(object sender, EventArgs e)
        {
            DatabaseController.RemoveLine(display_table_combobox.SelectedItem.ToString(),
                int.Parse(display_table_datagridview[0, display_table_datagridview.CurrentCell.RowIndex].Value.ToString()));

            DatabaseController.DisplayTable(display_table_combobox.SelectedItem.ToString());
        }

        private void available_choise_button_Click(object sender, EventArgs e)
        {
            FormsController.ShowAvailableChoise(display_table_combobox.SelectedItem.ToString());
            DatabaseController.DisplayTable(display_table_combobox.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e) //To main menu button
        {
            FormsController.instance.OpenMainMenuForm();
        }
    }
}
