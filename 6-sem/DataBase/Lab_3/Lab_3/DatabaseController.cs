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
        const string sql_address = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Git\\Labs\\Labs_3_course\\6-sem\\DataBase\\Lab_3\\Lab_3\\MyDatabase.mdf;Integrated Security=True";
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
        public static List<List<(Type, string)>> GetTable(string table_name)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM " + table_name, connection);
            List<List<(Type, string)>> result = new List<List<(Type, string)>>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    List<(Type, string)> one_string = new List<(Type, string)>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        one_string.Add((reader.GetFieldType(i), reader.GetValue(i).ToString()));
                    result.Add(one_string);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            connection.Close();
            return result;
        }
        public static List<List<(Type, string)>> GetTableRow(string table_name, int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM " + table_name + " WHERE id=" + id.ToString(), connection);
            List<List<(Type, string)>> result = new List<List<(Type, string)>>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<(Type, string)> one_string = new List<(Type, string)>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        one_string.Add((reader.GetFieldType(i), reader.GetValue(i).ToString()));
                    result.Add(one_string);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            connection.Close();
            return result;
        }
        public static List<(int, string, bool, string)> GetBooks()  //..id..name..is_taken..
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Books" , connection);
            List<(int, string, bool, string)> result = new List<(int, string, bool, string)>();
            
            try
            {
                List<(int, string, bool)> id_name = new List<(int, string, bool)>();
                List<int> author_id = new List<int>();
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    id_name.Add((reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2)));
                reader.Close();

                command = new SqlCommand("SELECT * FROM AuthorsAndBooks", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    foreach ((int, string, bool) book in id_name)
                    {
                        if (reader.GetInt32(2) != book.Item1)
                            continue;

                        author_id.Add(reader.GetInt32(1));
                        break;
                    }
                }
                reader.Close();

                List<(int, int, string, string, string)> authors = GetIdentityOpenedConnection("Authors");
                List <string> authors_full_name = new List<string>();

                for (int i = 0; i < author_id.Count; i++)
                {
                    for (int j = 0; j < authors.Count; j++)
                    {
                        if (author_id[i] != authors[j].Item1)
                            continue;
                        authors_full_name.Add(authors[j].Item3 + " " + authors[j].Item4 + " " + authors[j].Item5);
                        break;
                    }
                }


                for (int i = 0; i < id_name.Count; i++)
                {
                    result.Add((id_name[i].Item1, id_name[i].Item2, id_name[i].Item3, authors_full_name[i]));
                }

            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            connection.Close();
            return result;
        }
        public static List<(int, int, string, string, string)> GetIdentityOpenedConnection(string table_name_id_identity) //Human id, identity id, first, second, middle
        {
            SqlCommand command = new SqlCommand("SELECT * FROM " + table_name_id_identity, connection);
            List<(int, int, string, string, string)> result = new List<(int, int, string, string, string)>();
            try
            {

                List<List<int>> library_employees = new List<List<int>>();
                List<List<int>> identity_cards = new List<List<int>>();
                List<string> first_names = new List<string>();
                List<string> second_names = new List<string>();
                List<string> middle_names = new List<string>();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    library_employees.Add(new List<int>());
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        library_employees[library_employees.Count - 1].Add(reader.GetInt32(i));
                    }
                }
                reader.Close();

                command = new SqlCommand("SELECT * FROM " + "IdentityCards", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < library_employees.Count; i++)
                    {
                        int identity_card_id = library_employees[i][1];

                        if (reader.GetInt32(0) != identity_card_id)
                            continue;

                        identity_cards.Add(new List<int>());
                        identity_cards[identity_cards.Count - 1].Add(reader.GetInt32(1)); //first_name
                        identity_cards[identity_cards.Count - 1].Add(reader.GetInt32(2)); //second_name
                        identity_cards[identity_cards.Count - 1].Add(reader.GetInt32(3)); //middle_name

                        break;
                    }
                reader.Close();


                command = new SqlCommand("SELECT * FROM " + "FirstNames", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < identity_cards.Count; i++)
                    {
                        int first_name_id = identity_cards[i][0];

                        if (reader.GetInt32(0) != first_name_id)
                            continue;

                        first_names.Add(reader.GetString(1));
                        break;
                    }
                reader.Close();


                command = new SqlCommand("SELECT * FROM " + "SecondNames", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < identity_cards.Count; i++)
                    {
                        int second_name_id = identity_cards[i][1];

                        if (reader.GetInt32(0) != second_name_id)
                            continue;

                        second_names.Add(reader.GetString(1));
                        break;
                    }
                reader.Close();


                command = new SqlCommand("SELECT * FROM " + "MiddleNames", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < identity_cards.Count; i++)
                    {
                        int middle_name_id = identity_cards[i][2];

                        if (reader.GetInt32(0) != middle_name_id)
                            continue;

                        middle_names.Add(reader.GetString(1));
                        break;
                    }
                reader.Close();
                for (int i = 0; i < library_employees.Count; i++)
                {
                    result.Add((library_employees[i][0], library_employees[i][1], first_names[i], second_names[i], middle_names[i]));
                }
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            return result;
        }
        public static List<(int, int, string, string, string)> GetIdentity(string table_name_id_identity) //Human id, identity id, first, second, middle
        {
            SqlCommand command = new SqlCommand("SELECT * FROM " + table_name_id_identity, connection);
            List<(int, int, string, string, string)> result = new List<(int, int, string, string, string)>();
            try
            {
                
                List<List<int>> library_employees = new List<List<int>>();
                List<List<int>> identity_cards = new List<List<int>>();
                List<string> first_names = new List<string>();
                List<string> second_names = new List<string>();
                List<string> middle_names = new List<string>();

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    library_employees.Add(new List<int>());
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        library_employees[library_employees.Count - 1].Add(reader.GetInt32(i));
                    }
                }
                reader.Close();

                command = new SqlCommand("SELECT * FROM " + "IdentityCards", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < library_employees.Count; i++)
                    {
                        int identity_card_id = library_employees[i][1];

                        if (reader.GetInt32(0) != identity_card_id)
                            continue;

                        identity_cards.Add(new List<int>());
                        identity_cards[identity_cards.Count - 1].Add(reader.GetInt32(1)); //first_name
                        identity_cards[identity_cards.Count - 1].Add(reader.GetInt32(2)); //second_name
                        identity_cards[identity_cards.Count - 1].Add(reader.GetInt32(3)); //middle_name

                        break;
                    }
                reader.Close();


                command = new SqlCommand("SELECT * FROM " + "FirstNames", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < identity_cards.Count; i++)
                    {
                        int first_name_id = identity_cards[i][0];

                        if (reader.GetInt32(0) != first_name_id)
                            continue;

                        first_names.Add(reader.GetString(1));
                        break;
                    }
                reader.Close();


                command = new SqlCommand("SELECT * FROM " + "SecondNames", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < identity_cards.Count; i++)
                    {
                        int second_name_id = identity_cards[i][1];

                        if (reader.GetInt32(0) != second_name_id)
                            continue;

                        second_names.Add(reader.GetString(1));
                        break;
                    }
                reader.Close();


                command = new SqlCommand("SELECT * FROM " + "MiddleNames", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < identity_cards.Count; i++)
                    {
                        int middle_name_id = identity_cards[i][2];

                        if (reader.GetInt32(0) != middle_name_id)
                            continue;

                        middle_names.Add(reader.GetString(1));
                        break;
                    }
                reader.Close();
                for (int i = 0; i < library_employees.Count; i++)
                {
                    result.Add((library_employees[i][0], library_employees[i][1], first_names[i], second_names[i], middle_names[i]));
                }
            }
            catch (Exception ex)
            {
                FormsController.ErrorMessage(ex.Message);
            }
            connection.Close();
            return result;
        }
        public static void ChangeData(string table_name, int id, string column_name, string data)  // Add\Edit data at cell
        {
            CellEditQuery(table_name, id, column_name, data);
            //DisplayTable(table_name);
        }
        public static void ChangeData(string table_name, int id, string column_name) // Remove data at cell
        {
            CellEditQuery(table_name, id, column_name);
            //DisplayTable(table_name);
        }
        public static void AddData(string table_name) // Add data to cell
        {
            InsertQuery(table_name);
            //DisplayTable(table_name);
        }
        public static void RemoveLine(string table_name, int id)
        {
            Query("DELETE FROM " + table_name + " WHERE id = '" + id + "'");
            //DisplayTable(table_name);
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
        public static void InitConnection()
        {
            try
            {
                connection = new SqlConnection(sql_address);

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
                //FormsController.ErrorMessage(query);
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
