using FNStore.Domain.Commands;
using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using FNStore.Service.UsuarioServices;
using System;
using System.Collections.Generic;
using Xunit;

namespace FNStore.Test.Services
{
    public class RegistrarUsuarioServiceTest
    {
        [Fact]
        public void Dado_um_novo_usuario_sua_validacao_devera_falhar()
        {

            var command = new RegistrarUsuarioCommand();
            command.Login = "";
            command.Senha = "123456t";

            var service = new RegistrarUsuarioService(command, new FakeUsuarioRepository());
            Assert.True(service.HasNotifications());
        }
    }

    internal class FakeUsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario entity)
        {
            return;
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Get()
        {
            throw new NotImplementedException();
        }

        public Usuario Get(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
