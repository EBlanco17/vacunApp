using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;

public partial class Views_PerfilAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null && ((EUsuario)Session["user"]).RolId == 1)
            {
                Recursos recursos = new Recursos();
                txtId.Text = "ID: " + (((EUsuario)Session["user"]).Id).ToString() + ". Cuenta Administrador";
                txtNombre.Text = ((EUsuario)Session["user"]).Nombres;
                txtApellido.Text = ((EUsuario)Session["user"]).Apellidos;
                txtNac.Text = (((EUsuario)Session["user"]).FechaNacimiento).ToShortDateString().ToString();
                txtEdad.Text = recursos.CalcularEdad(((EUsuario)Session["user"]).FechaNacimiento).ToString();
                txtGen.Text = ((EUsuario)Session["user"]).Genero;
                txtemail.Text = ((EUsuario)Session["user"]).Correo;
                txtDoc.Text = ((EUsuario)Session["user"]).Documento;
                txtTel.Text = ((EUsuario)Session["user"]).Telefono;
            }
            else
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");

            }

        }
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Redirect("../Views/CambiarPassword.aspx");
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            EUsuario user = new EUsuario();
            user.Id = ((EUsuario)Session["user"]).Id;
            user.Nombres = txtNombre.Text.ToUpper();
            user.Apellidos = txtApellido.Text.ToUpper();
            user.Documento = txtDoc.Text;
            user.FechaNacimiento = DateTime.Parse(txtNac.Text);
            user.Genero = txtGen.Text;
            user.Telefono = txtTel.Text;
            user.Correo = txtemail.Text.ToUpper();
            user.RolId = 2;

            Respuesta resp = new LUsuario().actualizarDatos(user);
            HttpContext.Current.Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
            Session["user"] = resp.User;
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