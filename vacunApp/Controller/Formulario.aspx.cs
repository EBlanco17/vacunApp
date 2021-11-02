using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public partial class Views_Formulario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebResponse response;
        Stream strReader;
        StreamReader objReader;
        string responseBody;

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

                var url = ConfigurationManager.AppSettings["HOST"] + "/Formulario/comprobarFormulario";
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
                    using (response = request.GetResponse())
                    {
                        using (strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return;
                            using (objReader = new StreamReader(strReader))
                            {
                                responseBody = objReader.ReadToEnd();
                                // Do something with responseBody
                                Respuesta resp = JsonConvert.DeserializeObject<Respuesta>(responseBody);
                               
                                if (resp.Url == null)
                                {

                                    IniciarLlenadoDropDown();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);
                                    
                                }
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    Session["user"] = null;
                    Session["token"] = null;
                    ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('No está autorizado para esta acción');window.location ='../Views/Login.aspx';",true);
                }

            }
        }
    }

    public void IniciarLlenadoDropDown()
    {
        var url = ConfigurationManager.AppSettings["HOST"] + "/Formulario/getLocalidades";
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
                        // Do something with responseBody

                        List<ELocalidad> localidad = JsonConvert.DeserializeObject<List <ELocalidad>>(responseBody);
                        dropLocal.DataSource = localidad;
                        dropLocal.DataTextField = "nombre";
                        dropLocal.DataValueField = "id";
                        dropLocal.DataBind();
                        dropLocal.Items.Insert(0, new ListItem("Seleccionar", "0"));
                        dropBarrio.Items.Insert(0, new ListItem("Seleccionar", "0"));

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
    protected void dropLocal_SelectedIndexChanged(object sender, EventArgs e)
    {
        EBarrio barrio = new EBarrio();
        barrio.LocalidadId = Convert.ToInt32(dropLocal.SelectedValue);

        var url = ConfigurationManager.AppSettings["HOST"] + "/Formulario/getBarrios";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(barrio);
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
                        List<EBarrio> barrios = JsonConvert.DeserializeObject<List<EBarrio>>(responseBody);
                        dropBarrio.DataSource = barrios;
                        dropBarrio.DataTextField = "nombre";
                        dropBarrio.DataValueField = "id";
                        dropBarrio.DataBind();
                        dropBarrio.Items.Insert(0, new ListItem("Seleccionar", "0"));
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

    protected bool verificarFormulario()
    {
        if (dropLocal.SelectedIndex < 1 || dropBarrio.SelectedIndex < 1 || String.IsNullOrEmpty(txtEps.Text)
                || res1.SelectedIndex < 0 || res2.SelectedIndex < 0 || res3.SelectedIndex < 0 || res4.SelectedIndex < 0
                || res5.SelectedIndex < 0 || res6.SelectedIndex < 0 || res7.SelectedIndex < 0 || res8.SelectedIndex < 0
                || res9.SelectedIndex < 0 || res10.SelectedIndex < 0 || res11.SelectedIndex < 0 || resE1.SelectedIndex < 0
                || resE2.SelectedIndex < 0 || resE3.SelectedIndex < 0 || resE4.SelectedIndex < 0 || resE5.SelectedIndex < 0
                || resE6.SelectedIndex < 0 || resE7.SelectedIndex < 0 || resE8.SelectedIndex < 0 || resE9.SelectedIndex < 0)
        {

            return false;
        }
        else
        {
            return true;
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (verificarFormulario())
        {
            EFormulario form = new EFormulario();
            form.UsuarioId = ((EUsuario)Session["user"]).Id;
            form.Edad = new Recursos().CalcularEdad(((EUsuario)Session["user"]).FechaNacimiento);
            form.FechaIngreso = DateTime.Today;
            form.LocalidadId = dropLocal.SelectedIndex;
            form.BarrioId = dropBarrio.SelectedIndex;
            form.Eps = txtEps.Text;
            form.DiagnosticoCovid = res1.SelectedValue;
            form.TrabajoCovid = res2.SelectedValue;
            form.TrabajoNoCovid =  res3.SelectedValue;
            form.EstudiaSalud =  res4.SelectedValue;
            form.CuidaMayor =  res5.SelectedValue;
            form.TrabajoEducacion =  res6.SelectedValue;
            form.TrabajoSeguridad =  res7.SelectedValue;
            form.TrabajoCadaveres =  res8.SelectedValue;
            form.TrabajoReclusion =  res9.SelectedValue;
            form.TrabajoBombero =  res10.SelectedValue;
            form.TrabajoAeropuerto =  res11.SelectedValue;
            form.Diabetes =  resE1.SelectedValue;
            form.InsuficienciaRenal =  resE2.SelectedValue;
            form.Vih =  resE3.SelectedValue;
            form.Cancer =  resE4.SelectedValue;
            form.Tuberculosis =  resE5.SelectedValue;
            form.Epoc =  resE6.SelectedValue;
            form.Asma =  resE7.SelectedValue;
            form.Obesidad =  resE8.SelectedValue;
            form.Embarazo =  resE9.SelectedValue;
            form.Etapa = calcularEtapa();


            var url = ConfigurationManager.AppSettings["HOST"] + "/Formulario/guardar";
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
                            Respuesta resp = JsonConvert.DeserializeObject<Respuesta>(responseBody);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);
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
        else
        {
            string strMsg = "Por favor, Asegurese de llenar todo el formulario";
            HttpContext.Current.Response.Write("<script>alert('" + strMsg + "')</script>");
        }

    }
    public int calcularEtapa()
    {
        Recursos recursos = new Recursos();
        int etapa = 0;
        int edad = recursos.CalcularEdad(((EUsuario)Session["user"]).FechaNacimiento);

        if (edad >= 16)
        {
            if ( res2.SelectedValue == "SI" || edad >= 80) //Etapa 1
            {
                etapa = 1;
            }
            else if ( res3.SelectedValue == "SI" ||  res4.SelectedValue == "SI" || (edad >= 60 && edad <= 79)) //Etapa 2
            {
                etapa = 2;
            }
            else if ( res5.SelectedValue == "SI" ||  res6.SelectedValue == "SI" ||  res7.SelectedValue== "SI" ||  res8.SelectedValue == "SI"
               ||  resE1.SelectedValue == "SI" ||  resE2.SelectedValue == "SI" ||  resE3.SelectedValue == "SI" ||  resE4.SelectedValue == "SI" ||  resE5.SelectedValue == "SI" ||
                resE6.SelectedValue == "SI" ||  resE7.SelectedValue == "SI" ||  resE8.SelectedValue == "SI" || (edad >= 50 && edad <= 59)) //Etapa 3
            {
                etapa = 3;
            }
            else if ( res9.SelectedValue == "SI" ||  res10.SelectedValue == "SI" ||  res11.SelectedValue == "SI" || (edad >= 40 && edad <= 49)) //Etapa 4
            {
                etapa = 4;
            }
            else
            {
                etapa = 5;
            }
        }
        else if ( resE9.SelectedValue == "SI")// Embarazo
        {
            etapa = 5;
        }
        else
        {//No incluido
            etapa = 0;
        }
        return etapa;
    }
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["token"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }
}
