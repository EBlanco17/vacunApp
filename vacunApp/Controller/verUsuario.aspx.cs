using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;

public partial class Views_verUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["user"] != null && ((EUsuario)Session["user"]).RolId == 1 && Session["token"] != null)
            {

                ESolicitudAdmin solicitud = new ESolicitudAdmin();
                solicitud.UsuarioId = int.Parse(Request.QueryString.Get(0));

                var url = ConfigurationManager.AppSettings["HOST"] + "/SolicitudAdmin/verSolictud";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["Authorization"] = "Bearer " + Session["token"];
                string json = JsonConvert.SerializeObject(solicitud);
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
                                ESolicitudAdmin sol = JsonConvert.DeserializeObject<ESolicitudAdmin>(responseBody);
                                cargarSolicitud(sol);
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    Session["user"] = null;
                    Session["token"] = null;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No está autorizado para esta acción');window.location ='../Views/Login.aspx';", true);

                }

            }
            else
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");

            }
        }
    }

    public void cargarSolicitud(ESolicitudAdmin solicitud)
    {

        EUsuario usuario = new EUsuario();
        usuario.Id = int.Parse(Request.QueryString.Get(0));

        var url = ConfigurationManager.AppSettings["HOST"] + "/Usuario/buscarRegistro";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(usuario);
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
                        EUsuario user = JsonConvert.DeserializeObject<EUsuario>(responseBody);
                        txtRem.Text = user.Nombres + " " + user.Apellidos;
                        txtCorreo.Text = user.Correo;
                        txtFechaNac.Text = user.FechaNacimiento.ToShortDateString();
                        txtGen.Text = user.Genero;
                        txtDoc.Text = user.Documento;
                        txtFec.Text = solicitud.FechaIngreso.ToShortDateString();
                        txtMsg.Text = solicitud.Mensaje;
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Session["user"] = null;
            Session["token"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No está autorizado para esta acción');window.location ='../Views/Login.aspx';", true);

        }


    }
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["token"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {

        EUsuario user = new EUsuario();
        user.Id = Convert.ToInt32(int.Parse(Request.QueryString.Get(0)));
        var url = ConfigurationManager.AppSettings["HOST"] + "/SolicitudAdmin/cambiarRol";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(user);
        request.Method = "PUT";
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
                        enviarcorreo();
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Session["user"] = null;
            Session["token"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No está autorizado para esta acción');window.location ='../Views/Login.aspx';", true);

        }

    }

    protected void btnRechazar_Click(object sender, EventArgs e)
    {

        Recursos recursos = new Recursos();
        EUsuario user = new EUsuario();
        user.Id = Convert.ToInt32(int.Parse(Request.QueryString.Get(0)));

        var url = ConfigurationManager.AppSettings["HOST"] + "/SolicitudAdmin/rechazarSolictud";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
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
                        correorechazado();
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Session["user"] = null;
            Session["token"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No está autorizado para esta acción');window.location ='../Views/Login.aspx';", true);

        }
    }

    public void enviarcorreo()
    {
        Recursos recursos = new Recursos();
        string asunto = "Solicitud administrador";
        string body = "";
        string correo = txtCorreo.Text;
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>correo</title>";
        body += "</head>";
        body += "<h1>Ha sido aceptado como administrador</h1>";
        body += "<h3>Ahora tendrá acceso a funcionalidades extra</h3>";
        body += "<p>"+txtRes.Text+"</p>";
        body += "<body>";
        body += "<body>";
        body += "</body>";
        body += "</html>";

        recursos.SendMail(correo, body, asunto);
    }
    public void correorechazado()
    {
        Recursos recursos = new Recursos();
        string asunto = "Solicitud administrador";
        string body = "";
        string correo = txtCorreo.Text;
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>correo</title>";
        body += "</head>";
        body += "<h1>Ha sido rechazado como administrador</h1>";
        body += "<h3>En este momento no puede ser administrador, intentelo más adelante</h3>";
        body += "<p>" + txtRes.Text + "</p>";
        body += "<body>";
        body += "<body>";
        body += "</body>";
        body += "</html>";

        recursos.SendMail(correo, body, asunto);
    }
}