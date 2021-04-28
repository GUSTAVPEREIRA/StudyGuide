using Microsoft.EntityFrameworkCore;

namespace StudyGuide.Infra.Data
{
    public interface IMapping
    {
        public void Mapping(ref ModelBuilder builder);
    }
}