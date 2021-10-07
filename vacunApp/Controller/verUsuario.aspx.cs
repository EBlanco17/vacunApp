using System;
using System.Web;
using Utilitarios;
using Logica;

public partial class Views_verUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["user"] != null && ((EUsuario)Session["user"]).RolId == 1)
            {
                Respuesta datos = new LUsuario().buscarRegistro(int.Parse(Request.QueryString.Get(0)));
                ESolicitudAdmin datosS = new LSolicitudAdmin().verSolicitud(int.Parse(Request.QueryString.Get(0)));
                txtRem.Text = datos.User.Nombres + " " + datos.User.Apellidos;
                txtCorreo.Text = datos.User.Correo;
                txtFechaNac.Text = datos.User.FechaNacimiento.ToShortDateString();
                txtGen.Text = datos.User.Genero;
                txtDoc.Text = datos.User.Documento;
                txtFec.Text = datosS.FechaIngreso.ToShortDateString();
                txtMsg.Text = datosS.Mensaje;
            }
            else
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");

            }
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        EUsuario user = new EUsuario();
        user.Id = Convert.ToInt32(int.Parse(Request.QueryString.Get(0)));
        Respuesta resp = new LSolicitudAdmin().cambiarRol(user);
        HttpContext.Current.Response.Redirect(resp.Url);
    }

    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(int.Parse(Request.QueryString.Get(0)));
        Respuesta resp = new LSolicitudAdmin().rechazarSolicitud(id);
        Recursos recursos = new Recursos();
        string correo = txtCorreo.Text;

        string asunto = "Solicitud Administrador";
        string body = "";
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>correo</title>";
        body += "</head>";
        body += "<h1>Solicitud Administrador - VacunApp</h1>";
        body += "<h3>Su solicitud ha sido rechazada...</h3>";
        body += "<p>" + txtRes.Text + "</p>";
        body += "<body>";
        body += "</body>";
        body += "</html>";

        recursos.SendMail(correo, body, asunto);

        HttpContext.Current.Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
        HttpContext.Current.Response.Redirect(resp.Url);
    }
}