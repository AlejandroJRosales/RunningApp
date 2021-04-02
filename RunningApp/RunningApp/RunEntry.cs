using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Essentials;

namespace RunningApp
{
    [Table("runLog")]
    public class RunEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime RunDate { get; set; }
        public double Distance { get; set; }
        public string RunTime { get; set; }

        public override string ToString()
        {
            double distance = Preferences.Get("units", "Miles") == "Miles" ? Distance * (8 / 5) : Distance;
            return String.Format("Date: {0} Distance: {1} Time: {2}", RunDate.ToString("MM/dd/yyyy"), distance + " " + Preferences.Get("units", "Miles"), RunTime);
        }
    }
}
