namespace PowerApi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
