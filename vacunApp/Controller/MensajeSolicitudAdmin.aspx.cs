using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;

public partial class Views_MensajeSolicitudAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("../Views/Login.aspx");
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        DateTime fecha = DateTime.Today;

        try
        {
            ESolicitudAdmin solAdmin = new ESolicitudAdmin();

            solAdmin.UsuarioId = ((EUsuario)Session["user"]).Id;
            solAdmin.FechaIngreso = fecha;
            solAdmin.Mensaje = txtReport.Text;
            Respuesta resp = new LSolicitudAdmin().solicitarAdmin(solAdmin);
            HttpContext.Current.Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
            Response.Redirect(resp.Url);
        }
        catch (Exception ex)
        {
            Console.Write("<script>alert('" + ex + "')</script>");
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }
}