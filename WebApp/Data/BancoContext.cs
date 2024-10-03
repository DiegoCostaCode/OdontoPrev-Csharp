using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options) : base(options)
        {
            
        }

        public DbSet<UsuarioModel> CH_USUARIO { get; set; }
        public DbSet<EnderecoModel> CH_ENDERECO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsuarioModel>().HasOne(e => e.ENDERECO).WithOne().HasForeignKey<UsuarioModel>(u => u.ENDERECO_ID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
