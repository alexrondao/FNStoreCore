using DomainNotificationHelperCore.Assertions;
using DomainNotificationHelperCore.Commands;
using FNStore.Domain.Commands.UsuarioCommands;
using FNStore.Domain.Contracts.Repositories;

namespace FNStore.Service.UsuarioServices
{
    public class AtualizarUsuarioService: ServerCommand
    {

        private AtualizarUsuarioCommand _command;
        private IUsuarioRepository _repository;

        public AtualizarUsuarioService(AtualizarUsuarioCommand command, IUsuarioRepository repository) : base(command)
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

            var user = _repository.Get(_command.Id);
            user.Alterar(_command.Login, _command.Senha, _command.Ativo);
            _repository.Update(user);
        }

        public void Validate()
        {
            AddNotification(Assert.Length(_command.Senha, 5, 20, "Login", "Login inválido"));
        }

    }
}
