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
    public class WordMeaningRepository: RepositoryBase<WordMeaning>, IWordMeaningRepository
    {
        public WordMeaningRepository(WordMasterDbContext context) : base(context)
        {
        }
    }
}
