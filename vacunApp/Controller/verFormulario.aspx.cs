using System;
using System.Web;
using Utilitarios;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;

public partial class Views_verFormulario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        if (!IsPostBack)
        {
            if (Session["user"] == null || Session["token"] == null)
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");
            }
            else
            {
                EFormulario formulario = new EFormulario();
                formulario.UsuarioId = ((EUsuario)Session["user"]).Id;

                var url = ConfigurationManager.AppSettings["HOST"] + "/Formulario/getFormulario";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["Authorization"] = "Bearer " + Session["token"];
                string json = JsonConvert.SerializeObject(formulario);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
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
                                // Do something with responseBody
                                EFormulario form = JsonConvert.DeserializeObject<EFormulario>(responseBody);
                                llenarformulario(form);
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
        }

    }
    public void llenarformulario(EFormulario form)
    {
        string barrio = "";
        var url = ConfigurationManager.AppSettings["HOST"] + "/Formulario/getNombreBarrio";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(form);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
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
                        // Do something with responseBody

                        barrio = JsonConvert.DeserializeObject<string>(responseBody);

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

        mostrarFormulario(form, getLocalidad(form), barrio);
    }

    public void mostrarFormulario(EFormulario form, string localidad, string barrio)
    {
        txtFecha.Text = form.FechaIngreso.ToShortDateString();
        txtEtapa.Text = Convert.ToString(form.Etapa);
        txtLocalidad.Text = localidad;
        txtSector.Text = barrio;
        txtEps.Text = form.Eps;
        txtEdad.Text = form.Edad.ToString();
        txt1.Text = Convert.ToString(form.DiagnosticoCovid);
        txt2.Text = Convert.ToString(form.TrabajoCovid);
        txt3.Text = Convert.ToString(form.TrabajoNoCovid);
        txt4.Text = Convert.ToString(form.EstudiaSalud);
        txt5.Text = Convert.ToString(form.CuidaMayor);
        txt6.Text = Convert.ToString(form.TrabajoEducacion);
        txt7.Text = Convert.ToString(form.TrabajoSeguridad);
        txt8.Text = Convert.ToString(form.TrabajoCadaveres);
        txt9.Text = Convert.ToString(form.TrabajoReclusion);
        txt10.Text = Convert.ToString(form.TrabajoBombero);
        txt11.Text = Convert.ToString(form.TrabajoAeropuerto);
        txtEnf1.Text = Convert.ToString(form.Diabetes);
        txtEnf2.Text = Convert.ToString(form.InsuficienciaRenal);
        txtEnf3.Text = Convert.ToString(form.Vih);
        txtEnf4.Text = Convert.ToString(form.Cancer);
        txtEnf5.Text = Convert.ToString(form.Tuberculosis);
        txtEnf6.Text = Convert.ToString(form.Epoc);
        txtEnf7.Text = Convert.ToString(form.Asma);
        txtEnf8.Text = Convert.ToString(form.Obesidad);
        txtEnf9.Text = Convert.ToString(form.Embarazo);
    }

    private string getLocalidad(EFormulario form)
    {
        string localidad = "";
        var url = ConfigurationManager.AppSettings["HOST"] + "/Formulario/getNombreLocalidad";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(form);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return "";
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        // Do something with responseBody

                        localidad = JsonConvert.DeserializeObject<string>(responseBody);

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
        return localidad;
    }
}