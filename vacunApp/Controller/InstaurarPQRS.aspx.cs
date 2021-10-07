using System;
using System.Web;
using Utilitarios;
using Logica;

public partial class Views_PqrsEnvia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || ((EUsuario)Session["user"]).RolId == 1)
        {
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        HttpContext.Current.Response.Redirect("../Views/Login.aspx");
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        DateTime fecha = DateTime.Today;
        try
        {
            ESolicitud solicitud = new ESolicitud();
            solicitud.TipoSolicitudId = dropTipo.SelectedIndex + 1;
            solicitud.UsuarioId = ((EUsuario)Session["user"]).Id;
            solicitud.Mensaje = txtReport.Text;
            solicitud.FechaIngreso = fecha;
            solicitud.FechaLimite = fecha.AddDays(15);

            Respuesta resp = new LSolicitud().insertarSolicitud(solicitud);
            Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
            Response.Redirect(resp.Url);
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }
    }
}