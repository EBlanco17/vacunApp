using System.Collections.Generic;
using Datos;
using Utilitarios;

namespace Logica
{
    public class LSolicitud
    {
        public Respuesta insertarSolicitud(ESolicitud solicitud) {

            Respuesta resp = new Respuesta();
            new DAOSolicitud().insertarSolicitud(solicitud);
            resp.User = null;
            resp.Mensaje = "Solicitud enviada correctamente";
            resp.Url = "../Views/RecepcionPQRS.aspx";
            return resp;
        }

        public Respuesta borrarSolicitudRespuesta(int id)
        {
            Respuesta resp = new Respuesta();
            new DAOSolicitud().deleteSolicitud(id);
            resp.User = null;
            resp.Mensaje = "Respuesta a solicitud enviada";
            resp.Url = "../Views/RecepcionPQRS.aspx";
            return resp;
        }

        public List<ESolicitud> verRegistros()
        {
            return new DAOSolicitud().registros();
        }

        public ESolicitud verSolicitud(int id)
        {
            return new DAOSolicitud().getSolicitudXId(id);
        }
    }
}
