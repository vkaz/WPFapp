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
                List<MyTable> data = con.grid(tsql);
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

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            inside ins = new inside();
            MyTable t = grid.SelectedItem as MyTable;

             string surname = Convert.ToString(t.Surname.Trim());
             string name = Convert.ToString(t.Name.Trim());
             string days = Convert.ToString(t.Days);
             string date = Convert.ToString(t.FLy);
             string type = Convert.ToString(t.Type.Trim());
             string ex1s = Convert.ToString(t.Ex1_start);
             string ex1e = Convert.ToString(t.Ex1_end);
             string ex2s = Convert.ToString(t.Ex2_start);
             string ex2e = Convert.ToString(t.Ex2_end);
             string ex3s = Convert.ToString(t.Ex3_start);
             string ex3e = Convert.ToString(t.Ex3_end);
             ins.t1.Text = surname;
             ins.t2.Text = name;
             ins.t3.Text = date;
             ins.t4.Text = days;
             ins.t5.Text = type;
             ins.t6.Text = ex1s;
             ins.t7.Text = ex1e;
             ins.t8.Text = ex2s;
             ins.t9.Text = ex2e;
             ins.t10.Text = ex3s;
             ins.t11.Text = ex3e;
             ins.ShowDialog();
             if (ins.t1.Text != surname || ins.t2.Text != name || ins.t3.Text != date || ins.t4.Text != days ||
                 ins.t5.Text != type || ins.t6.Text != ex1s || ins.t7.Text != ex1e || ins.t8.Text != ex2s ||
                 ins.t9.Text != ex2e || ins.t10.Text != ex3s || ins.t11.Text != ex3e)
                 MessageBox.Show("aaaa");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ch_us ch_Us = new ch_us();
            ch_Us.ShowDialog();
        }
    }
}
