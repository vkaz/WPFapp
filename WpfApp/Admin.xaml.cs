using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // string pass = HashPassword(password.Password.ToString());
            // string login = textbox1.Text;
            string tsql = null;// = @"UPDATE [Users] SET password = '" + pass + "' WHERE login = 'admin'";
            try
            {
                var cb = new SqlConnectionStringBuilder
                {
                    DataSource = "custadm.database.windows.net",
                    UserID = "admin_cus",
                    Password = "Qwerty12",
                    InitialCatalog = "customers"
                };
                string var = ConfigurationManager.ConnectionStrings["WpfApp.Properties.Settings.localDBConnectionString"].ConnectionString;

                using (var connection = new SqlConnection(var))
                {
                    connection.Open();
                    using (var command = new SqlCommand(tsql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();

                            reader.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Gd_Loaded(object sender, RoutedEventArgs e)
        {
            string tsql = @"SELECT * FROM [Users]";
            try
            {
                DBCon con = new DBCon();
                gd.ItemsSource = con.Users(tsql);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ch_us ch_Us = new ch_us();
            ch_Us.ShowDialog();
        }
    }
}
