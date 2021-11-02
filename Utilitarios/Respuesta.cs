
namespace Utilitarios
{
    public class Respuesta
    {
        private EUsuario user;
        private string mensaje;
        private string url;
        private string token;

        public EUsuario User { get => user; set => user = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string Url { get => url; set => url = value; }
        public string Token { get => token; set => token = value; }
    }
}
