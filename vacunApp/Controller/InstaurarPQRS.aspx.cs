using System;
using System.Web;
using Utilitarios;
using System.Web.UI;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;

public partial class Views_PqrsEnvia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || ((EUsuario)Session["user"]).RolId == 1 || Session["token"] == null)
        {
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["token"] = null;
        HttpContext.Current.Response.Redirect("../Views/Login.aspx");
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        DateTime fecha = DateTime.Today;
        if (txtReport.Text.Length < 50)
        {
            HttpContext.Current.Response.Write("<script>alert('Registre una mejor descripcion')</script>");
        }
        else
        {

            ESolicitud solicitud = new ESolicitud();
            solicitud.TipoSolicitud = dropTipo.SelectedValue;
            solicitud.UsuarioId = ((EUsuario)Session["user"]).Id;
            solicitud.Mensaje = txtReport.Text;
            solicitud.FechaIngreso = fecha;
            solicitud.FechaLimite = fecha.AddDays(15);


            var url = ConfigurationManager.AppSettings["HOST"] + "/Solicitud/insertar";
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

    }
}
