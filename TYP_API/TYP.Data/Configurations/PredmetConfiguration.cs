using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;

namespace TYP.Data.Configurations
{
    public class PredmetConfiguration : IEntityTypeConfiguration<Predmet>
    {
        public void Configure(EntityTypeBuilder<Predmet> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasOne(x => x.Department).WithMany(x => x.Predmets).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
