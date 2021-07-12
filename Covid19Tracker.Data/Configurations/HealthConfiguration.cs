using Covid19Tracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Tracker.Data.Configurations
{
    public class HealthConfiguration : IEntityTypeConfiguration<Health>
    {
        public void Configure(EntityTypeBuilder<Health> builder)
        {
            builder.ToTable("Healths");
            builder.HasKey(x => x.Id);
        }
    }
}
