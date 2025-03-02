using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskAdministratorAPI.models;
using TaskAdministratorAPI.repositories.models;

namespace TaskAdministratorAPI.repositories
{
    public class TaskRepository : DbContext
    {
        public DbSet<TaskDBModel> Tasks { get; set; }
        public string DBPath { get; }

        public TaskRepository(IOptions<Config> configuration)
        {
            var config = configuration.Value;
            DBPath = Path.Join(config.Path, config.Name);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DBPath}");
    }
}
