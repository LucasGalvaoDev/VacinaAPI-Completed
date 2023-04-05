using Microsoft.EntityFrameworkCore;
using Vacinas.API.Model;

namespace Vacina.API.Context
{
    public class ConsultaContext : DbContext
    {
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Relatorio> Relatorio { get; set; }

        public ConsultaContext(DbContextOptions options) 
            : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEntities(modelBuilder);
            InitializeData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected void ConfigureEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>()
                .ToTable("tbl_consulta")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Consulta>()
                .Property(c => c.DataSolicitacao);

            modelBuilder.Entity<Consulta>()
                .Property(c => c.Cpf)
                .IsRequired();

            modelBuilder.Entity<Consulta>()
                .Property(c => c.Nome)
                .IsRequired();

            modelBuilder.Entity<Relatorio>()
                .ToTable("tbl_relatorio")
                .HasKey(r => r.Id);

            modelBuilder.Entity<Relatorio>()
                .Property(r => r.QuantidadeTotalVacinados)
                .IsRequired();

            modelBuilder.Entity<Relatorio>()
                .Property(r => r.SolicitanteId)
                .IsRequired();

            modelBuilder.Entity<Relatorio>()
                .Property(r => r.DataSolicitacao)
                .IsRequired();

            modelBuilder.Entity<Relatorio>()
                .Property(r => r.DescricaoRelatorio)
                .IsRequired();
        }

        protected void InitializeData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>().HasData(
                new Consulta { Cpf = "13119056774" , DataSolicitacao = DateTime.Now, Id = 1, Nome = "Lucas Galvão" });

            modelBuilder.Entity<Relatorio>().HasData(
                new Relatorio { Id = 1, DataSolicitacao = DateTime.Now, DescricaoRelatorio = "Relatório Vacinas Pfizer aplicadas no RJ dia 03/03/2023", QuantidadeTotalVacinados = 71, SolicitanteId = 1 });

            modelBuilder.Entity<Consulta>().HasData(
                new Consulta { Cpf = "56898787874", DataSolicitacao = DateTime.Now, Id = 2, Nome = "Lucas Coutinho" });

            modelBuilder.Entity<Relatorio>().HasData(
                new Relatorio { Id = 2, DataSolicitacao = DateTime.Now, DescricaoRelatorio = "Relatório Vacinas Pfizer aplicadas no RJ dia 15/03/2023", QuantidadeTotalVacinados = 50, SolicitanteId = 2 });
        }
    }
}
