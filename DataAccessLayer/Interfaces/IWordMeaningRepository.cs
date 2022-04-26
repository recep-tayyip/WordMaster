using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IWordMeaningRepository:IRepositoryBase<WordMeaning>
    {
        List<WordMeaning> ListByDefId(int defId);
    }
}
