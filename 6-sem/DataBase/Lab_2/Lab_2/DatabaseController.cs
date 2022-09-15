using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Lab_2
{
    internal static class DatabaseController
    {
        static private SqlConnection connection;

        public static void DisplayTable(string table_name)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM " + table_name, connection);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                FormsController.StaticClearDataGridView();
                bool first_read = true;
                while (reader.Read())
                {
                    if (first_read)
                    {
                        first_read = false;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            FormsController.StaticGetDataGridView().Columns.Add(reader.GetName(i), reader.GetName(i));
                        }
                    }
                    string[] values = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        values[i] = reader.GetValue(i).ToString();
                    }
                    FormsController.StaticGetDataGridView().Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            connection.Close();
        }
        public static void ChangeData(string table_name, int id, string column_name, string data)  // Add\Edit data at cell
        {
            CellEditQuery(table_name, id, column_name, data);
            DisplayTable(table_name);
        }
        public static void ChangeData(string table_name, int id, string column_name) // Remove data at cell
        {
            CellEditQuery(table_name, id, column_name);
            DisplayTable(table_name);
        }
        public static void AddData(string table_name) // Add data to cell
        {
            InsertQuery(table_name);
            DisplayTable(table_name);
        }
        public static void RemoveLine(string table_name, int id)
        {
            Query("DELETE FROM " + table_name + " WHERE id = '" + id + "'");
            DisplayTable(table_name);
        }
        public static void InitConnection(string database_link_string)
        {
            try
            {
                connection = new SqlConnection(database_link_string);
                
                DataSet ds = new DataSet();
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
        }
        public static void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
        }
        public static void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
        }
        public static void CellEditQuery(string table_name, int id, string column_name, string data)  // Add/Edit data at cell
        {
            Query("UPDATE " + table_name +
                " SET " +
                column_name + " = '" + data +
                "' WHERE id = " + id);
        }
        public static void CellEditQuery(string table_name, int id, string column_name)  // Remove data at cell
        {
            Query("UPDATE " + table_name +
                  " SET " +
                  column_name + " = NULL WHERE id = " + id);
        }
        public static void InsertQuery(string table_name)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + table_name, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                string values = " VALUES (";
                for (int i = 1; i < reader.FieldCount; i++)
                {
                    values += "NULL,";
                }
                values = values.Remove(values.Length - 1, 1);
                values += ")";
                
                reader.Close();
                CloseConnection();

                Query("INSERT INTO " + table_name + values);
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            CloseConnection();
        }
        public static List<int> GetAllId(string table_name)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + table_name, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<int> all_id = new List<int>();
                while(reader.Read())
                {
                    all_id.Add(int.Parse(reader.GetString(0)));
                }

                reader.Close();
                CloseConnection();
                return all_id;
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
                CloseConnection();
                return null;
            }
        }
        public static void Query(string query)
        {
            try
            {
                OpenConnection();
                FormsController.ErrorMessage(query);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            CloseConnection();
        }
    }
}
