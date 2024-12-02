using System;

namespace GestaoProfissionais.Models
{
    public class Especialidade
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }

        public string TipoDocumento { get; set; }
    }
}
