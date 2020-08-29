using System;
using System.Collections.Generic;
using System.Text;

namespace UnderHiveBookKeeper.Gangs.Domain.SeedWork
{
    interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
