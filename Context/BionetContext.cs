using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bionet.Entities;

namespace Bionet.Context
{
    public class BionetContext : DbContext
    {
    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Usuario>()
    .HasMany(u => u.ColetaCriadas)
    .WithOne(c => c.UsuarioCriador);

modelBuilder.Entity<Coleta>()
    .HasOne(c => c.UsuarioCriador)
    .WithMany(u => u.ColetaCriadas);

modelBuilder.Entity<Coleta>()
    .HasMany(c => c.Retiradas)
    .WithOne(r => r.Coleta);

modelBuilder.Entity<RetiradaColeta>()
    .HasOne(r => r.Coleta)
    .WithMany(c => c.Retiradas);
    }
    #endregion

        public BionetContext(DbContextOptions<BionetContext> options) : base(options){
            //Receberemos a conexão do banco e passaremos para o DbContext que gerencia a comunicação com o banco, não é necessário fazer mais nada.
        }

        public DbSet<Coleta> Coletas {get; set;}
        public DbSet<RetiradaColeta> RetiradaColetas {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}
