using System;
using System.Web;
using Utilitarios;
using Logica;

public partial class Views_CambiarPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        if ((Encrypt.GetSHA256(txtActual.Text) == ((EUsuario)Session["user"]).Clave) && (txtNueva.Text == txtCnueva.Text))
        {
            EUsuario user = new EUsuario();
            user.Id = ((EUsuario)Session["user"]).Id;
            user.Clave = Encrypt.GetSHA256(txtNueva.Text);
            Respuesta resp = new LUsuario().actualizarPassword(user);
            Session["user"] = resp.User;
            HttpContext.Current.Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
            Response.Redirect(resp.Url);
        }
        else
        {
            string strMsg = "Datos Incorrectos";
            HttpContext.Current.Response.Write("<script>alert('" + strMsg + "')</script>");
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }
}