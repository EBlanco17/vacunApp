using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;

public partial class Views_CambiarPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null || Session["token"] == null)
        {
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        if(txtNueva.Text.Length > 6)
        {
       
        if ((Encrypt.GetSHA256(txtActual.Text) == ((EUsuario)Session["user"]).Clave) && (txtNueva.Text == txtCnueva.Text))
        {
            EUsuario user = new EUsuario();
            user.Id = ((EUsuario)Session["user"]).Id;
            user.Clave = Encrypt.GetSHA256(txtNueva.Text);

                var url = ConfigurationManager.AppSettings["HOST"] + "/Usuario/actualizarPassword";
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
                                Session["user"] = resp.User;
                                Session["token"] = null;
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
        else
        {
            string strMsg = "Datos Incorrectos";
            HttpContext.Current.Response.Write("<script>alert('" + strMsg + "')</script>");
        }
        }
        else
        {
            string strMsg = "La nueva contraseña debe tener una longitud de mínimo 6 caracteres";
            HttpContext.Current.Response.Write("<script>alert('" + strMsg + "')</script>");
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["token"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }
}