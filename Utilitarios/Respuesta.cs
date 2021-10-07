
namespace Utilitarios
{
    public class Respuesta
    {
        private EUsuario user;
        private string mensaje;
        private string url;

        public EUsuario User { get => user; set => user = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string Url { get => url; set => url = value; }
        
    }
}
