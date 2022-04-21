using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IWordMeaningRepository
    {
        List<WordMeaning> List();
        WordMeaning GetById(int id);
        void Add(WordMeaning entity);
        void Update(WordMeaning entity);
        void Delete(int id);
    }
}
