using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Covid19Tracker.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public bool Gender { get; set; } // 0 Nam 1 Nu
        public string IdentityCard { get; set; }
        public string Address { get; set; }
        public string UrlAvatar { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Health> Healths { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
