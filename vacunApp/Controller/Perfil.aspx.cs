using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;

public partial class Views_Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null && ((EUsuario)Session["user"]).RolId == 2 && Session["token"] != null)
            {
                Recursos recursos = new Recursos();


                EUsuario usuario = new EUsuario();
                usuario.Id = ((EUsuario)Session["user"]).Id;

                var url = ConfigurationManager.AppSettings["HOST"] + "/Usuario/buscarRegistro";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["Authorization"] = "Bearer " + Session["token"];

                string json = JsonConvert.SerializeObject(usuario);
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

                                EUsuario user = JsonConvert.DeserializeObject<EUsuario>(responseBody);

                                txtId.Text = "ID: " + user.Id.ToString() + ". Cuenta Estándar";
                                txtNombre.Text = user.Nombres;
                                txtApellido.Text = user.Apellidos;
                                txtNac.Text = user.FechaNacimiento.ToShortDateString();
                                txtEdad.Text = recursos.CalcularEdad(user.FechaNacimiento).ToString();
                                txtGen.Text = user.Genero;
                                txtemail.Text = user.Correo;
                                txtDoc.Text = user.Documento;
                                txtTel.Text = user.Telefono;

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
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");

            }

        }
    }
    protected void lkbSolAmd_Click(object sender, EventArgs e)
    {
        EUsuario user = new EUsuario();
        user.Id = ((EUsuario)Session["user"]).Id;

        var url = ConfigurationManager.AppSettings["HOST"] + "/SolicitudAdmin/comprobarSolictud";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(user);
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


    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["token"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
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
        user.RolId = 2;


        var url = ConfigurationManager.AppSettings["HOST"] + "/Usuario/actualizar";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers["Authorization"] = "Bearer " + Session["token"];
        string json = JsonConvert.SerializeObject(user);
        request.Method = "PUT";
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
                        Session["user"] = resp.User;
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


    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Redirect("../Views/CambiarPassword.aspx");
    }
}