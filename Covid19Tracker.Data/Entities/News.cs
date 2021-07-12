using System;

namespace Covid19Tracker.Data.Entities
{
    public class News
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Slug { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public string Content { set; get; }
        public int ViewCount { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateUpdated { set; get; }
        public Guid CreatedBy { set; get; }
        
        public virtual AppUser AppUser { get; set; }

    }
}
