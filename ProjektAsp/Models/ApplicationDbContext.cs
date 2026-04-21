using Microsoft.EntityFrameworkCore;

namespace ProjektAsp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member>? Members { get; set; }
        public DbSet<GroupClass>? GroupClasses { get; set; }
        public DbSet<Trainer>? Trainers { get; set; }
        public DbSet<TrainingSession>? TrainingSessions { get; set; }
    }
}
