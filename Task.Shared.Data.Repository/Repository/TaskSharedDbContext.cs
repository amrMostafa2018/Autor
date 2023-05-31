using Microsoft.EntityFrameworkCore;
using Task.Domain.Entites;


namespace Task.Shared.Data.Repository
{
    public class TaskSharedDbContext : DbContext
    {
        public TaskSharedDbContext(DbContextOptions<TaskSharedDbContext> options) : base(options)
        {
        }
        protected TaskSharedDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMemeber> TeamMemeber { get; set; }
        public DbSet<TeamSchedule> TeamSchedule { get; set; }

    }
}