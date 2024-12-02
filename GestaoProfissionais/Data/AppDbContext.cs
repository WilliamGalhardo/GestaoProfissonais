using Microsoft.EntityFrameworkCore;
using GestaoProfissionais.Models;
using System; // Ajuste conforme seu namespace

namespace GestaoProfissionais.Data // Namespace ajustado conforme sua estrutura
{
    public class AppDbContext : DbContext
    {
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Configuração da string de conexão com o banco SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Idealmente a string de conexão vem do arquivo appsettings.json
            optionsBuilder.UseSqlite("DataSource=D:\\Projetos C#\\GestaoProfissionais\\GestaoProfissionais\\app.db");
        }

        // Carregar dados iniciais de especialidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dados iniciais das especialidades
            modelBuilder.Entity<Especialidade>().HasData(
                new Especialidade { Id = Guid.NewGuid(), Nome = "Cardiologia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Ortopedia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Pediatria", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Dermatologia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Ginecologia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Neurologia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Psiquiatria", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Anestesiologia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Radiologia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Endocrinologia", TipoDocumento = "CRM" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Nutricionista Clínico", TipoDocumento = "CRN" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Nutrição Esportiva", TipoDocumento = "CRN" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Nutrição Oncológica", TipoDocumento = "CRN" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Fisioterapia Ortopédica", TipoDocumento = "CREFITO" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Fisioterapia Neurológica", TipoDocumento = "CREFITO" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Fisioterapia Respiratória", TipoDocumento = "CREFITO" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Ortodontia", TipoDocumento = "CRO" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Implantodontia", TipoDocumento = "CRO" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Endodontia", TipoDocumento = "CRO" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Enfermagem Geral", TipoDocumento = "COREN" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Enfermagem Obstétrica", TipoDocumento = "COREN" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Psicologia Clínica", TipoDocumento = "CRP" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Psicologia Organizacional", TipoDocumento = "CRP" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Neuropsicologia", TipoDocumento = "CRP" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Farmácia Clínica", TipoDocumento = "CRF" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Farmácia Hospitalar", TipoDocumento = "CRF" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Análises Clínicas", TipoDocumento = "CRF" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Personal Trainer", TipoDocumento = "CREF" },
                new Especialidade { Id = Guid.NewGuid(), Nome = "Preparação Física", TipoDocumento = "CREF" }
            );

            // Relacionamento entre Profissional e Especialidade
            modelBuilder.Entity<Profissional>()
                .HasOne(p => p.Especialidade)
                .WithMany()
                .HasForeignKey(p => p.EspecialidadeId);
        }
    }
}
