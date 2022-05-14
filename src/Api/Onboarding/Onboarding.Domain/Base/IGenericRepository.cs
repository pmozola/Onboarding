namespace Onboarding.Domain.Base
{
    public interface IAddGenericRepository<T> where T : Entity, IAggregateRoot
    {
        public Task<int> Add(T entity, CancellationToken cancellationToken);
    }

    public interface IDeleteGenericRepository<T> : IGetGenericRepository<T> where T : Entity, IAggregateRoot
    {
        public Task Delete(T entity, CancellationToken cancellationToken);
    }

    public interface IGetGenericRepository<T> where T : Entity, IAggregateRoot
    {
        public Task<T?> Get(int id, CancellationToken cancellationToken);
    }

    public interface IUpdateGenericRepository<T> : IGetGenericRepository<T> where T : Entity, IAggregateRoot
    {
        public Task Update(T entity, CancellationToken cancellationToken);
    }
}
