using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
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
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (surname.Text != String.Empty && name.Text != String.Empty && days.Text != String.Empty
                && date.Text != String.Empty && visa.Text != String.Empty)
            {
                string str = date.SelectedDate.Value.ToString("dd.MM.yyyy");
                DateTime dt = DateTime.ParseExact(str, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                str = dt.ToString("MM.dd.yyyy");
                dt = DateTime.ParseExact(str, "MM.dd.yyyy", CultureInfo.InvariantCulture);
                MyTable table = new MyTable(surname.Text, name.Text, visa.Text, str, int.Parse(days.Text));
                string tsql = @"INSERT INTO [Customers] (Surname, Name, Type_of_visa, Fly_in, Days) 
                    VALUES('" + table.Surname + "', '" + table.Name + "'," +
                    "'" + table.Type + "', '" + table.Fly + "', '" + table.Days + "')";
                try
                {
                    DBCon con = new DBCon();
                    con.Add(table, tsql);
                    MessageBox.Show("Customer added");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Empty line");
        }
    }
}
