using Microsoft.EntityFrameworkCore;

namespace StudyGuide.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        //Code example please use this logic
        //public DbSet<class> DbSets

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected ApplicationContext()
        {
        }
    }
}