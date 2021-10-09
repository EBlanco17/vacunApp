using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Utilitarios;

namespace Logica
{
    public class LFormulario
    {
        public List<ELocalidad> listarLocalidades()
        {
            return new DAOFormulario().listar();
        }

        public List<EBarrio> listarBarrios(int id)
        {
            return new DAOFormulario().listarBarrios(id);
        }

        public Respuesta comprobarFormulario(int id)
        {
            Respuesta resp = new Respuesta();
            int numForms = new DAOFormulario().verificarFormXUsuario(id);
            if (numForms == 0)
            {
                resp.User = null;
                resp.Mensaje = null;
                resp.Url = null;
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "Ya se realizo la solictud antes";
                resp.Url = "../Views/Perfil.aspx";
            }
            return resp;

        }

        public EFormulario GetFormulario(int idUsuario)
        {
            return new DAOFormulario().GetFormulario(idUsuario);
        }
        
        public string getNombreLocalidad(int id)
        {
            return new DAOFormulario().getLocalidadXId(id);
        }
        public string getNombreBarrio(int id)
        {
            return new DAOFormulario().getBarrioXId(id);
        }
        public Respuesta guardarFormulario()
        {
            Respuesta resp = new Respuesta();

            return resp;
        }
    }
}
