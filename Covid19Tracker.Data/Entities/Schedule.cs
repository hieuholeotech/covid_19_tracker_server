using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Tracker.Data.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string Status { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
