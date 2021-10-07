using System.Collections.Generic;
using System.Linq;
using Utilitarios;
/// <summary>
/// Funciones que utiliza la aplicacion para guardar, editar, eliminar registros en la tabla solicitudes de la Base de Datos
/// </summary>
namespace Datos { 
public class DAOSolicitud
{
    public ESolicitud insertarSolicitud(ESolicitud solicitud)
    {
        using (var db = new Mapeo())
        {
            db.solicitudes.Add(solicitud);
            db.SaveChanges();

            return solicitud;
        }
    }

    public List<ESolicitud> registros()
    {
        return new Mapeo().solicitudes.OrderBy(x => x.FechaIngreso).OrderBy(x => x.FechaLimite).ToList();
    }

    public ESolicitud getSolicitudXId(int solicitudId)
    {
        using (var db = new Mapeo())
        {
            return db.solicitudes.Where(x => x.Id == solicitudId).FirstOrDefault();
        }
    }

    
    public void deleteSolicitud(int id)
    {
        using (var db = new Mapeo())
        {
            var itemToRemove = db.solicitudes.SingleOrDefault(x => x.Id == id); //returns a single item.

            if (itemToRemove != null)
            {
                db.solicitudes.Remove(itemToRemove);
                db.SaveChanges();
            }

        }

    }
    /*
  
        public List<ESolicitud> getSolicitudesXUsuario(EUsuario user)
        {
            using (var db = new Mapeo())
            {
                return (from sol in db.solicitudes
                        join estado in db.estado on sol.EstadoId equals estado.Id
                        join tipo in db.tipoSolicitud on sol.TipoSolicitudId equals tipo.Id

                        where sol.ClienteId == user.Id

                        select new
                        {
                            sol,
                            estado,
                            tipo

                        }).ToList().Select(m => new ESolicitud
                        {
                            Id = m.sol.Id,
                            FechaIngreso = m.sol.FechaIngreso,
                            NombreTipo = m.tipo.Nombre,
                            NombreEstado = m.estado.Nombre,
                            FechaLimite = m.sol.FechaLimite
                        }).ToList();
            }
        }*/
}

}