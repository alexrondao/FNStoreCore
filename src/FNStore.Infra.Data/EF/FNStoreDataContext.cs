using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace FNStore.Infra.Data.EF
{
    public class FNStoreDataContext : DbContext
    {
        private readonly string _conn;

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public FNStoreDataContext(IConfigurationRoot config)
        {
            _conn = config["ConnectionStrings:FNStoreConn"];

            if (string.IsNullOrWhiteSpace(_conn))
            {
                throw new ArgumentException("Connection string not found");
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ClienteMap(modelBuilder);
            TelefoneMap(modelBuilder);
            UsuarioMap(modelBuilder);
        }

        private void UsuarioMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(user =>
            {
                user.ToTable(nameof(Usuario));
                user.HasKey(c => c.Id);

                user.Property(col => col.Id)
                    .HasColumnName("Id").HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                user.Property(col => col.DataCadastro)
                    .HasColumnName("DataCadastro")
                    .HasColumnType("datetime").IsRequired();

                user.Property(col => col.Login)
                    .HasColumnName("Login")
                    .HasColumnType($"varchar(20)")
                    .IsRequired();

                user.Property(col => col.Senha)
                    .HasColumnName("Senha")
                    .HasColumnType($"varchar(20)")
                    .IsRequired();

                user.Property(col => col.Ativo)
                    .HasColumnName("Ativo")
                    .HasColumnType($"bit")
                    .IsRequired();
            });
        }

        private void TelefoneMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>(tel =>
            {
                tel.ToTable(nameof(Telefone));
                tel.HasKey(c => c.Id);

                tel.Property(col => col.Id)
                    .HasColumnName("Id").HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                tel.Property(col => col.DataCadastro)
                    .HasColumnName("DataCadastro")
                    .HasColumnType("datetime").IsRequired();

                tel.Property(col => col.Numero)
                    .HasColumnName("Numero")
                    .HasColumnType($"varchar(11)")
                    .IsRequired();

                tel.HasOne(col => col.Cliente)
                    .WithMany(col => col.Telefones)
                    .HasForeignKey(col => col.ClienteId);
            });
        }

        private void ClienteMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(cli =>
            {
                cli.ToTable(nameof(Cliente));

                cli.HasKey(c => c.Id);

                cli.Property(col => col.Id)
                    .HasColumnName("Id").HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                cli.Property(col => col.DataCadastro)
                    .HasColumnName("DataCadastro")
                    .HasColumnType("datetime").IsRequired();

                cli.Property(col => col.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType($"varchar(100)")
                    .IsRequired();

                cli.Property(col => col.Endereco)
                    .HasColumnName("Endereco")
                    .HasColumnType($"varchar(300)")
                    .IsRequired();
            });
        }


    }
}
