using Entities;
using Entities.IssuesManager;
using Microsoft.EntityFrameworkCore;
using XCutting.Extensions;

namespace DataLayer.Context
{
    public class IssuesManagerContext : DbContext
    {
        public IssuesManagerContext(DbContextOptions<IssuesManagerContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.GetConfigurationsFromAssembly<IssuesManagerContext>();
            builder.DisableCascadeDeleteConvention();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<UserStoryContainer> UserStoryContainers { get; set; }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
