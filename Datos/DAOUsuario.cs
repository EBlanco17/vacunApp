using System;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DAOUsuario
    {
        
        public int comprobarBD(string correo)
        {
            return new Mapeo().usuario.Where(x => x.Correo.Equals(correo)).Count();
        }
        public int comprobarDocumentos(string documento)
        {
            return new Mapeo().usuario.Where(x => x.Documento.Equals(documento)).Count();
        }

        public EUsuario correoRegistrado(string documento)
        {
            return new Mapeo().usuario.Where(x => x.Documento.Equals(documento)).FirstOrDefault();
        }
        public EUsuario login(EUsuario user)
        {
            return new Mapeo().usuario.Where(x => x.Correo.Equals(user.Correo) && x.Clave.Equals(user.Clave)).FirstOrDefault();
        }

        public void createUser(EUsuario user)
        {
            using (var db = new Mapeo())
            {
                db.usuario.Add(user); //add nuevo usuario
                db.SaveChanges();//confirmar el guardado
            }
        }

        public EUsuario recuperarPassword(string correo)
        {
            return new Mapeo().usuario.Where(x => x.Correo.Equals(correo)).FirstOrDefault();
        }

        public void updateUser(EUsuario user)
        {
            using (var db = new Mapeo())
            {
                var usuarioEditar = db.usuario.FirstOrDefault(x => x.Id == user.Id);
                usuarioEditar.Nombres = user.Nombres;
                usuarioEditar.Apellidos = user.Apellidos;
                usuarioEditar.Documento = user.Documento;
                usuarioEditar.Telefono = user.Telefono;
                usuarioEditar.Correo = user.Correo;
                db.SaveChanges();//confirmar el guardado
            }
        }

        public void updatePassword(EUsuario user)
        {
            using (var db = new Mapeo())
            {
                var usuarioEditar = db.usuario.FirstOrDefault(x => x.Id == user.Id);
                usuarioEditar.Clave = user.Clave;
                db.SaveChanges();//confirmar el guardado

            }
        }

        public EUsuario getUsuarioXId(int id)
        {
            return new Mapeo().usuario.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
