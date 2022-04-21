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
    public class LanguageRepository:ILanguageRepository
    {
        private WordMasterDbContext _context;
        public LanguageRepository(WordMasterDbContext context)
        {
            _context = context;
        }

        public List<Language> List()
        {
            return _context.Set<Language>().ToList();
        }

        public Language GetById(int id)
        {
            return _context.Set<Language>().Find(id);
        }

        public void Add(Language entity)
        {
            _context.Set<Language>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Language entity)
        {
            //_context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleted = GetById(id);
            _context.Set<Language>().Remove(deleted);
            _context.SaveChanges();
        }


    }
}
