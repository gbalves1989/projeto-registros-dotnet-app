using Microsoft.EntityFrameworkCore;
using RegistrosEntradaSaidaAPP.Database.Entities;
using System.IO;

namespace RegistrosEntradaSaidaAPP.Database
{
    public class DatabaseConnection : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string projectRootPath = Directory.GetParent(AppContext.BaseDirectory) 
                                       .Parent 
                                       .Parent 
                                       .Parent 
                                       .FullName;

            string dbPath = Path.Combine(projectRootPath, "RegistrosEntradaSaida.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        public DbSet<EmpresaEntity> Empresas { get; set; }
        public DbSet<VeiculoEntity> Veiculos { get; set; }
        public DbSet<MotoristaEntity> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VeiculoEntity>()
                .HasOne(v => v.Empresa)     
                .WithMany(e => e.Veiculos)  
                .HasForeignKey(v => v.EmpresaId); 
        }
    }
}
