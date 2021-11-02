using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

public partial class Views_Login : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        if (Session["user"] != null && Session["token"] != null) //hay sesion abierta
        {
            int rol = ((EUsuario)Session["user"]).RolId;

            if (rol == 1)
            {
                HttpContext.Current.Response.Redirect("../Views/PerfilAdministrador.aspx");
            }
            else
            {
                HttpContext.Current.Response.Redirect("../Views/Perfil.aspx");
            }

        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {

        EUsuario user = new EUsuario();
        user.Correo = txtCorreo.Text.ToUpper();
        user.Clave = txtClave.Text;
       
        var url = ConfigurationManager.AppSettings["HOST"]+"/Usuario/login";
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
                            Session["user"] = resp.User;
                            Session["token"] = resp.Token;
                        

                    }
                }
            }
        }
        catch (WebException ex)
        {
            // Handle error
        }

    }
}

 