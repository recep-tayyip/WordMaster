﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class WordDefinitionRepository : RepositoryBase<WordDefinition>, IWordDefinitionRepository
    {
        public WordDefinitionRepository(WordMasterDbContext context) : base(context)
        {
        }

        public override List<WordDefinition> List()
        {
            var liste = _context.Set<WordDefinition>().Include(c => c.Lang).ToList();
            return liste;
        }
    }
}
