using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class WordMasterDbContext:DbContext
    {
        public WordMasterDbContext(DbContextOptions<WordMasterDbContext> options):base(options)
        {
          
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<WordMeaning> WordMeanings { get; set; }
        public DbSet<WordDefinition> WordDefinitions { get; set; }
    }
}
