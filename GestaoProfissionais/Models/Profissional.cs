using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoProfissionais.Models
{
    public class Profissional
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Nome { get; set; }

        // Relacionamento com a tabela Especialidade
        public Guid EspecialidadeId { get; set; }  // Chave estrangeira alterada para Guid
        public Especialidade Especialidade { get; set; }  // Navegação

        [Required]
        public string TipoDocumento { get; set; }

        [Required]
        public string NumeroDocumento { get; set; }
    }
}
