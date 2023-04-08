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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Fathername).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.PhoneNumber).IsRequired(true);
            builder.Property(x => x.BirthDate).IsRequired(true);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasOne(x => x.Sex).WithMany(x => x.Teachers).HasForeignKey(x => x.SexId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Department).WithMany(x => x.Teachers).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ScientificName).WithMany(x => x.Teachers).HasForeignKey(x => x.ScientificNameId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ScientificDegree).WithMany(x => x.Teachers).HasForeignKey(x => x.ScientificDegreeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.JobType).WithMany(x => x.Teachers).HasForeignKey(x => x.JobTypeId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
