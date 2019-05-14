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
            DataContext = new LoginViewModel();
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
    }
}
    
