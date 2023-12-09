using PowerApi.Application.Entitys;
using PowerApi.Application.Interfaces;
using PowerApi.Application.Interfaces.Repositories;
using PowerApi.Application.Interfaces.Services;
using PowerApi.Application.Notifications;

namespace PowerApi.Domain.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, 
            INotificationService notificationService) : base(notificationService)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _usuarioRepository.ObterTodosAsync();
        }

        public async Task<Usuario?> AdicionarAsync(Usuario usuario)
        {
            if (await ValidarCamposDuplicados(usuario)) return null;

            _usuarioRepository.Add(usuario);

            if (!await _usuarioRepository.UnitOfWork.Commit())
            {
                Notify(UsuarioNotifications.ErroAoAdicionar);
                return null;
            }

            return usuario;
        }

        public async Task<Usuario?> AtualizarAsync(Usuario usuario)
        {
            if (await ValidarCamposDuplicados(usuario)) return null;

            var usuarioBd = await _usuarioRepository.ObterPorIdAsync(usuario.UsuarioId);

            if (usuarioBd == null)
            {
                Notify(UsuarioNotifications.NaoEncontrado);
                return null;
            }

            usuarioBd.Atualizar(usuario);
            _usuarioRepository.Update(usuarioBd);

            if (!await _usuarioRepository.UnitOfWork.Commit())
            {
                Notify(UsuarioNotifications.ErroAoAdicionar);
                return null;
            }

            return usuarioBd;
        }

        public async Task<bool> BanirAsync(int id)
        {
            var usuarioBd = await _usuarioRepository.ObterPorIdAsync(id);

            if(usuarioBd == null)
            {
                Notify(UsuarioNotifications.NaoEncontrado);
                return false;
            }

            usuarioBd.Banir();
            _usuarioRepository.Update(usuarioBd);

            return await _usuarioRepository.UnitOfWork.Commit();
        }

        public async Task<bool> InativarAsync(int id)
        {
            var usuarioBd = await _usuarioRepository.ObterPorIdAsync(id);

            if (usuarioBd == null)
            {
                Notify(UsuarioNotifications.NaoEncontrado);
                return false;
            }

            usuarioBd.Inativar();
            _usuarioRepository.Update(usuarioBd);

            return await _usuarioRepository.UnitOfWork.Commit();
        }

        public async Task<bool> SuspenderAsync(int id)
        {
            var usuarioBd = await _usuarioRepository.ObterPorIdAsync(id);

            if (usuarioBd == null)
            {
                Notify(UsuarioNotifications.NaoEncontrado);
                return false;
            }

            usuarioBd.Suspender();
            _usuarioRepository.Update(usuarioBd);

            return await _usuarioRepository.UnitOfWork.Commit();
        }

        private async Task<bool> ValidarCamposDuplicados(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Email) &&
                            await _usuarioRepository.ObterPorEmailAsync(usuario.Email) != null)
            {
                Notify(UsuarioNotifications.EmailJaCadastrado);
            }

            if (!string.IsNullOrEmpty(usuario.Telefone) &&
                await _usuarioRepository.ObterPorTelefoneAsync(usuario.Telefone) != null)
            {
                Notify(UsuarioNotifications.TelefoneJaCadatrado);
            }

            if (!string.IsNullOrEmpty(usuario.NomeUsuario) &&
                await _usuarioRepository.ObterPorNomeUsuarioAsync(usuario.NomeUsuario) != null)
            {
                Notify(UsuarioNotifications.NomeUsuarioJaCadastrado);
            }

            return _notificationService.GetMessages().Any();
        }
    }
}
