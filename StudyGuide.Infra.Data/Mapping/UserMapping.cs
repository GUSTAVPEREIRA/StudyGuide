using Microsoft.EntityFrameworkCore;
using StudyGuide.Model.Users;

namespace StudyGuide.Infra.Data.Mapping
{
    public class UserMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(k => k.Id);
            builder.Entity<User>().Property(p => p.Username).HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Password).HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Name).HasMaxLength(100);
            builder.Entity<User>().Property(p => p.Name).HasMaxLength(100);
        }
    }
}
