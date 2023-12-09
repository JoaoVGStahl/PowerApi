using PowerApi.Application.Entitys;

namespace PowerApi.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<List<Usuario>> ObterTodosAsync();
        Task<Usuario?> ObterPorIdAsync(int id);
        Task<Usuario?> ObterPorNomeUsuarioAsync(string nome);
        Task<Usuario?> ObterPorEmailAsync(string email);
        Task<Usuario?> ObterPorTelefoneAsync(string telefone);
    }
}
