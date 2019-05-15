using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    class DBCon
    {
        private static string login;
        private static string pass;
        private static SqlDataReader reader;

       
        public DBCon()
        {
            login = null;
            pass = null;
        }
        public DBCon(string l, string p)
        {
            login = l;
            pass = p;
        }
        public static SqlDataReader DBConnection(string tsql)
        {
            try
            {
                string var = ConfigurationManager.ConnectionStrings["WpfApp.Properties.Settings.localDBConnectionString"].ConnectionString;
                var connection = new SqlConnection(var);
                SqlConnection connClone = new SqlConnection(var);
                connClone.Open();
                var command = new SqlCommand(tsql, connClone);
                reader = command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return reader;
        }
        public void AddExt(string tsql)
        {
            DBConnection(tsql);
            reader.Read();
            reader.Close();
        }
        public static void UpdateIdentity()
        {
            string tsql = @"DBCC CHECKIDENT ('[Customers]', RESEED, 0)";
            DBConnection(tsql);
            reader.Read();
            reader.Close();
        }
        public static void AddItemExt(MyTable table)
        {
            int i = table.Num + 1;
            if (table.Num < 5)
            {
                string tsql = @"UPDATE [Customers] SET num_ext='" + i + "' WHERE Id='" + table.Id + "'";
                try
                {
                    DBCon con = new DBCon();
                    con.AddExt(tsql);
                    MessageBox.Show("update");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Already use all ext");
        }
        public static void DelItemExt(MyTable table)
        {
            string tsql = @"UPDATE [Customers] SET num_ext='0' WHERE Id='" + table.Id + "'";
            try
            {
                DBCon con = new DBCon();
                con.AddExt(tsql);
                MessageBox.Show("update");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void Delete(MyTable t)
        {
            string surname = Convert.ToString(t.Surname.Trim());
            string name = Convert.ToString(t.Name.Trim());
            string tsql = @"DELETE FROM [Customers] WHERE Surname='" + surname + "' AND Name='" + name + "' AND Id='" + t.Id + "'";
            try
            {
                DBConnection(tsql);
                reader.Read();
                reader.Close();
                UpdateIdentity();
                MessageBox.Show("Customer deleted");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Add(MyTable table)
        {
            string tsql = @"INSERT INTO [Customers]
                    VALUES('" + table.Surname + "', '" + table.Name + "'," +
                   "'" + table.Type + "', '" + table.FLy + "', '" + table.Days + "'," +
                   "'" + table.Ex1_start + "', '"+ table.Ex1_end +"'," +
                   "'" + table.Ex2_start + "', '" + table.Ex2_end + "'," +
                   "'" + table.Ex3_start + "', '" + table.Ex3_end + "'," +
                   "'" + table.Ex4_start + "', '" + table.Ex4_end + "'," +
                   "'" + table.Fly_out + "', '" + table.Num + "')";
            DBConnection(tsql);
            reader.Read();
            reader.Close();
        }
        public static ObservableCollection<MyTable> Grid()
        {
            string tsql = @"SELECT * FROM [Customers]";
            reader = DBConnection(tsql);
            ObservableCollection<MyTable> data = new ObservableCollection<MyTable>();
            while (reader.Read())
            {
                data.Add(new MyTable(
                    int.Parse(reader[0].ToString()),
                    reader[1].ToString(), reader[2].ToString(),
                     reader[3].ToString(), DateTime.Parse(reader[4].ToString()),
                     int.Parse(reader[5].ToString()),
                     reader[6].ToString(), reader[7].ToString(),
                     reader[8].ToString(), reader[9].ToString(),
                     reader[10].ToString(), reader[11].ToString(), 
                     reader[12].ToString(), reader[13].ToString(),
                     reader[14].ToString(), int.Parse(reader[15].ToString())));
            }
            reader.Close();
            return data;
        }
        public ObservableCollection<Users> Users()
        {
            string tsql = @"SELECT * FROM [Users]";
            DBConnection(tsql);
            ObservableCollection<Users> data = new ObservableCollection<Users>();
            while (reader.Read())
            {
                data.Add(new Users(reader[0].ToString(), reader[1].ToString(),
                    int.Parse(reader[2].ToString())));
            }
            reader.Close();
            return data;
        }
        public static void Password(string l, string p)
        {
            login = l.Trim();
            pass = p.Trim();
            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(pass))
            {
                try
                {  
                    string tsql = @"SELECT * FROM [Users] WHERE login = '" + login + "'";
                    SqlDataReader reader1 = DBConnection(tsql);
                    bool ans;
                    reader1.Read();
                    if (reader1.HasRows)
                    {
                        ans = HashPass.VerifyHashedPassword(reader1[1].ToString(), pass);
                        if ((ans == false) || reader1.IsClosed)
                        {
                            throw new Exception("Wrong password!");
                        }
                        else
                        {
                            Window2 win = new Window2();
                            if (int.Parse(reader1[2].ToString()) == 0)
                            {
                                win.btn1.Visibility = Visibility.Hidden;
                                win.btn2.Visibility = Visibility.Hidden;
                                win.btn2.Visibility = Visibility.Hidden;
                            }
                            reader1.Close();
                            win.ShowDialog();
                        }
                        reader1.Close();
                    }
                    else
                    {
                        throw new Exception("Wrong Login!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Empty line!!");
           
        }
    }
}
