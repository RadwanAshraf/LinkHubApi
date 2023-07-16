using LinkHubApi.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkHubApi.CodeFirstMigration.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<ProfileSettings> ProfileSettings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
