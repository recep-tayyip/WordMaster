using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T:class
    {
        protected WordMasterDbContext _context;
        public RepositoryBase(WordMasterDbContext context)
        {
            _context = context;
        }
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T deleted = GetById(id);
            _context.Set<T>().Remove(deleted);
            _context.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public virtual void Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
