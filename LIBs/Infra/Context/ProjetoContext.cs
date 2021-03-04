using LIBs.Domain;
using Microsoft.EntityFrameworkCore;

namespace LIBs.Infra.Context
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options)
   : base(options)
        { }

        public DbSet<Vendedor> Vendedores { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }

        //public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Keys
            modelBuilder.Entity<Venda>().HasKey(x => x.Codigo);
            modelBuilder.Entity<Veiculo>().HasKey(x => x.Codigo);
            modelBuilder.Entity<Vendedor>().HasKey(x => x.Codigo);



            modelBuilder.Entity<Venda>().HasOne(v => v.Vendedor).WithMany(x => x.Vendas).HasForeignKey(x => x.VendedorCodigo);
            modelBuilder.Entity<Vendedor>().HasMany(x => x.Vendas).WithOne(x => x.Vendedor);

        }
    }

}