using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Tracker.Data.ViewModel
{
    public class CreateReportViewModel
    {
        public string Content { get; set; }
        public string Place { get; set; }
        public DateTime DetectionTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

    }
}
