using PowerApi.Application.Entitys;

namespace PowerApi.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IDisposable where T : Entity 
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(T entity);
        void Update(T entity);
    }
}
