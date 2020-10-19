using DesafioWebmotors.Domain.Entities;
using DesafioWebmotors.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DesafioWebmotors.Infra.Data
{
    public class DefaultDbContext : DbContext
    {
        public virtual DbSet<AnuncioWebmotors> AnuncioWebmotors { get; set; }

        public DefaultDbContext()
        {

        }

        public DefaultDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnuncioWebmotorsConfiguration());
        }
    }
}
