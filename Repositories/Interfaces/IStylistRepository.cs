using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Repositories.Interfaces
{
    interface IStylistRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllStylists();

    }
}
