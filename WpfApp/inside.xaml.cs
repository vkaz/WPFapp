using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для inside.xaml
    /// </summary>
    public partial class inside : Window
    {
        public inside()
        {
            InitializeComponent();
        }

        internal void ShowData(object selectedItem)
        {
            MyTable t = selectedItem as MyTable;

            string surname = Convert.ToString(t.Surname);
            string name = Convert.ToString(t.Name);
            string days = Convert.ToString(t.Days);
            string date = Convert.ToString(t.FLy);
            t1.Text = surname;
            t2.Text = name;
            t3.Text = date;
            t4.Text = days;
            MessageBox.Show(surname, name);
            MessageBox.Show(date, days);
        }
    }
    
}
