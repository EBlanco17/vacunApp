using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;

/// <summary>
/// Metodos y funciones para el funcionamiento de la aplicacion
/// </summary>

namespace Logica
{
    public class Recursos
    {
        public Boolean validarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int CalcularEdad(DateTime fechaNac)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (fechaNac > fechaActual)
            {
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNac.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (fechaNac.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }

        
        public void SendMail(string To, string Body, string asunto)
        {
            string from = "vacunapp21@gmail.com";
            string displayName = "VacunApp 2021";
            string pass = "vacun2021_app";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(To);

                mail.Subject = asunto;

              
                mail.Body = Body;
                mail.IsBodyHtml = true;


                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                cliente.Credentials = new NetworkCredential(from, pass);
                cliente.EnableSsl = true;
                cliente.Send(mail);


            }
            catch (Exception ex)
            {

            }

        }
        
    }
}