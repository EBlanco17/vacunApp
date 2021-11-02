using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios { 

[Serializable]
[Table("solicitudes", Schema = "administrativo")]
public class ESolicitud
{
    private int id;
    private string tipoSolicitud;
    private int usuarioId;
    private DateTime fechaIngreso;
    private string mensaje;
    private DateTime fechaLimite;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("tipo_solicitud")]
    public string TipoSolicitud { get => tipoSolicitud; set => tipoSolicitud = value; }
    [Column("usuario_id")]
    public int UsuarioId { get => usuarioId; set => usuarioId = value; }
    [Column("fecha_ingreso")]
    public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
    [Column("mensaje")]
    public string Mensaje { get => mensaje; set => mensaje = value; }
    [Column("fecha_limite")]
    public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
}
}