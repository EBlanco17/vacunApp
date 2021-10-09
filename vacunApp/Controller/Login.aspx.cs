using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;

public partial class Views_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["user"] != null) //hay sesion abierta
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
        user.Clave = Encrypt.GetSHA256(txtClave.Text);

        Respuesta resp = new LUsuario().login(user);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);
        Session["user"] = resp.User;
        

    }
}