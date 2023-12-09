using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerApi.Application.Entitys;
using PowerApi.Application.Enums;

namespace PowerApi.Data.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(u => u.UsuarioId);

            builder.Property(u => u.UsuarioId)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            builder.Property(u => u.NomeCompleto)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("varchar(80)");

            builder.Property(u => u.Telefone)
                .HasColumnType("varchar(11)");

            builder.Property(u => u.Senha)
                .HasColumnType("varchar(32)");

            builder.Property(u => u.DataCadastro)
                .ValueGeneratedOnAdd()
                .HasColumnType("datetime");

            builder.Property(u => u.DataUltimaAtualizacao)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime");

            builder.Property(u => u.Status)
                .HasColumnType("int(1)")
                .HasDefaultValue(StatusUsuario.Ativo);
        }
    }
}
