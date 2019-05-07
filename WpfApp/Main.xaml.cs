using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Security.Cryptography;
using System.Data;
using System.Configuration;

namespace WpfApp
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string tsql = @"SELECT * FROM [Customers]";
            try
            {
                DBCon con = new DBCon();
                List<MyTable> data = con.Grid(tsql);
                grid.ItemsSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.ShowDialog();
            Grid_Loaded(sender, e);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Grid_Loaded(sender, e);
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            MyTable t = grid.SelectedItem as MyTable;
            string surname = Convert.ToString(t.Surname.Trim());
            string name = Convert.ToString(t.Name.Trim());
            string tsql = @"DELETE FROM [Customers] WHERE Surname='" + surname + "' AND Name='"+name+"'";
            try
            {
                DBCon con = new DBCon();
                con.Delete(tsql);
                MessageBox.Show("Customer deleted");
                Grid_Loaded(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        DataGridCell targetCell1;
        DataGridRow targetRow;

        private void Grid_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var hit = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
            DependencyObject cell = VisualTreeHelper.GetParent(hit.VisualHit);
            while (cell != null && !(cell is DataGridCell)) cell = VisualTreeHelper.GetParent(cell);
            DataGridCell targetCell = cell as DataGridCell;
            if (targetCell != null)
            {
                targetCell1 = targetCell;
            }
            DependencyObject row = VisualTreeHelper.GetParent(hit.VisualHit);
            while (row != null && !(row is DataGridRow))
                row = VisualTreeHelper.GetParent(row);
            DataGridRow targetCell2 = row as DataGridRow;
            if (targetCell2 != null)
            {
                targetRow = targetCell2;
            }
            //MessageBox.Show(targetCell2.ToString());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //targetCell1.Background = new SolidColorBrush(Colors.Red);
            //targetRow.Background = new SolidColorBrush(Colors.Red);
            MyTable table = targetRow.Item as MyTable;
            int i = table.Num + 1;
            if (table.Num < 5)
            {
                string tsql = @"UPDATE [Customers] SET num_ext='" + i + "' WHERE Id='" + table.Id + "'";
                try
                {
                    DBCon con = new DBCon();
                    con.AddExt(tsql);
                    MessageBox.Show("update");
                    Grid_Loaded(sender, e);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Already use all ext");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // targetCell1.Background = new SolidColorBrush(Colors.AliceBlue);
            MyTable table = targetRow.Item as MyTable;
            string tsql = @"UPDATE [Customers] SET num_ext='0' WHERE Id='" + table.Id + "'";
            try
            {
                DBCon con = new DBCon();
                con.AddExt(tsql);
                MessageBox.Show("update");
                Grid_Loaded(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
