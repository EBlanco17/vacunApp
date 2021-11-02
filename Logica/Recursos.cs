using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

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