using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Repository
{
    interface IStylistRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

    }
}
