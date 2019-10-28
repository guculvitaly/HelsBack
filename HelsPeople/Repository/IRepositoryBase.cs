using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.Repository
{
  public  interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        Task<T> FindById(T id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);

    }
}
