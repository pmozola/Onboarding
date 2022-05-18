namespace Onboarding.Domain.Base
{
    public interface ISpecification<T> where T : Entity
    {
        Task<bool> IsSatisfiedBy(T entity, CancellationToken cancellationToken = default);
    }
}
