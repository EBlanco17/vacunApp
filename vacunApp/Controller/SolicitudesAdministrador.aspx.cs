using System;
using System.Web;
using Utilitarios;
using Logica;

public partial class Views_SolicitudAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null || ((EUsuario)Session["user"]).RolId == 2)
        {
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }
        else
        {
            this.bindData();
        }

    }

    protected void bindData()
    {
        LSolicitudAdmin datos = new LSolicitudAdmin();
        tabla.DataSource = datos.verRegistros();
        tabla.DataBind();
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        HttpContext.Current.Response.Redirect("../Views/Login.aspx");
    }

    protected void tabla_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        tabla.PageIndex = e.NewPageIndex;
        this.bindData();
    }
}