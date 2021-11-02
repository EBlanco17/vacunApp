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
        private int edad;
        private DateTime fechaIngreso;
        private int localidadId;
        private int barrioId;
        private string eps;
        private string diagnosticoCovid;
        private string trabajoCovid;
        private string trabajoNoCovid;
        private string estudiaSalud;
        private string cuidaMayor;
        private string trabajoEducacion;
        private string trabajoSeguridad;
        private string trabajoCadaveres;
        private string trabajoReclusion;
        private string trabajoBombero;
        private string trabajoAeropuerto;
        private string diabetes;
        private string insuficienciaRenal;
        private string vih;
        private string cancer;
        private string tuberculosis;
        private string epoc;
        private string asma;
        private string obesidad;
        private string embarazo;
        private int etapa;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("usuario_id")]
        public int UsuarioId { get => usuarioId; set => usuarioId = value; }
        [Column("edad")]
        public int Edad { get => edad; set => edad = value; }
        [Column("fecha_ingreso")]
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        [Column("localidad_id")]
        public int LocalidadId { get => localidadId; set => localidadId = value; }
        [Column("barrio_id")]
        public int BarrioId { get => barrioId; set => barrioId = value; }
        [Column("eps")]
        public string Eps { get => eps; set => eps = value; }
        [Column("diagnosticocovid")]
        public string DiagnosticoCovid { get => diagnosticoCovid; set => diagnosticoCovid = value; }
        [Column("trabajocovid")]
        public string TrabajoCovid { get => trabajoCovid; set => trabajoCovid = value; }
        [Column("trabajonocovid")]
        public string TrabajoNoCovid { get => trabajoNoCovid; set => trabajoNoCovid = value; }
        [Column("estudiasalud")]
        public string EstudiaSalud { get => estudiaSalud; set => estudiaSalud = value; }
        [Column("cuidamayor")]
        public string CuidaMayor { get => cuidaMayor; set => cuidaMayor = value; }
        [Column("trabajoeducacion")]
        public string TrabajoEducacion { get => trabajoEducacion; set => trabajoEducacion = value; }
        [Column("trabajoseguridad")]
        public string TrabajoSeguridad { get => trabajoSeguridad; set => trabajoSeguridad = value; }
        [Column("trabajocadaveres")]
        public string TrabajoCadaveres { get => trabajoCadaveres; set => trabajoCadaveres = value; }
        [Column("trabajoreclusion")]
        public string TrabajoReclusion { get => trabajoReclusion; set => trabajoReclusion = value; }
        [Column("trabajobombero")]
        public string TrabajoBombero { get => trabajoBombero; set => trabajoBombero = value; }
        [Column("trabajoaeropuerto")]
        public string TrabajoAeropuerto { get => trabajoAeropuerto; set => trabajoAeropuerto = value; }
        [Column("diabetes")]
        public string Diabetes { get => diabetes; set => diabetes = value; }
        [Column("ensuficienciarenal")]
        public string InsuficienciaRenal { get => insuficienciaRenal; set => insuficienciaRenal = value; }
        [Column("vih")]
        public string Vih { get => vih; set => vih = value; }
        [Column("cancer")]
        public string Cancer { get => cancer; set => cancer = value; }
        [Column("tuberculosis")]
        public string Tuberculosis { get => tuberculosis; set => tuberculosis = value; }
        [Column("epoc")]
        public string Epoc { get => epoc; set => epoc = value; }
        [Column("asma")]
        public string Asma { get => asma; set => asma = value; }
        [Column("obesidad")]
        public string Obesidad { get => obesidad; set => obesidad = value; }
        [Column("embarazo")]
        public string Embarazo { get => embarazo; set => embarazo = value; }
        [Column("etapa")]
        public int Etapa { get => etapa; set => etapa = value; }
       
    }
}
