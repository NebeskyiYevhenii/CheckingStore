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

        protected MSSQLContext Context;
        protected DbSet<TEntity> DbSet;

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

        public virtual IEnumerable<TEntity> GetAll()
        {


            var rez = DbSet.ToList<TEntity>();
            return rez; 
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        //public TEntity GetById(object id)
        //{
        //    return DbSet.Find(id);
        //}

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> exception)
        {
            return DbSet.Where(exception).ToList();
        }
    }
}
