using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class WordMeaning:IEntity
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public int LangId { get; set; }
        public int? WordDefinitionId { get; set; }

        [ForeignKey("LangId")]
        public virtual Language Lang { get; set; }

        [ForeignKey("WordDefinitionId")]
        public virtual WordDefinition WordDef { get; set; }
    }
}
