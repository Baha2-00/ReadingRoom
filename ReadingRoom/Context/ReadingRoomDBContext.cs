using Microsoft.EntityFrameworkCore;
using ReadingRoom.Models.Entity;
using ReadingRoom.Models.EntityConfiguration;

namespace ReadingRoom.Context
{
    public class ReadingRoomDBContext : DbContext
    {
        public ReadingRoomDBContext(DbContextOptions<ReadingRoomDBContext> dbOptions) : base(dbOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ContentEnitityConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEnitityConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionEnitityConfiguration());
        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
    }
}
