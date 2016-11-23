using System;

namespace FNStore.Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario() { }

        public Usuario(string login, string senha)
        {
            this.Id = Guid.Empty;
            this.Login = login;
            this.Senha = senha;
            this.Ativo = false;
            this.DataCadastro = DateTime.Now;
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
        public bool Ativo { get; private set; }

        public void Alterar(string login, string senha, bool ativo)
        {
            this.Login = login;
            this.Senha = senha;
            this.Ativo = ativo;
        }
    }
}
