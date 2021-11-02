using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;



public partial class Views_MensajeSolicitudAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["token"] == null)
        {
            Response.Redirect("../Views/Login.aspx");
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        DateTime fecha = DateTime.Today;


        ESolicitudAdmin solAdmin = new ESolicitudAdmin();

        solAdmin.UsuarioId = ((EUsuario)Session["user"]).Id;
        solAdmin.FechaIngreso = fecha;
        solAdmin.Mensaje = txtReport.Text;

        var url = ConfigurationManager.AppSettings["HOST"] + "/SolicitudAdmin/solicitar";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(solAdmin);
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

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["token"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }
}