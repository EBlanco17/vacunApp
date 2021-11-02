using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public partial class Views_PqrsRecibe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null || ((EUsuario)Session["user"]).RolId == 2 || Session["token"] == null)
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");
            }
            else
            {
                this.bindData();
            }
        }
    }

    protected void bindData()
    {
        var url = ConfigurationManager.AppSettings["HOST"] + "/Solictud/verRegistros";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();

                        List<ESolicitud> datos = JsonConvert.DeserializeObject<List<ESolicitud>>(responseBody);
                        tabla.DataSource = datos;
                        tabla.DataBind();
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Session["user"] = null;
            Session["token"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No está autorizado para esta acción');window.location ='../Views/Login.aspx';", true);

        }

    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["token"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }

    protected void tabla_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        tabla.PageIndex = e.NewPageIndex;
        this.bindData();
    }
}