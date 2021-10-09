using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI.WebControls;


public partial class Views_Formulario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");
            }
            else
            {
                Respuesta resp = new LFormulario().comprobarFormulario(((EUsuario)Session["user"]).Id);
                
                if(resp.Url == null)
                {
                    
                    IniciarLlenadoDropDown();
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
                    reenviarFormulario(new LFormulario().GetFormulario(((EUsuario)Session["user"]).Id));
                    Response.Redirect(resp.Url);
                }
                
            }
        }
    }

    public void IniciarLlenadoDropDown()
    {
        LFormulario datos = new LFormulario();
        dropLocal.DataSource = datos.listarLocalidades();
        dropLocal.DataTextField = "nombre";
        dropLocal.DataValueField = "id";
        dropLocal.DataBind();
        dropLocal.Items.Insert(0, new ListItem("Seleccionar", "0"));
        dropBarrio.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }
    protected void dropLocal_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idLocal = Convert.ToInt32(dropLocal.SelectedValue);
        LFormulario datos = new LFormulario();
        dropBarrio.DataSource = datos.listarBarrios(idLocal);
        dropBarrio.DataTextField = "nombre";
        dropBarrio.DataValueField = "id";
        dropBarrio.DataBind();
        dropBarrio.Items.Insert(0, new ListItem("Seleccionar", "0"));
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
            form.FechaIngreso = DateTime.Today;
            form.LocalidadId = dropLocal.SelectedIndex;
            form.BarrioId = dropBarrio.SelectedIndex;
            form.Eps = txtEps.Text;
            form.DiagnosticoCovid = Convert.ToChar(res1.SelectedValue);
            form.TrabajoCovid = Convert.ToChar(res2.SelectedValue);
            form.TrabajoNoCovid = Convert.ToChar(res3.SelectedValue);
            form.EstudiaSalud = Convert.ToChar(res4.SelectedValue);
            form.CuidaMayor = Convert.ToChar(res5.SelectedValue);
            form.TrabajoEducacion = Convert.ToChar(res6.SelectedValue);
            form.TrabajoSeguridad = Convert.ToChar(res7.SelectedValue);
            form.TrabajoCadaveres = Convert.ToChar(res8.SelectedValue);
            form.TrabajoReclusion = Convert.ToChar(res9.SelectedValue);
            form.TrabajoBombero = Convert.ToChar(res10.SelectedValue);
            form.TrabajoAeropuerto = Convert.ToChar(res11.SelectedValue);
            form.Diabetes = Convert.ToChar(resE1.SelectedValue);
            form.InsuficienciaRenal = Convert.ToChar(resE2.SelectedValue);
            form.Vih = Convert.ToChar(resE3.SelectedValue);
            form.Cancer = Convert.ToChar(resE4.SelectedValue);
            form.Tuberculosis = Convert.ToChar(resE5.SelectedValue);
            form.Epoc = Convert.ToChar(resE6.SelectedValue);
            form.Asma = Convert.ToChar(resE7.SelectedValue);
            form.Obesidad = Convert.ToChar(resE8.SelectedValue);
            form.Embarazo = Convert.ToChar(resE9.SelectedValue);
            form.Etapa = calcularEtapa();
            Respuesta resp = new LFormulario().guardarFormulario(form);

            HttpContext.Current.Response.Write("<script>alert('" + resp.Mensaje + "')</script>");
            Response.Redirect(resp.Url);

            enviarFormulario(dropLocal.SelectedItem.Text,
            dropBarrio.SelectedItem.Text,
            form.LocalidadId,
            form.BarrioId,
            form.Eps,
            form.DiagnosticoCovid,
            form.TrabajoCovid,
            form.TrabajoNoCovid,
            form.EstudiaSalud,
            form.CuidaMayor,
            form.TrabajoEducacion,
            form.TrabajoSeguridad,
            form.TrabajoCadaveres,
            form.TrabajoReclusion,
            form.TrabajoBombero,
            form.TrabajoAeropuerto,
            form.Diabetes,
            form.InsuficienciaRenal,
            form.Vih,
            form.Cancer,
            form.Tuberculosis,
            form.Epoc,
            form.Asma,
            form.Obesidad,
            form.Embarazo,
            form.Etapa);

            
        }
        else
        {
            string strMsg = "Por favor, Asegurese de llenar todo el formulario";
            HttpContext.Current.Response.Write("<script>alert('" + strMsg + "')</script>");
        }

    }
    public char calcularEtapa()
    {
        Recursos recursos = new Recursos();
        char etapa = '0';
        int edad = recursos.CalcularEdad(((EUsuario)Session["user"]).FechaNacimiento);

        if (edad >= 16)
        {
            if (Convert.ToChar(res2.SelectedValue) == '1' || edad >= 80) //Etapa 1
            {
                etapa = '1';
            }
            else if (Convert.ToChar(res3.SelectedValue) == '1' || Convert.ToChar(res4.SelectedValue) == '1' || (edad >= 60 && edad <= 79)) //Etapa 2
            {
                etapa = '2';
            }
            else if (Convert.ToChar(res5.SelectedValue) == '1' || Convert.ToChar(res6.SelectedValue) == '1' || Convert.ToChar(res7.SelectedValue) == '1' || Convert.ToChar(res8.SelectedValue) == '1'
               || Convert.ToChar(resE1.SelectedValue) == '1' || Convert.ToChar(resE2.SelectedValue) == '1' || Convert.ToChar(resE3.SelectedValue) == '1' || Convert.ToChar(resE4.SelectedValue) == '1' || Convert.ToChar(resE5.SelectedValue) == '1' ||
               Convert.ToChar(resE6.SelectedValue) == '1' || Convert.ToChar(resE7.SelectedValue) == '1' || Convert.ToChar(resE8.SelectedValue) == '1' || (edad >= 50 && edad <= 59)) //Etapa 3
            {
                etapa = '3';
            }
            else if (Convert.ToChar(res9.SelectedValue) == '1' || Convert.ToChar(res10.SelectedValue) == '1' || Convert.ToChar(res11.SelectedValue) == '1' || (edad >= 40 && edad <= 49)) //Etapa 4
            {
                etapa = '4';
            }
            else
            {
                etapa = '5';
            }
        }
        else if (Convert.ToChar(resE9.SelectedValue) == '1')//No incluido Embarazo
        {
            etapa = '0';
        }
        else
        {//No incluido
            etapa = '0';
        }
        return etapa;
    }
    public void enviarFormulario(string localidad, string barrio, int idLocal, int idBarrio, string eps, char resp1, char resp2,
        char resp3, char resp4, char resp5, char resp6, char resp7, char resp8, char resp9, char resp10, char resp11, char respE1,
        char respE2, char respE3, char respE4, char respE5, char respE6, char respE7, char respE8, char respE9, char etapa)
    {
        Recursos recursos = new Recursos();
        string path = "";
        int edad = recursos.CalcularEdad(((EUsuario)Session["user"]).FechaNacimiento);

        if (edad >= 16)
        {
            if (etapa == '1') //Etapa 1
            {
                path = "<img src='https://pbs.twimg.com/media/Ertb_JOW4AkADei.jpg' alt='Etapa 1 Covid-19'/>";
                
            }
            else if (etapa == '2') //Etapa 2
            {
                path = "<img src='https://pbs.twimg.com/media/Ertb_pVW8AM98vg?format=jpg&name=medium' alt='Etapa 2 Covid-19'/>";
                
            }
            else if (etapa == '3') //Etapa 3
            {
                path = "<img src='https://pbs.twimg.com/media/Ertb_pVW8AM98vg?format=jpg&name=medium' alt='Etapa 3 Covid-19'/>";
                
            }
            else if (etapa == '4') //Etapa 4
            {
                path = "<img src='https://pbs.twimg.com/media/ErtcAS7XcAQOdtL?format=jpg&name=medium' alt='Etapa 4 Covid-19'/>";
                
            }
            else
            {
                path = "<img src='https://pbs.twimg.com/media/ErtcAS7XcAQOdtL?format=jpg&name=medium' alt='Etapa 5 Covid-19'/>";
                etapa = '5';
            }
        }
        else if (respE9 == 'S')//No incluido Embarazo
        {
            path = "<img src='https://drive.google.com/file/d/1P3Pg5wJox_NYgtAlFqRIr6Viuc8I2Q6z/view?usp=sharing' alt='Etapa Covid-19'/>";
            etapa = '0';
        }
        else
        {//No incluido
            path = "<img src='https://pbs.twimg.com/media/Eq-We-iW8AE1t8T.png' alt='Etapas Covid-19'/>";
            etapa = '0';
        }

        string asunto = "Resultados Formulario";
        string body = @"<!doctype html>";
        body += "<html>";
        body += "<head>";
        body += "<meta charset='utf-8'>";
        body += "<title>correo</title>";
        body += "</head>";
        body += "<style>";
        body += "h1,h2{color: #23607D; font-family: Baskerville,'Palatino Linotype', Palatino, 'Century Schoolbook L', 'Times New Roman', 'serif'; text-align: center}";
        body += "p{color: #0A80CB; font-family: 'Lucida Grande', 'Lucida Sans Unicode', 'Lucida Sans', 'DejaVu Sans', Verdana, 'sans-serif'}";
        body += ".etapa{color: #22B825; font-size: 25px;}";
        body += ".data{color: #420C77; font-family: 'Lucida Grande', 'Lucida Sans Unicode', 'Lucida Sans', 'DejaVu Sans', Verdana, 'sans-serif'}";
        body += "a{font-family: Cambria, 'Hoefler Text', 'Liberation Serif', Times, 'Times New Roman', 'serif'; font-style: italic}";
        body += "table{align-items: center; text-align: center; color: #BF6A0C; font-family: 'Lucida Grande', 'Lucida Sans Unicode', 'Lucida Sans', 'DejaVu Sans', Verdana, 'sans-serif'; font-size: 14px;}";
        body += "th{color: #420C77;}";
        body += "td{color: #22B825;}";
        body += "</style>";
        body += path;
        body += "<h1>Datos de la persona </h1>";
        body += "<p>Nombre: <b class='data'>" + ((EUsuario)Session["user"]).Nombres + " " + ((EUsuario)Session["user"]).Apellidos + " </b></p>";
        body += "<p>Género:   <b class='data'> " + ((EUsuario)Session["user"]).Genero + "</b></p>";
        body += "<p>Edad:  <b class='data'> " + edad + " </b></p>";
        body += "<p>Documento:  <b class='data'>" + ((EUsuario)Session["user"]).Documento + " </b></p>";
        body += "<p>Teléfono:  <b class='data'> " + ((EUsuario)Session["user"]).Telefono + " </b></p>";
        body += "<p>Según toda la información suminastrada usted se encuentra en la etapa No. <b class='etapa'>" + etapa + "</b> de vacunación</p>";
        body += "<p><a href='https://www.dssa.gov.co/images/vacunacion/etapas_de_priorizacion.pdf'>Para mas información de las etapas de vacunación, siga este enlace...</a></p>";
        body += "<h2>Formulario</h2>";
        body += "<p>Localidad: <b class='data'> " + localidad + " </b></p>";
        body += "<p>Sector: <b class='data'> " + barrio + " </b></p>";
        body += "<p>EPS: <b class='data'> " + eps + " </b></p>";
        body += "<p>1- ¿Ha sido usted diagnosticado en algún momento durante la actual contingencia de salud con COVID-19? <b class='data'> " + resp1 + " </b></p>";
        body += "<p>2- ¿Trabajas en el area de la salud dando apoyo en areas COVID-19? <b class='data'> " + resp2 + " </b></p>";
        body += "<p>3- ¿Trabajas en el area de la salud, en areas no COVID-19? <b class='data'> " + resp3 + " </b></p>";
        body += "<p>4- ¿Eres estudiante de pregrado de programas de ciencia de la salud haciendo prácticas?  <b class='data'> " + resp4 + " </b></p>";
        body += "<p>5- ¿Eres cuidador de adultos mayores en atención domiciliaria, identificado por un prestador de servicio de salud? <b class='data'> " + resp5 + " </b></p>";
        body += "<p>6- ¿Eres personal docente o administrativo educativo, inluye ICBF? <b class='data'> " + resp6 + " </b></p>";
        body += "<p>7- ¿Perteneces a las fuerzas militares, policía o cuerpo de seguridad? <b class='data'> " + resp7 + " </b></p>";
        body += "<p>8- ¿Trabajas en proximidad a cadáveres? <b class='data'> " + resp8 + " </b></p>";
        body += "<p>9- ¿Perteneces al personal de custodia y vigilancia de la población privada de la libertad? <b class='data'> " + resp9 + " </b></p>";
        body += "<p>10- ¿Perteneces a los bomberos, defensa civil o socorristas de la cruz roja? <b class='data'> " + resp10 + " </b></p>";
        body += "<p>11- ¿Eres trabajador aéreo o aeroportuario (piloto o auxiliar)? <b class='data'> " + resp11 + " </b></p>";
        body += "<p>E12- ¿Te han diagnosticado alguna(s) de las siguientes enfermedades?</p>";
        body += "<table class='enfermedades'>";
        body += "<tr><th>DIABETES</th>";
        body += "<th>INSUFICIENCIA <br>RENAL</th>";
        body += "<th>VIH</th>";
        body += "<th>CÁNCER</th>";
        body += "<th>TUBERCULOSIS</th>";
        body += "<th>EPOC</th>";
        body += "<th>ASMA</th>";
        body += "<th>OBESIDAD</th>";
        body += "<th>EMBARAZO</th></tr>";
        body += "<tr><td>" + respE1 + "</td>";
        body += "<td>" + respE2 + "</td>";
        body += "<td>" + respE3 + "</td>";
        body += "<td>" + respE4 + "</td>";
        body += "<td>" + respE5 + "</td>";
        body += "<td>" + respE6 + "</td>";
        body += "<td>" + respE7 + "</td>";
        body += "<td>" + respE8 + "</td>";
        body += "<td>" + respE9 + "</td>";
        body += "</tr>";
        body += "</table>";
        body += "<br><h2>Tenga en Cuenta...</h2>";
        body += "<img src='https://www.occidentesp.com.co/wp-content/uploads/2020/05/sinttomas.png' alt='Cuidados Covid'/>";
        body += "</body>";
        body += "</body>";
        body += "</html>";

        //recursos.SendMail(((EUsuario)Session["user"]).Correo, body, asunto);
    }
    public void reenviarFormulario(EFormulario form)
    {
        string localidad = new LFormulario().getNombreLocalidad(form.LocalidadId);
        string barrio = new LFormulario().getNombreBarrio(form.BarrioId);
        enviarFormulario(localidad,
            barrio,
            form.LocalidadId,
            form.BarrioId,
            form.Eps,
            form.DiagnosticoCovid,
            form.TrabajoCovid,
            form.TrabajoNoCovid,
            form.EstudiaSalud,
            form.CuidaMayor,
            form.TrabajoEducacion,
            form.TrabajoSeguridad,
            form.TrabajoCadaveres,
            form.TrabajoReclusion,
            form.TrabajoBombero,
            form.TrabajoAeropuerto,
            form.Diabetes,
            form.InsuficienciaRenal,
            form.Vih,
            form.Cancer,
            form.Tuberculosis,
            form.Epoc,
            form.Asma,
            form.Obesidad,
            form.Embarazo,
            form.Etapa);
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }


}
