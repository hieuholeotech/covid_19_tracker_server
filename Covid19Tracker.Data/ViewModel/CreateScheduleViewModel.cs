using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Tracker.Data.ViewModel
{
    public class CreateScheduleViewModel
    {
        public string Content { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
