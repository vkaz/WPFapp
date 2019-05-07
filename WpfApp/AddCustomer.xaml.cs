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
                DateTime ex1 = date.SelectedDate.Value.Date;
                MyTable table = new MyTable(surname.Text, name.Text, visa.Text, ex1, 
                    int.Parse(days.Text));
                string tsql = null;
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
