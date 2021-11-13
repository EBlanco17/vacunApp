using System;
using System.Web;
using Utilitarios;
using System.Web.UI;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Logica;


public partial class Views_verSolicitudPQRS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["user"] != null && ((EUsuario)Session["user"]).RolId == 1 && Session["token"] != null)
            {
                ESolicitud solicitud = new ESolicitud();
                solicitud.Id = int.Parse(Request.QueryString.Get(0));

                var url = ConfigurationManager.AppSettings["HOST"] + "/Solicitud/verSolictud";
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
                                ESolicitud sol = JsonConvert.DeserializeObject<ESolicitud>(responseBody);
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

    protected void cargarSolicitud(ESolicitud solicitud)
    {
        EUsuario usuario = new EUsuario();
        usuario.Id = solicitud.UsuarioId;

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

                        txtTipo.Text = solicitud.TipoSolicitud;
                        txtFec.Text = solicitud.FechaIngreso.ToShortDateString();
                        txtDesc.Text = solicitud.Mensaje;
                        txtRem.Text = user.Nombres + " " + user.Apellidos;
                        txtCorreo.Text = user.Correo;
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

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        

        ESolicitud solicitud = new ESolicitud();
        solicitud.Id = int.Parse(Request.QueryString.Get(0));

        var url = ConfigurationManager.AppSettings["HOST"] + "/Solicitud/borrarSolictud";
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

    public void enviarcorreo()
    {
        Recursos recursos = new Recursos();
        string asunto = "Respuesta PQRS";
        string mensaje = txtRes.Text;
        string correo = txtCorreo.Text;
        string body = @"<!doctype html>";
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>Correo</title>";
        body += "</head>";
        body += "<h3><strong>Respuesta a</strong> " + txtTipo.Text + " <strong>tramitado en la fecha</strong> " + txtFec.Text + "</h3>";
        body += "<p><strong>Cordial Saludo: </strong>" + txtRem.Text + "</p>";
        body += "<p>Con respecto a su solicitud...</p>";
        body += "</p>" + mensaje + "</p>";
        body += "<p><strong>Atentamente: </strong>" + ((EUsuario)Session["user"]).Nombres + " " + ((EUsuario)Session["user"]).Apellidos + "</p>";
        body += "<p><strong>Correo:</strong> " + ((EUsuario)Session["user"]).Correo + "</p>";
        body += "</body>";
        body += "</body>";
        body += "</html>";

        recursos.SendMail(correo, body, asunto);

    }
}