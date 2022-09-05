using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        // Construtor protected para Entity Framework
        protected BaseEntity() { }
        public int Id { get; private set; }
    }
}