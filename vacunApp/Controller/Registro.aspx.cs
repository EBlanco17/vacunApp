using System;
using System.Web;
using System.Web.UI;
using System.Globalization;
using Utilitarios;
using Logica;

public partial class Views_Registro : System.Web.UI.Page
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

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        
        DateTime fecha;
        EUsuario user = new EUsuario();

        if(txtNombre.Text.Length < 3)
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
        

        if ((!DateTime.TryParse(txtNac.Text, out fecha)) || DateTime.Parse(txtNac.Text) >= DateTime.Today)
        {
            
            HttpContext.Current.Response.Write("<script>alert('Fecha de Nacimiento incorrecta')</script>");
        }
        else
        {
            DateTime fechaNacimiento = Convert.ToDateTime(txtNac.Text);
            user.FechaNacimiento = Convert.ToDateTime(fechaNacimiento.ToShortDateString());
        }

        if (txtDoc.Text.Length < 8)
        {
            HttpContext.Current.Response.Write("<script>alert('Número de documento incorrecto')</script>");
        }
        else
        {
            user.Documento = txtDoc.Text;
        }
        if (txtTel.Text.Length < 10)
        {
            HttpContext.Current.Response.Write("<script>alert('Número de teléfono incorrecto...Recuerde 60+indicativo+Número para fijo')</script>");
        }
        else
        {
            user.Telefono = txtTel.Text;
        }

        if (txtClave.Text.Length < 6)
        {
            HttpContext.Current.Response.Write("<script>alert('Clave incorrecta, mínimo 6 caracteres - máximo 14')</script>");
        }
        else
        {
            user.Clave = Encrypt.GetSHA256(txtClave.Text);
        }
        
        if(new Recursos().validarEmail(Txtemail.Text))
        {
            user.Correo = Txtemail.Text.ToUpper();
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('Correo incorrecto')</script>");
        }
        
        user.Genero = dropGenero.Text.ToUpper();
        user.RolId = 2;


        if (user.Nombres != null
             && user.Apellidos != null
             && user.FechaNacimiento != null
             && user.Documento != null
             && user.Correo != null
             && user.Telefono != null
             && user.Clave != null)
        {
            Respuesta resp = new LUsuario().registro(user, Txtemail.Text.ToUpper(), txtDoc.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('"+resp.Mensaje+"');window.location ='"+resp.Url+"';",true);
           
        }

    }
}

