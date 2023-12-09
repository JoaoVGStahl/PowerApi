using PowerApi.Application.Enums;

namespace PowerApi.Application.Entitys
{
    public class Usuario : Entity
    {
        public int UsuarioId { get; set; }
        public string? NomeUsuario { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        public StatusUsuario? Status { get; set; }

        public void Atualizar(Usuario novosDados)
        {
            NomeUsuario = novosDados.NomeUsuario;
            NomeCompleto = novosDados.NomeCompleto;
        }

        public void Banir()
        {
            Status = StatusUsuario.Banido;
        }
        public void Inativar()
        {
            Status = StatusUsuario.Inativo;
        }

        public void Suspender()
        {
            Status = StatusUsuario.Suspenso;
        }
    }
}
