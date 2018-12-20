using Aerolinea.DA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Aerolinea.DA
{
    public class AerolineaContext : DbContext
    {
        public AerolineaContext() : base("AerolineaConnection")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Pais> pais { set; get; }
        public DbSet <Aerolineas> aerolineas {set; get; }
        public DbSet<Avion> avion { set; get; }
        public DbSet <Modelo> modelo {set; get; }
        public DbSet <Asiento> asiento { set; get; }
        public DbSet <Rol> rol { set; get; }
        public DbSet<Usuario> usuario { set; get; }
        public DbSet<Reserva> reserva { set; get; }
        public DbSet<Vuelo> vuelo { set; get; }
        public DbSet <Sistema> sistema { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Para no crear tablas pluralizadas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}