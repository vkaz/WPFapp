using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp
{

    public class MyTable : INotifyPropertyChanged
    {
        int id;
        string surname;
        string name;
        string type;
        DateTime fly = DateTime.Today;
        int days;
        DateTime ex1_start;
        DateTime ex1_end;
        DateTime ex2_start;
        DateTime ex2_end;
        DateTime ex3_start;
        DateTime ex3_end;
        DateTime ex4_start;
        DateTime ex4_end;
        DateTime fly_out;
        int num;
        public ObservableCollection<MyTable> Table { get; set; }
        private MyTable t1;
        private RelayCommand addCustomer;
        public RelayCommand AddCustomer
        {
            get
            {
                return addCustomer ??
                      (addCustomer = new RelayCommand(obj =>
                      {
                          Window1 win = new Window1();
                          win.ShowDialog();
                      }));
            }
        }
        private RelayCommand delCustomer;
        public RelayCommand DelCustomer
        {
            get
            {
                return delCustomer ??
                      (delCustomer = new RelayCommand(obj =>
                      {
                          MessageBox.Show("del");
                      }));
            }
        }
        private RelayCommand admin;
        public RelayCommand Admin
        {
            get
            {
                return admin ??
                      (admin = new RelayCommand(obj =>
                      {
                          ch_us ch_Us = new ch_us();
                          ch_Us.ShowDialog();
                      }));
            }
        }
        private RelayCommand update;
        public RelayCommand Update
        {
            get
            {
                return update ??
                      (update = new RelayCommand(obj =>
                      {
                          Table = DBCon.Grid();
                      }));
            }
        }

        public MyTable()
        {
            Table = DBCon.Grid();
        }
        public MyTable(string Surname, string Name, string Type, DateTime fly, int days)
        {
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);

            ci.DateTimeFormat.ShortDatePattern = "MM'/'dd'/'yyyy";

            ci.DateTimeFormat.LongTimePattern = "hh':'mm tt";

            Thread.CurrentThread.CurrentCulture = ci;

            Thread.CurrentThread.CurrentUICulture = ci;
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Type = Type;
            this.FLy = fly;
            this.Days = days;
            this.Ex1_start = fly.AddDays(days);
            this.Ex1_end = this.Ex1_start.AddDays(29);
            this.Ex2_start = this.Ex1_end.AddDays(1);
            this.Ex2_end = this.Ex2_start.AddDays(29);
            this.Ex3_start = this.Ex2_end.AddDays(1);
            this.Ex3_end = this.Ex3_start.AddDays(29);
            this.Ex4_start = this.Ex3_end.AddDays(1);
            this.Ex4_end = this.Ex4_start.AddDays(29);
            this.Fly_out = this.Ex4_end;
            this.Num = 0;
        }
        public MyTable(int Id, string Surname, string Name, string Type,
            DateTime fly, int days, string ex1_start, string ex1_end,
            string ex2_start, string ex2_end, string ex3_start, string ex3_end,
            string ex4_start, string ex4_end, string fly_out, int num)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Type = Type;
            this.FLy = fly;
            this.Days = days;
            if (ex1_start.Trim() != string.Empty)
                this.Ex1_start = DateTime.Parse(ex1_start);
            if (ex1_end.Trim() != string.Empty)
                this.Ex1_end = DateTime.Parse(ex1_end);
            if (ex2_start.Trim() != string.Empty)
                this.Ex2_start = DateTime.Parse(ex2_start);
            if (ex2_end.Trim() != string.Empty)
                this.Ex2_end = DateTime.Parse(ex2_end);
            if (ex3_start.Trim() != string.Empty)
                this.Ex3_start = DateTime.Parse(ex3_start);
            if (ex3_end.Trim() != string.Empty)
                this.Ex3_end = DateTime.Parse(ex3_end);
            if (ex4_start.Trim() != string.Empty)
                this.Ex4_start = DateTime.Parse(ex4_start);
            if (ex4_end.Trim() != string.Empty)
                this.Ex4_end = DateTime.Parse(ex4_end);
            if (fly_out.Trim() != string.Empty)
                this.Fly_out = DateTime.Parse(fly_out);
            this.Num = num;
            if (Num == 0)
            {
                this.Fly_out = fly.AddDays((days - 1));
                DateTime thisDay = DateTime.Today;
                if (thisDay.AddDays(14) >= Fly_out && thisDay.AddDays(7) < Fly_out)
                    ColorCell = "Yellow";
                else if (thisDay.AddDays(7) >= Fly_out)
                    ColorCell = "Red";

            }
            else if (Num == 1)
            {
                this.Fly_out = this.Ex1_end;
                DateTime thisDay = DateTime.Today;
                if (thisDay.AddDays(14) >= Fly_out && thisDay.AddDays(7) < Fly_out)
                    ColorCell1 = "Yellow";
                else if (thisDay.AddDays(7) >= Fly_out)
                    ColorCell1 = "Red";
            }
            else if (Num == 2)
            {
                this.Fly_out = this.Ex2_end;
                DateTime thisDay = DateTime.Today;
                if (thisDay.AddDays(14) >= Fly_out && thisDay.AddDays(7) < Fly_out)
                    ColorCell2 = "Yellow";
                else if (thisDay.AddDays(7) >= Fly_out)
                    ColorCell2 = "Red";
            }
            else if (Num == 3)
            {
                this.Fly_out = this.Ex3_end;
                DateTime thisDay = DateTime.Today;
                if (thisDay.AddDays(14) >= Fly_out && thisDay.AddDays(7) < Fly_out)
                    ColorCell3 = "Yellow";
                else if (thisDay.AddDays(7) >= Fly_out)
                    ColorCell3 = "Red";
            }
            else if (Num == 4)
            {
                this.Fly_out = this.Ex4_end;
                DateTime thisDay = DateTime.Today;
                if (thisDay.AddDays(14) >= Fly_out && thisDay.AddDays(7) < Fly_out)
                    ColorCell4 = "Yellow";
                else if (thisDay.AddDays(7) >= Fly_out)
                    ColorCell4 = "Red";
            }
            /*DateTime thisDay = DateTime.Today;
            if (thisDay.AddDays(14) >= Fly_out && thisDay.AddDays(7) < Fly_out)
                ColorSet = "Yellow";
            else if (thisDay.AddDays(7) >= Fly_out)
                ColorSet = "Red";
            else if (thisDay < Fly_out)
                ColorSet = "AliceBlue";*/
        }
        public string ColorCell { get; set; }
        public string ColorCell1 { get; set; }
        public string ColorCell2 { get; set; }
        public string ColorCell3 { get; set; }
        public string ColorCell4 { get; set; }
        public string ColorSet { get; set; }


        public int Num {
            get
            {
                return num;
            }
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public DateTime FLy
        {
            get
            {
                return fly;
            }
            set
            {
                fly = value;
                OnPropertyChanged("FLy");
            }
        }
        public int Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
                OnPropertyChanged("Days");
            }
        }
        public DateTime Ex1_start
        {
            get
            {
                return ex1_start;
            }
            set
            {
                ex1_start = value;
                OnPropertyChanged("Ext1_start");
            }
        }
        public DateTime Ex1_end
        {
            get
            {
                return ex1_end;
            }
            set
            {
                ex1_end = value;
                OnPropertyChanged("Ext1_end");
            }
        }
        public DateTime Ex2_start
        {
            get
            {
                return ex2_start;
            }
            set
            {
                ex2_start = value;
                OnPropertyChanged("Ext2_start");
            }
        }
        public DateTime Ex2_end
        {
            get
            {
                return ex1_end;
            }
            set
            {
                ex2_end = value;
                OnPropertyChanged("Ext2_end");
            }
        }
        public DateTime Ex3_start
        {
            get
            {
                return ex3_start;
            }
            set
            {
                ex3_start = value;
                OnPropertyChanged("Ext3_start");
            }
        }
        public DateTime Ex3_end
        {
            get
            {
                return ex3_end;
            }
            set
            {
                ex3_end = value;
                OnPropertyChanged("Ext3_end");
            }
        }
        public DateTime Ex4_start
        {
            get
            {
                return ex4_start;
            }
            set
            {
                ex4_start = value;
                OnPropertyChanged("Ext4_start");
            }
        }
        public DateTime Ex4_end
        {
            get
            {
                return ex4_end;
            }
            set
            {
                ex4_end = value;
                OnPropertyChanged("Ext4_end");
            }
        }
        public DateTime Fly_out
        {
            get
            {
                return fly_out;
            }
            set
            {
                fly_out = value;
                OnPropertyChanged("Fly_out");
            }
        }
        private RelayCommand addCus;
        public RelayCommand AddCus
        {
            get
            {
                return addCus ??
                    (addCus = new RelayCommand(obj =>
                    {
                        MessageBox.Show("1");

                        if (surname != String.Empty && name != String.Empty && days > 0
                            && fly != null && type != String.Empty)
                        {
                            t1 = new MyTable(surname, name, type, fly, days);
                            try
                            {
                                DBCon con = new DBCon();
                                con.Add(t1);
                                MessageBox.Show("Customer added");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                            MessageBox.Show("Empty line");

                    }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private string userName;
        public string UserName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.userName))
                {
                    this.userName = "Nothing is Selected";
                    return this.userName;
                }
                else
                {
                    MessageBox.Show(userName);
                    return this.userName;
                }
            }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                //if (!string.Equals(userName, value))
                //{
                userName = value;
                OnPropertyChanged("UserName"); // Method to raise the PropertyChanged event in your BaseViewModel class...
                //}
            }
        }
    }
}
