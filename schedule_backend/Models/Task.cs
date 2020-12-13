using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schedule_backend.Models
{
    public class Task
    {
        public ResultTask ToResult() {
            return new ResultTask(TaskDate.Year, TaskDate.Month, TaskDate.Day, TaskText);
        }

        public int Id { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskText { get; set; }
    }
}
