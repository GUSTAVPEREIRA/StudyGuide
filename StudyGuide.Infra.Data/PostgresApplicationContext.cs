using Microsoft.EntityFrameworkCore;

namespace StudyGuide.Infra.Data
{
    public class PostgresApplicationContext : ApplicationContext
    {
        public PostgresApplicationContext(DbContextOptions<PostgresApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
