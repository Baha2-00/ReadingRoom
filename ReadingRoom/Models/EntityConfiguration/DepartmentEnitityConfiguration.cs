using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReadingRoom.Models.Entity;

namespace ReadingRoom.Models.EntityConfiguration
{
    public class DepartmentEnitityConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentId).UseIdentityColumn();
            builder.Property(x => x.Description).HasMaxLength(120);
            builder.HasIndex(x => x.ContactEmail).IsUnique();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    
    }
}
