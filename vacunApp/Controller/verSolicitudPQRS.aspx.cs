using System;
using System.Web;
using Utilitarios;
using Logica;


public partial class Views_verSolicitudPQRS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["user"] != null && ((EUsuario)Session["user"]).RolId == 1)
            {
                ESolicitud datos = new LSolicitud().verSolicitud(int.Parse(Request.QueryString.Get(0)));
                txtId.Text = Convert.ToString(datos.Id);
                txtIdU.Text = Convert.ToString(datos.UsuarioId);
                Respuesta datosU = new LUsuario().buscarRegistro(Convert.ToInt32(txtIdU.Text));
                switch (datos.TipoSolicitudId)
                {
                    case 1:
                        txtTipo.Text = "PETICIÓN";
                        break;
                    case 2:
                        txtTipo.Text = "QUEJA";
                        break;
                    case 3:
                        txtTipo.Text = "RECLAMO";
                        break;
                    case 4:
                        txtTipo.Text = "SUGERENCIA";
                        break;
                    default:
                        txtTipo.Text = Convert.ToString(datos.TipoSolicitudId);
                        break;
                }
                txtFec.Text = (datos.FechaIngreso).ToShortDateString().ToString();
                txtDesc.Text = datos.Mensaje;
                txtRem.Text = datosU.User.Nombres + " " + datosU.User.Apellidos;
                txtCorreo.Text = datosU.User.Correo;

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

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Recursos recursos = new Recursos();
        string asunto = "Respuesta PQRS";
        string mensaje = txtRes.Text;
        string correo = txtCorreo.Text;
        string body = @"<!doctype html>";
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>Correo</title>";
        body += "</head>";
        body += "<h3><strong>Respuesta a</strong> " + txtTipo.Text + " <strong>tramitado en la fecha</strong> " + txtFec.Text + "</h3>";
        body += "<p><strong>Cordial Saludo: </strong>" + txtRem.Text + "</p>";
        body += "<p>Con respecto a su solicitud...</p>";
        body += "</p>" + mensaje + "</p>";
        body += "<p><strong>Atentamente: </strong>" + ((EUsuario)Session["user"]).Nombres + " " + ((EUsuario)Session["user"]).Apellidos + "</p>";
        body += "<p><strong>Correo:</strong> " + ((EUsuario)Session["user"]).Correo + "</p>";
        body += "</body>";
        body += "</body>";
        body += "</html>";

        Respuesta resp = new LSolicitud().borrarSolicitudRespuesta(Convert.ToInt32(Request.QueryString.Get(0)));
        resp.User = null;
        Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
        Response.Redirect(resp.Url);

        recursos.SendMail(correo, body, asunto);
        
    }
}