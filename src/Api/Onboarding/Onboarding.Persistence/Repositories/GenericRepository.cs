using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Base;

namespace Onboarding.Persistence.Repositories
{
    public class EntityFrameworkGenericRepository<T> : IGetGenericRepository<T>, ICreateGenericRepository<T>, IUpdateGenericRepository<T>, IDeleteGenericRepository<T>
        where T : Entity, IAggregateRoot
    {
        private readonly OnboardingDBContext dbContext;
        private readonly DbSet<T> dbSet;

        public EntityFrameworkGenericRepository(OnboardingDBContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<int> Create(T entity, CancellationToken cancellationToken)
        {
            dbSet.Add(entity);
            await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return entity.Id;
        }

        public Task<T?> Get(int id, CancellationToken cancellationToken) => dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public Task Delete(T entity, CancellationToken cancellationToken)
        {
            dbSet.Remove(entity);

            return dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Update(T entity, CancellationToken cancellationToken)
        {
            dbSet.Update(entity);
            return dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
