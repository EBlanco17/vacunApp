using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("formulario", Schema = "administrativo")]
    public class EFormulario
    {
        private int id;
        private int usuarioId;
        private DateTime fechaIngreso;
        private int localidadId;
        private int barrioId;
        private string eps;
        private char diagnosticoCovid;
        private char trabajoCovid;
        private char trabajoNoCovid;
        private char estudiaSalud;
        private char cuidaMayor;
        private char trabajoEducacion;
        private char trabajoSeguridad;
        private char trabajoCadaveres;
        private char trabajoReclusion;
        private char trabajoBombero;
        private char trabajoAeropuerto;
        private char diabetes;
        private char insuficienciaRenal;
        private char vih;
        private char cancer;
        private char tuberculosis;
        private char epoc;
        private char asma;
        private char obesidad;
        private char embarazo;
        private char etapa;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("usuario_id")]
        public int UsuarioId { get => usuarioId; set => usuarioId = value; }
        [Column("fecha_ingreso")]
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        [Column("localidad_id")]
        public int LocalidadId { get => localidadId; set => localidadId = value; }
        [Column("barrio_id")]
        public int BarrioId { get => barrioId; set => barrioId = value; }
        [Column("eps")]
        public string Eps { get => eps; set => eps = value; }
        [Column("diagnosticoCovid")]
        public char DiagnosticoCovid { get => diagnosticoCovid; set => diagnosticoCovid = value; }
        [Column("trabajoCovid")]
        public char TrabajoCovid { get => trabajoCovid; set => trabajoCovid = value; }
        [Column("trabajoNoCovid")]
        public char TrabajoNoCovid { get => trabajoNoCovid; set => trabajoNoCovid = value; }
        [Column("estudiaSalud")]
        public char EstudiaSalud { get => estudiaSalud; set => estudiaSalud = value; }
        [Column("cuidaMayor")]
        public char CuidaMayor { get => cuidaMayor; set => cuidaMayor = value; }
        [Column("trabajoEducacion")]
        public char TrabajoEducacion { get => trabajoEducacion; set => trabajoEducacion = value; }
        [Column("trabajoSeguridad")]
        public char TrabajoSeguridad { get => trabajoSeguridad; set => trabajoSeguridad = value; }
        [Column("trabajoCadaveres")]
        public char TrabajoCadaveres { get => trabajoCadaveres; set => trabajoCadaveres = value; }
        [Column("trabajoReclusion")]
        public char TrabajoReclusion { get => trabajoReclusion; set => trabajoReclusion = value; }
        [Column("trabajoBombero")]
        public char TrabajoBombero { get => trabajoBombero; set => trabajoBombero = value; }
        [Column("trabajoAeropuerto")]
        public char TrabajoAeropuerto { get => trabajoAeropuerto; set => trabajoAeropuerto = value; }
        [Column("diabetes")]
        public char Diabetes { get => diabetes; set => diabetes = value; }
        [Column("ensuficienciaRenal")]
        public char InsuficienciaRenal { get => insuficienciaRenal; set => insuficienciaRenal = value; }
        [Column("vih")]
        public char Vih { get => vih; set => vih = value; }
        [Column("cancer")]
        public char Cancer { get => cancer; set => cancer = value; }
        [Column("tuberculosis")]
        public char Tuberculosis { get => tuberculosis; set => tuberculosis = value; }
        [Column("epoc")]
        public char Epoc { get => epoc; set => epoc = value; }
        [Column("asma")]
        public char Asma { get => asma; set => asma = value; }
        [Column("obesidad")]
        public char Obesidad { get => obesidad; set => obesidad = value; }
        [Column("embarazo")]
        public char Embarazo { get => embarazo; set => embarazo = value; }
        [Column("etapa")]
        public char Etapa { get => etapa; set => etapa = value; }
    }
}
