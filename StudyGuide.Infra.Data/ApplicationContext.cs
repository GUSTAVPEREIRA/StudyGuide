using Microsoft.EntityFrameworkCore;
using StudyGuide.Infra.Data.Mapping;
using StudyGuide.Model.Users;

namespace StudyGuide.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        //Code example please use this logic
        public DbSet<User> TbUsers;

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected ApplicationContext(ModelBuilder builder)
        {
            new UserMapping().Mapping(ref builder);

            base.OnModelCreating(builder);
        }
    }
}