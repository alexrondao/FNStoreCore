using DomainNotificationHelperCore.Commands;

namespace FNStore.Domain.Commands
{
    public class RegistrarUsuarioCommand : Command
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
