using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ProgrammingLanguage()
        {

        }

        public ProgrammingLanguage(int id,string name, string description) : this()
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
