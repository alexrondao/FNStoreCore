using System;

namespace FNStore.Domain.Entities
{
    public class Telefone : Entity
    {
        public string Numero { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
