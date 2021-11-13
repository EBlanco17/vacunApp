using System;
using System.Web;
using Utilitarios;
using System.Web.UI;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Logica;

public partial class Views_RecuperarPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null && Session["token"] != null) //hay sesion abierta
        {
            int rol = ((EUsuario)Session["user"]).RolId;

            if (rol == 1)
            {
                HttpContext.Current.Response.Redirect("../Views/PerfilAdmininstrador.aspx");
            }
            else
            {
                HttpContext.Current.Response.Redirect("../Views/Perfil.aspx");
            }

        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        EUsuario user = new EUsuario();
        user.Correo = txtCorreo.Text;

        var url = ConfigurationManager.AppSettings["HOST"] + "/Usuario/recuperar";
        var request = (HttpWebRequest)WebRequest.Create(url);
        string json = JsonConvert.SerializeObject(user);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        // Do something with responseBody
                        Respuesta resp = JsonConvert.DeserializeObject<Respuesta>(responseBody);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);
                        if (resp.User != null)
                        {
                            enviarcorreo(resp.User);
                        }
                    }
                }
            }
        }
        catch (WebException ex)
        {
            // Handle error
        }
        
    }

    public void enviarcorreo(EUsuario user)
    {
        Recursos recursos = new Recursos();
        string asunto = "Recuperación Contraseña";
        string body = "";
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>correo</title>";
        body += "</head>";
        body += "<h1>Recuperacion de Contraseña - VacunApp</h1>";
        body += "<h3>Su nueva contraseña es su numero de documento</h3>";
        body += "<p>Por favor cambiela al momento de iniciar sesión.</p>";
        body += "<body>";
        body += "<body>";
        body += "</body>";
        body += "</html>";

        recursos.SendMail(user.Correo, body, asunto);
    }
}
