using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.Repository
{
    public  class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _context { get; set; }

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }

       

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> FindById(T id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

       
        public async Task<T> Update(T entity)
        {
             _context.Set<T>().Update(entity);
           await _context.SaveChangesAsync();
            return entity;
           
        }

        
    }
}
