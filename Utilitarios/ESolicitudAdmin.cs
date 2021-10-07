using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("solicitudesadmin", Schema = "administrativo")]
    public class ESolicitudAdmin
    {
        private int id;
        private int usuarioId;
        private DateTime fechaIngreso;
        private string mensaje;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("usuario_id")]
        public int UsuarioId { get => usuarioId; set => usuarioId = value; }
        [Column("fecha_ingreso")]
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        [Column("mensaje")]
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}