using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{

    [Serializable]
    [Table("usuario", Schema = "security")]
    public class EUsuario
    {
        private int id;
        private string nombres;
        private string apellidos;
        private string documento;
        private DateTime fechaNacimiento;
        private string genero;
        private string telefono;
        private string correo;
        private string clave;
        private int rolId;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombres")]
        public string Nombres { get => nombres; set => nombres = value; }
        [Column("apellidos")]
        public string Apellidos { get => apellidos; set => apellidos = value; }
        [Column("documento")]
        public string Documento { get => documento; set => documento = value; }
        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        [Column("genero")]
        public string Genero { get => genero; set => genero = value; }
        [Column("telefono")]
        public string Telefono { get => telefono; set => telefono = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("clave")]
        public string Clave { get => clave; set => clave = value; }
        [Column("rol_id")]
        public int RolId { get => rolId; set => rolId = value; }

    }
}