using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        internal MSSQLContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(MSSQLContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        //public GenericRepository()
        //{

        //}


        public void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        //public TEntity GetById(object id)
        //{
        //    return DbSet.Find(id);
        //}

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> exception)
        {
            return DbSet.Where(exception).ToList();
        }
    }
}
