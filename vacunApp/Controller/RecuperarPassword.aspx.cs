using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI;

public partial class Views_RecuperarPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null) //hay sesion abierta
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
        Recursos recursos = new Recursos();
        string correo = txtCorreo.Text.ToUpper();

        //Genera nuevo codigo
        int longitud = 7;
        Guid miGuid = Guid.NewGuid();
        string token = Convert.ToBase64String(miGuid.ToByteArray());
        token = token.Replace("=", "").Replace("+", "");
        token = token.Substring(0, longitud);

        Respuesta resp = new LUsuario().recuperarPassword(correo, token);
        if (resp.User != null) { 
        string asunto = "Recuperación Contraseña";
        string body = "";
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>correo</title>";
        body += "</head>";
        body += "<h1>Recuperacion de Contraseña - VacunApp</h1>";
        body += "<h3>Su nueva contraseña es:</h3>";
        body += "<p>" + token + "</p>";
        body += "<p>Por favor cambiela al momento de iniciar sesión.</p>";
        body += "<body>";
        body += "</body>";
        body += "</html>";

        recursos.SendMail(resp.User.Correo, body, asunto);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

    }
}
