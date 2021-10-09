using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{

    [Serializable]
    [Table("barrios", Schema = "administrativo")]
    public class EBarrio
    {
        private int id;
        private string nombre;
        private int localidadId;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("localidad_id")]
        public int LocalidadId { get => localidadId; set => localidadId = value; }
    }
}
