using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilitarios;

/// <summary>
/// Funciones que utiliza la aplicacion para guardar, editar, eliminar registro en la tabla solicitudAmd de la Base de Datos
/// </summary>

namespace Datos
{
    public class DAOSolicitudAdmin
    {
        public int verificarSolAdmin(int id)
        {
            return new Mapeo().solAdmin.Where(x => x.UsuarioId == id).Count();
        }

        public void solicitarAdmin(ESolicitudAdmin solAmd)
        {
            using (var db = new Mapeo())
            {
                db.solAdmin.Add(solAmd); //add nuevo usuario
                db.SaveChanges();//confirmar el guardado
            }
        }

        public List<ESolicitudAdmin> registros()
        {
            return new Mapeo().solAdmin.OrderBy(x => x.FechaIngreso).ToList();
        }

        public void updateRol(EUsuario user)
        {
            using (var db = new Mapeo())
            {
                var usuarioEditar = db.usuario.FirstOrDefault(x => x.Id == user.Id);
                usuarioEditar.RolId = 1;
                db.SaveChanges();//confirmar el guardado
            }
        }

        public void deleteUserRol(int id)
        {
            using (var db = new Mapeo())
            {
                var itemToRemove = db.solAdmin.SingleOrDefault(x => x.UsuarioId == id); //returns a single item.

                if (itemToRemove != null)
                {
                    db.solAdmin.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
        }

        public ESolicitudAdmin getSolicitudXId(int solicitudId)
        {
            using (var db = new Mapeo())
            {
                return db.solAdmin.Where(x => x.Id == solicitudId).FirstOrDefault();
            }
        }
    }
}