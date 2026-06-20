using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        // MongoDB applies each write atomically and immediately at the repository level, so there is no
        // buffered change set to flush here. This is the commit boundary the use cases call; a transactional
        // implementation would open and commit a Mongo client session at this point.
        public Task<int> Save()
        {
            return Task.FromResult(0);
        }
    }
}
