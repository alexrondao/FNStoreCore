using DomainNotificationHelperCore.Commands;
using System;

namespace FNStore.Domain.Commands.UsuarioCommands
{
    public class AtualizarUsuarioCommand : Command
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public bool Ativo { get; set; }
    }
}
