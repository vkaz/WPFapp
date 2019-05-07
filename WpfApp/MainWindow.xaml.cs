using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using BCrypt.Net;
using BCrypt;
using System.Windows.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Net;
using System.Configuration;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool Checkinternet()
        {
            WebRequest request = WebRequest.Create("http://www.google.com");
            WebResponse response;
            try
            {
                response = request.GetResponse();
                response.Close();
                request = null;
                return true;
            }
            catch (Exception)
            {
                request = null;
                return false;
            }
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            bool result = Checkinternet();
            if (result == false)
            {
                MessageBox.Show("Sorry, we couldn't connect to Internet!");
               // this.Close();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textbox1.Text;
            string pass = password.Password.ToString();
            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(pass))
            {
                DBCon con = new DBCon(login, pass);
                string tsql = @"SELECT * FROM [Users] WHERE login = '" + login + "'";
                try
                {
                    con.Password(tsql);
                    this.Close();
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
    
