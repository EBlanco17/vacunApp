using System.Collections.Generic;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DAOFormulario
    {
        public List<ELocalidad> listar()
        {
            return new Mapeo().localidades.ToList();
        }

        public List<EBarrio> listarBarrios(int idLocalidad)
        {
            return new Mapeo().barrios.Where(x => x.LocalidadId == idLocalidad).ToList();
        }

        public int verificarFormXUsuario(int id)
        {
            return new Mapeo().formulario.Where(x => x.UsuarioId == id).Count();
        }
        public void guardar(EFormulario formulario)
        {
            using (var db = new Mapeo())
            {
                db.formulario.Add(formulario); //add nuevo usuario
                db.SaveChanges();//confirmar el guardado
            }
        }

        public ELocalidad getLocalidadXId(int id)
        {
            return new Mapeo().localidades.Where(x => x.Id.Equals(id)).FirstOrDefault();
            
        }
        public EBarrio getBarrioXId(int id)
        {
            return new Mapeo().barrios.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public EFormulario GetFormulario(int idUser)
        {
            return new Mapeo().formulario.Where(x => x.UsuarioId.Equals(idUser)).FirstOrDefault();
        }
    }
}