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
            if (txtNombre.Text.Length < 3)
            {
                HttpContext.Current.Response.Write("<script>alert('Nombre incorrecto')</script>");
            }
            else
            {
                user.Nombres = txtNombre.Text.ToUpper();
            }
            if (txtApellido.Text.Length < 4)
            {
                HttpContext.Current.Response.Write("<script>alert('Apellido incorrecto')</script>");
            }
            else
            {
                user.Apellidos = txtApellido.Text.ToUpper();
            }
            if (txtTel.Text.Length < 10)
            {
                HttpContext.Current.Response.Write("<script>alert('Número de teléfono incorrecto...Recuerde 60+indicativo+Número para fijo')</script>");
            }
            else
            {
                user.Telefono = txtTel.Text;
            }
            if (new Recursos().validarEmail(txtemail.Text))
            {
                user.Correo = txtemail.Text.ToUpper();
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Correo incorrecto')</script>");
            }

            user.FechaNacimiento = DateTime.Parse(txtNac.Text);
            user.Documento = txtDoc.Text;
            user.Genero = txtGen.Text;
            user.RolId = 1;

            Respuesta resp = new LUsuario().actualizarDatos(user);
            Session["user"] = resp.User;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

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