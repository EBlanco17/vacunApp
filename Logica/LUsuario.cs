using Datos;
using Utilitarios;

namespace Logica
{
    public class LUsuario
    {
        public Respuesta login(EUsuario user)
        {
            user = new DAOUsuario().login(user);
            Respuesta resp = new Respuesta();

            if (user != null)
            {
                resp.User = user;
                resp.Mensaje = "Bienvenido: " + user.Nombres;
                resp.Url = "../Views/Perfil.aspx";
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "Datos incorrectos";
                resp.Url = "../Views/Login.aspx";
            }
            return resp;
        }

        public Respuesta registro(EUsuario user, string correo, string documento)
        {
            int numCorreos = 0;
            int numDocumentos = 0;
            numCorreos = new DAOUsuario().comprobarBD(correo);
            numDocumentos = new DAOUsuario().comprobarDocumentos(documento);
            Respuesta resp = new Respuesta();

            if (numCorreos == 0 && numDocumentos == 0)
            {
                new DAOUsuario().createUser(user);
                resp.User = null;
                resp.Mensaje = "Usuario Creado";
                resp.Url = "../Views/Login.aspx";
            }
            else
            {
                if(numCorreos > 0) { 
                resp.User = null;
                resp.Mensaje = "Error al crear usuario, correo ya registrado";
                resp.Url = "../Views/Registro.aspx";
                }
                else
                {
                    resp.User = null;
                    string email = ((EUsuario)new DAOUsuario().correoRegistrado(documento)).Correo;
                    resp.Mensaje = "Error al crear usuario, documento ya registrado con el correo: "+ email;
                    resp.Url = "../Views/Registro.aspx";
                }
            }
            return resp;

        }

        public Respuesta recuperarPassword(string correo,string clave)
        {
            Respuesta resp = new Respuesta();
            EUsuario user = new EUsuario();
           
            user = new DAOUsuario().recuperarPassword(correo);
            

            if (user != null)
            {
                user.Clave = clave;
                new DAOUsuario().updatePassword(user);
                resp.User = user;
                resp.Mensaje = "Correo enviado";
                resp.Url = "../Views/Login.aspx";
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "El correo no se ha encontradoo";
                resp.Url = "../Views/RecuperarPassword.aspx";
            }

            return resp;
        }

        public Respuesta actualizarDatos(EUsuario user)
        {
            Respuesta resp = new Respuesta();
            new DAOUsuario().updateUser(user);
            resp.User = null;
            resp.Mensaje = "Datos Actualizados Correctamente";
            resp.Url = "../Views/Login.aspx";
            return resp;  
        }

        public Respuesta actualizarPassword(EUsuario user)
        {
            Respuesta resp = new Respuesta();
            new DAOUsuario().updatePassword(user);
            resp.User = null;
            resp.Mensaje = "Datos Actualizados Correctamente";
            resp.Url = "../Views/Login.aspx";
            return resp;
        }

        public Respuesta buscarRegistro(int id)
        {
            Respuesta resp = new Respuesta();
            resp.User = new DAOUsuario().getUsuarioXId(id);
            return resp;
        }
    }
}
