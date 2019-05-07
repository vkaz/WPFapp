using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class DBCon
    {
        private readonly string login;
        private readonly string pass;
        private SqlDataReader reader;
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
        public void DBConnection(string tsql)
        {
            try
            {
                string var = ConfigurationManager.ConnectionStrings["WpfApp.Properties.Settings.localDBConnectionString"].ConnectionString;
                var connection = new SqlConnection(var);
                connection.Open();
                var command = new SqlCommand(tsql, connection);
                reader = command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddExt(string tsql)
        {
            DBConnection(tsql);
            reader.Read();
            reader.Close();
        }
        public void UpdateIdentity()
        {
            string tsql = @"DBCC CHECKIDENT ('[Customers]', RESEED, 0)";
            DBConnection(tsql);
            reader.Read();
            reader.Close();
        }
        public void Delete(string tsql)
        {
            DBConnection(tsql);
            reader.Read();
            reader.Close();
            UpdateIdentity();
        }
        public void Add(MyTable table, string tsql)
        {
            tsql = @"INSERT INTO [Customers]
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
        public List<MyTable> Grid(string tsql)
        { 
            DBConnection(tsql);
            List<MyTable> data = new List<MyTable>();
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
        public List<Users> Users(string tsql)
        {
            DBConnection(tsql);
            List<Users> data = new List<Users>();
            while (reader.Read())
            {
                data.Add(new Users(reader[0].ToString(),
                    int.Parse(reader[2].ToString())));
            }
            reader.Close();
            return data;
        }
        public void Password(string tsql)
        {
            DBConnection(tsql);
            bool ans;
            reader.Read();
            if (reader.HasRows)
            {
                ans = HashPass.VerifyHashedPassword(reader[1].ToString(), pass);
                if ((ans == false) || reader.IsClosed)
                {
                    throw new Exception("Wrong password!");
                }
                else
                {
                    reader.Close();
                    Window2 win = new Window2();
                    win.ShowDialog();
                }
                reader.Close();
            }
            else
            {
                throw new Exception("Wrong Login!");
            }
        }
    }
}
