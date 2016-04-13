using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Gapo_Permissionamento.Entities;

namespace Gapo_Permissionamento.Context
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany(usuario => usuario.Perfis)
                .WithMany(perfil => perfil.Usuarios)
                .Map(up =>
                {
                    up.MapLeftKey("UsuarioID");
                    up.MapRightKey("PerfilID");
                    up.ToTable("UsuarioPerfil");
                });
        }
    }
}