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
            DataContext = new MyTable();
        }
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            DBCon.Delete(grid.SelectedItem); 
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
            DBCon.AddItemExt(targetRow.Item as MyTable);
           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // targetCell1.Background = new SolidColorBrush(Colors.AliceBlue);
            DBCon.DelItemExt(targetRow.Item as MyTable);
           
        }
    }
}
