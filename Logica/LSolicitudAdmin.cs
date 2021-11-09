using System.Collections.Generic;
using Utilitarios;
using Datos;

namespace Logica
{
    public class LSolicitudAdmin
    {
        public Respuesta comprobarSolicitud(int id)
        {
            Respuesta resp = new Respuesta();
            int numSolicitudes = 0;
            numSolicitudes = new DAOSolicitudAdmin().verificarSolAdmin(id);
            if (numSolicitudes == 0)
            {
                resp.User = null;
                resp.Mensaje = "Realice una petición...";
                resp.Url = "../Views/MensajeSolicitudAdmin.aspx";
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "Ya se realizo la solictud antes";
                resp.Url = "../Views/Perfil.aspx";
            }
            return resp;
        }


        public Respuesta solicitarAdmin(ESolicitudAdmin solAdmin)
        {
            Respuesta resp = new Respuesta();

            new DAOSolicitudAdmin().solicitarAdmin(solAdmin);
            resp.User = null;
            resp.Mensaje = "Mensaje Enviado";
            resp.Url = "../Views/Perfil.aspx";

            return resp;
        }

        public Respuesta cambiarRol(EUsuario user)
        {
            Respuesta resp = new Respuesta();
            new DAOSolicitudAdmin().updateRol(user.Id);
            new DAOSolicitudAdmin().deleteUserRol(user.Id);
            resp.User = null;
            resp.Mensaje = "Datos Actualizados Correctamente";
            resp.Url = "../Views/SolicitudesAdministrador.aspx";
            return resp;

        }

        public List<ESolicitudAdmin> verRegistros()
        {
            return new DAOSolicitudAdmin().registros(); ;
        }
        public Respuesta rechazarSolicitud(int id)
        {
            Respuesta resp = new Respuesta();
            new DAOSolicitudAdmin().deleteUserRol(id);
            resp.User = null;
            resp.Mensaje = "Solicitud rechazada";
            resp.Url = "../Views/SolicitudAdmin.aspx";
            return resp;
        }

        public ESolicitudAdmin verSolicitud(int id)
        {
            return new DAOSolicitudAdmin().getSolicitudXId(id);
        }
    }
}
