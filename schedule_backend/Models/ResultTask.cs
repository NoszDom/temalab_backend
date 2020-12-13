using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schedule_backend.Models
{
    public class ResultTask
    {
        public ResultTask() { }
        public ResultTask(int year, int month, int day, string text)
        {
            Year = year;
            Month = month;
            Day = day;
            Text = text;
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day{ get; set; }
        public string Text { get; set; }
    }
}
