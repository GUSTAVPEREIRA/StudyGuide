using Microsoft.EntityFrameworkCore;
using StudyGuide.Infra.Data;
using StudyGuide.Infra.Repositories.IRepositories;
using System;

namespace StudyGuide.Infra.Repositories.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public PostgresApplicationContext Context { get; set; }

        public virtual bool Delete(T t)
        {
            try
            {
                Context.Remove(t);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual T FindById(int id)
        {
            return Context.Find<T>(id);
        }

        public virtual T Save(T t)
        {
            Context.Add(t);
            Context.SaveChanges();
            return t;
        }

        public virtual T Updated(T t)
        {
            Context.Add(t).State = EntityState.Modified;
            Context.SaveChanges();
            return t;
        }
    }
}
