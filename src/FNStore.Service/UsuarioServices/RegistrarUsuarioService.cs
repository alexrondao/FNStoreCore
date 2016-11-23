using DomainNotificationHelperCore.Assertions;
using DomainNotificationHelperCore.Commands;
using FNStore.Domain.Commands;
using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;

namespace FNStore.Service.UsuarioServices
{
    public class RegistrarUsuarioService : ServerCommand
    {
        private RegistrarUsuarioCommand _command;
        private IUsuarioRepository _repository;

        public RegistrarUsuarioService(RegistrarUsuarioCommand command, IUsuarioRepository repository) : base(command)
        {
            _command = command;
            _repository = repository;

            this.Run();
        }

        public void Run()
        {
            Validate();
            if (HasNotifications())
                return;

            var user = new Usuario(_command.Login, _command.Senha);
            _repository.Add(user);
        }

        public void Validate()
        {
            AddNotification(Assert.Length(_command.Login, 5, 20, "Login", "Login inválido"));
        }
    }
}
