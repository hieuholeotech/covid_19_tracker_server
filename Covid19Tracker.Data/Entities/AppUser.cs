using Microsoft.AspNetCore.Identity;
using System;

namespace Covid19Tracker.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public string Address { get; set; }
        public string UrlAvatar { get; set; }

    }
}
