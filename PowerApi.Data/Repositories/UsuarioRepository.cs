using Microsoft.EntityFrameworkCore;
using PowerApi.Application.Entitys;
using PowerApi.Application.Enums;
using PowerApi.Application.Interfaces;
using PowerApi.Application.Interfaces.Repositories;
using PowerApi.Data.Context;

namespace PowerApi.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PowerApiContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UsuarioRepository(PowerApiContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorIdAsync(int id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioId == id && u.Status == StatusUsuario.Ativo);
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios
               .FirstOrDefaultAsync(u => u.Email == email && u.Status == StatusUsuario.Ativo);
        }

        public async Task<Usuario?> ObterPorNomeUsuarioAsync(string nome)
        {
            return await _context.Usuarios
               .FirstOrDefaultAsync(u => u.NomeUsuario == nome && u.Status == StatusUsuario.Ativo);
        }

        public async Task<Usuario?> ObterPorTelefoneAsync(string telefone)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Telefone == telefone && u.Status == StatusUsuario.Ativo);
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _context.Usuarios
                .Where(u => u.Status == StatusUsuario.Ativo).ToListAsync();
        }

        public void Add(Usuario entity)
        {
           _context.Usuarios.Add(entity);
        }

        public void Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
           GC.SuppressFinalize(this);
        }
    }
}
