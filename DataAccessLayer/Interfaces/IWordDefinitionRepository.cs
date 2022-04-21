﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IWordDefinitionRepository
    {
        List<WordDefinition> List();
        WordDefinition GetById(int id);
        void Add(WordDefinition entity);
        void Update(WordDefinition entity);
        void Delete(int id);
    }
}