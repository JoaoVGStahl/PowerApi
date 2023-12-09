using PowerApi.Application.Entitys;

namespace PowerApi.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario?> AdicionarAsync(Usuario usuario);
        Task<Usuario?> AtualizarAsync(Usuario usuario);
        Task<bool> InativarAsync(int id);
        Task<bool> SuspenderAsync(int id);
        Task<bool> BanirAsync(int id);
        Task<List<Usuario>> ObterTodosAsync();
    }
}
