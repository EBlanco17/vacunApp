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

        public bool Send(string To, string Body, string Asunto)
        {
            bool respuesta = false;
            try
            {
                // Obtiene los datos de configuracion
                string servidor = "smtp.gmail.com";
                int puerto = 587;
                string from = "vacunapp21@gmail.com";
                string password = "vacun2021_app";


                MailMessage mensaje = new MailMessage();

                mensaje.To.Add(To); //Correo del destinatario
                //mensaje.CC.Add("prueba@prueba.com"); //Correo a quien quieren copiar
                //mensaje.Bcc.Add("prueba@prueba.com"); //Correo Copia oculta

                mensaje.From = new MailAddress(from);
                mensaje.Subject = Asunto; // Asunto
                mensaje.Body = Body;
                mensaje.IsBodyHtml = true; //Boleano que identifica si el cuerpo esta en html par auna plantilla
                mensaje.SubjectEncoding = Encoding.UTF8;

                SmtpClient cliente = new SmtpClient(servidor, puerto);
                cliente.Credentials = new NetworkCredential(from, password);
                cliente.EnableSsl = false;
                cliente.Credentials = CredentialCache.DefaultNetworkCredentials;
                // Se envia el mail
                cliente.Send(mensaje);
                return respuesta;
            }
            catch (Exception ex)
            {
                return respuesta;
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
        //public void SendMail(string To, string Body, string Asunto)
        //{
        //    string from = "vacunapp21@gmail.com";
        //    string fromName = "VacunApp 2021";
        //    string smtpUserName = "AKIAUV72BIA33VRDST6O";
        //    string smtpPassword = "BIg5wZvvpOQ4IBQTlT6iVU1WtjNL/mxva8+cHzK1GXiD";
        //    string configSet = "ConfigSet";

        //    string host = "email-smtp.sa-east-1.amazonaws.com";
        //    int port = 587;


        //    //MailMessage message = new MailMessage();
        //    //message.IsBodyHtml = true;
        //    //message.From = new MailAddress(from, fromName);
        //    //message.To.Add(new MailAddress(To));
        //    //message.Subject = Asunto;
        //    //message.Body = Body;

        //    //message.Headers.Add("X-SES-CONFIGURATION-SET", configSet);

        //    //using (var client = new SmtpClient(host, port))
        //    //{
        //    //    client.Credentials = new NetworkCredential(smtpUserName, smtpPassword);

        //    //    client.EnableSsl = true;

        //    //    try
        //    //    {
        //    //        client.Send(message);
        //    //    }
        //    //    catch(Exception ex)
        //    //    {
        //    //        Console.WriteLine(ex);
        //    //    }
        //    //}

        //}
    }
}