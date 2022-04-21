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
    public class WordMeaningRepository:IWordMeaningRepository
    {
        private WordMasterDbContext _context;
        public WordMeaningRepository(WordMasterDbContext context)
        {
            _context = context;
        }

        public void Add(WordMeaning entity)
        {
            _context.Set<WordMeaning>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleted = GetById(id);
            _context.Set<WordMeaning>().Remove(deleted);
            _context.SaveChanges();
        }

        public WordMeaning GetById(int id)
        {
           return _context.Set<WordMeaning>().Find(id);
        }

        public List<WordMeaning> List()
        {
            return _context.Set<WordMeaning>().ToList();
        }

        public void Update(WordMeaning entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
