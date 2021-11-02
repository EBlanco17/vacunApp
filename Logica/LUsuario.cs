using Datos;
using System;
using Utilitarios;

namespace Logica
{
    public class LUsuario
    {
        public Respuesta login(EUsuario user, string token)
        {
            EUsuario usuario = new EUsuario();
            usuario.Correo = user.Correo.ToUpper();
            usuario.Clave = Encrypt.GetSHA256(user.Clave);

            user = new DAOUsuario().login(usuario);
            Respuesta resp = new Respuesta();

            if (user != null)
            {
                resp.User = user;
                resp.Mensaje = "Bienvenido: " + user.Nombres;
                resp.Url = "../Views/Perfil.aspx";
                resp.Token = token;
            }
           
            return resp;
        }

        public Respuesta login(EUsuario user)
        {
            EUsuario usuario = new EUsuario();
            usuario.Correo = user.Correo.ToUpper();
            usuario.Clave = Encrypt.GetSHA256(user.Clave);

            user = new DAOUsuario().login(usuario);
            Respuesta resp = new Respuesta();

            if (user == null)
            {
                resp.User = null;
                resp.Mensaje = "Datos incorrectos";
                resp.Url = "../Views/Login.aspx";

            }
            else
            {
                resp.User = user;
            }
           
            return resp;
        }

        public Respuesta registro(EUsuario user)
        {
            int numCorreos = 0;
            int numDocumentos = 0;
            numCorreos = new DAOUsuario().comprobarBD(user.Correo);
            numDocumentos = new DAOUsuario().comprobarDocumentos(user.Documento);
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
                    string email = ((EUsuario)new DAOUsuario().correoRegistrado(user.Documento)).Correo;
                    resp.Mensaje = "Error al crear usuario, documento ya registrado con el correo: "+ email;
                    resp.Url = "../Views/Registro.aspx";
                }
            }
            return resp;

        }

        public Respuesta recuperarPassword(EUsuario user)
        {
            Respuesta resp = new Respuesta();
            EUsuario usuario = new EUsuario();
            usuario.Correo = user.Correo.ToUpper();
           
            user = new DAOUsuario().recuperarPassword(usuario.Correo);

            //int longitud = 7;
            //Guid miGuid = Guid.NewGuid();
            //string token = Convert.ToBase64String(miGuid.ToByteArray());
            //token = token.Replace("=", "").Replace("+", "");
            //token = token.Substring(0, longitud);
            //string pass = Encrypt.GetSHA256(token);

          

            if (user != null)
            {

                user.Clave = Encrypt.GetSHA256(user.Documento);
                new DAOUsuario().updatePassword(user);
                resp.User = user;
                resp.Mensaje = "Su nueva contraseña es su No.Documento";
                resp.Url = "../Views/Login.aspx";
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "El correo no se ha encontrado";
                resp.Url = "../Views/RecuperarPassword.aspx";
            }

            return resp;
        }

        public Respuesta actualizarDatos(EUsuario user)
        {
            Respuesta resp = new Respuesta();
            new DAOUsuario().updateUser(user);
            resp.User = null;
            resp.Token = null;
            resp.Mensaje = "Datos Actualizados Correctamente";
            resp.Url = "../Views/Login.aspx";
            return resp;  
        }

        public Respuesta actualizarPassword(EUsuario user)
        {
            Respuesta resp = new Respuesta();
            new DAOUsuario().updatePassword(user);
            resp.User = null;
            resp.Token = null;
            resp.Mensaje = "Datos Actualizados Correctamente";
            resp.Url = "../Views/Login.aspx";
            return resp;
        }

        public EUsuario buscarRegistro(int id)
        {
            return new DAOUsuario().getUsuarioXId(id);
             
        }
    }
}
