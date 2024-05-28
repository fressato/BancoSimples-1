using BancoSimples.Domain.Conta;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BancoSimples.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ClientePessoa> ClientePessoa { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<AbrirNovaContas> AbrirNovaConta { get; set; }
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<Notification>();
            builder.Entity<ClientePessoa>()
                .Property(p => p.Id).IsRequired();
            builder.Entity<ClientePessoa>()
                .Property(p => p.Nome).HasMaxLength(100).IsRequired();
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Server=localhost;Database=IWantDb;User Id=sa;Password=@Sql2024;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES");

        internal void AbrirConta(AbrirNovaContas contaNova)
        {
            throw new NotImplementedException();
        }
    }
}   





    

