using System.Collections.Generic;

namespace FNStore.Domain.Entities
{
    public class Cliente:Entity
    {
        public Cliente()
        {
            this.Telefones = new List<Telefone>();
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
