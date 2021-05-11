using Microsoft.EntityFrameworkCore;
using StudyGuide.Infra.Data.Mapping;
using StudyGuide.Model.Users;

namespace StudyGuide.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        //Code example please use this logic
        public DbSet<User> TbUsers { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping().Mapping(ref builder);


            base.OnModelCreating(builder);
        }
    }
}