using System;
using System.Web;
using Utilitarios;
using Logica;

public partial class Views_FormDosis : System.Web.UI.Page
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
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }

    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        int tipo = Convert.ToInt32(dropDosis.SelectedValue);
        DateTime fechaN = DateTime.Parse(txtFecha.Text);
        DateTime fechaE = DateTime.Parse(txtFecha.Text);
        int dias = 0;
        Recursos recursos = new Recursos();
        int edad = recursos.CalcularEdad(((EUsuario)Session["user"]).FechaNacimiento);
        string mensaje = "";
        DateTime fecha;
        if ((!DateTime.TryParse(txtFecha.Text, out fecha)) || DateTime.Parse(txtFecha.Text) > DateTime.Today)
        {
            HttpContext.Current.Response.Write("<script>alert('Fecha de aplicacion incorrecta')</script>");
        }
        else {        
        if (tipo > 0) { 
        switch (tipo)
        {
            case 1:
                dias = 21;
                if (edad > 70)
                {
                    mensaje = "Deberá aplicarse una tercera dosis";
                }
                else
                {
                    fechaE = fechaE.AddDays(84);
                    mensaje = "No necesita una tercera dosis || Su segunda dosis podrá extenderse hasta 84 días" + " " + Convert.ToString(fechaE.ToShortDateString());
                }
                break;
            case 2:
                dias = 28;
                if (edad > 70)
                {
                    mensaje = "Deberá aplicarse una tercera dosis";
                }
                else
                {
                    fechaE = fechaE.AddDays(84);
                    mensaje = "No necesita una tercera dosis || Su segunda dosis podrá extenderse hasta 84 días" + " " + Convert.ToString(fechaE.ToShortDateString());
                }
                break;
            case 3:
                dias = 0;
                mensaje = "No necesita más dosis";
                break;
            case 4:
                dias = 28;
                fechaE = fechaE.AddDays(84);
                mensaje = "No necesita una tercera dosis || Su segunda dosis podrá extenderse hasta 84 días" + " " + Convert.ToString(fechaE.ToShortDateString());
                break;
            case 5:
                dias = 28;
                if (edad > 70)
                {
                    mensaje = "Deberá aplicarse una tercera dosis";
                }
                else
                {
                    fechaE = fechaE.AddDays(84);
                    mensaje = "No necesita una tercera dosis || Su segunda dosis podrá extenderse hasta 84 días" + " " + Convert.ToString(fechaE.ToShortDateString());
                }
                break;

        }

        fechaN = fechaN.AddDays(dias);
        txtFecha2.Text = Convert.ToString(fechaN.ToShortDateString()) + " " + mensaje;
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('Seleccione un tipo de vacuna')</script>");
        }
        }
    }
}