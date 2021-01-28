using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);

        //TEntity GetById(object id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> exception);

    }
}
