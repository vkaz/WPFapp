using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{

    public class MyTable
    {
        DateTime date;

        public MyTable(string Surname, string Name, string Type, string fly, int days)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Type = Type;
            this.Fly = fly;
            this.Days = days;
        }
        public MyTable(int Id, string Surname, string Name, string Type,
            DateTime fly, int days, string ex1_start, string ex1_end,
            string ex2_start, string ex2_end, string ex3_start, string ex3_end)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Type = Type;
            this.FLy = fly;
            this.Days = days;
            if (ex1_start.Trim() != string.Empty)
            {
                MessageBox.Show(ex1_start);
                this.Ex1_start = DateTime.Parse(ex1_start);
            }
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
            DateTime thisDay = DateTime.Today;
            if (thisDay.AddDays(14) >= Fly_out && thisDay.AddDays(7) < Fly_out)
                ColorSet = "Yellow";
            else if (thisDay.AddDays(7) >= Fly_out)
                ColorSet = "Red";
            else if (thisDay < Fly_out)
                ColorSet = "AliceBlue";
        }
        public string Fly{ get; set; }
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime FLy { get; set; }
        public int Days { get; set; }
        public DateTime Ex1_start { get; set; }
        public DateTime Ex1_end { get; set; }
        public DateTime Ex2_start { get; set; }
        public DateTime Ex2_end { get; set; }
        public DateTime Ex3_start { get; set; }
        public DateTime Ex3_end { get; set; }
        public string ColorSet { get; set; }
        public DateTime Fly_out
        {
            get
            {
                this.date = this.FLy.AddDays(this.Days);
                if (date < this.Ex1_end)
                    date = this.Ex1_end;
                else if (date < this.Ex2_end)
                    date = this.Ex2_end;
                else if (date < this.Ex3_end)
                    date = this.Ex3_end;
                return (date);
            }
            set
            {
                date = value;
            }
        }
    }
}
