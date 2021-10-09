using System.Data.Entity;
using Utilitarios;

namespace Datos
{
    class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;

        public Mapeo() : base("name=MiConexion")
        { }

        public DbSet<EUsuario> usuario { get; set; }
        public DbSet<ESolicitudAdmin> solAdmin { get; set; }
        public DbSet<ESolicitud> solicitudes { get; set; }
        public DbSet<ELocalidad>localidades { get; set; }
        public DbSet<EBarrio> barrios { get; set; }
        public DbSet<EFormulario> formulario { get; set; }
    }
}
