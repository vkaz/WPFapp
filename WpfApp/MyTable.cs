using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{

    public class MyTable
    {
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

        public int Num { get; set; }
        public string Fly { get; set; }
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
        public DateTime Ex4_start { get; set; }
        public DateTime Ex4_end { get; set; }
        public string ColorSet { get; set; }
        public DateTime Fly_out { get; set; }
    }
}
