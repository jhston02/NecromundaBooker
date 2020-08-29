using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnderHiveBookKeeper.Gangs.Domain.SeedWork
{
    interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken token = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken token = default(CancellationToken));
    }
}
