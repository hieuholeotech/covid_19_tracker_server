using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Tracker.Data.Entities
{
    public class Health
    {
        public Guid Id { get; set; }

        public DateTime DateFollow { get; set; }

        public bool isDifficultyBreathing { get; set; } // Khó thở
        public bool isFever { get; set; } // Sốt
        public bool isCough { get; set; } // Ho
        public bool isSoreThroat { get; set; } // Đau họng
        public bool isTiredness { get; set; } // Mệt mỏi
        public bool isPneumonia { get; set; } // viêm phổi
        public string OtherSymptoms { get; set; }

        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public bool Status { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
