using System;
using System.Web;
using Utilitarios;
using Logica;

public partial class Views_Formulario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Recursos recursos = new Recursos();
        string path = "";
        char etapa = '0';
        int edad = recursos.CalcularEdad(((EUsuario)Session["user"]).FechaNacimiento);

        if (edad >= 16)
        {
            if (Convert.ToChar(res2.SelectedValue) == '1' || edad >= 80) //Etapa 1
            {
                path = "<img src='https://pbs.twimg.com/media/Ertb_JOW4AkADei.jpg' alt='Etapa 1 Covid-19'/>";
                etapa = '1';
            }
            else if (Convert.ToChar(res3.SelectedValue) == '1' || Convert.ToChar(res4.SelectedValue) == '1' || (edad >= 60 && edad <= 79)) //Etapa 2
            {
                path = "<img src='https://pbs.twimg.com/media/Ertb_pVW8AM98vg?format=jpg&name=medium' alt='Etapa 2 Covid-19'/>";
                etapa = '2';
            }
            else if (Convert.ToChar(res5.SelectedValue) == '1' || Convert.ToChar(res6.SelectedValue) == '1' || Convert.ToChar(res7.SelectedValue) == '1' || Convert.ToChar(res8.SelectedValue) == '1'
               || Convert.ToChar(resE1.SelectedValue) == '1' || Convert.ToChar(resE2.SelectedValue) == '1' || Convert.ToChar(resE3.SelectedValue) == '1' || Convert.ToChar(resE4.SelectedValue) == '1' || Convert.ToChar(resE5.SelectedValue) == '1' ||
               Convert.ToChar(resE6.SelectedValue) == '1' || Convert.ToChar(resE7.SelectedValue) == '1' || Convert.ToChar(resE8.SelectedValue) == '1' || (edad >= 50 && edad <= 59)) //Etapa 3
            {
                path = "<img src='https://pbs.twimg.com/media/Ertb_pVW8AM98vg?format=jpg&name=medium' alt='Etapa 3 Covid-19'/>";
                etapa = '3';
            }
            else if (Convert.ToChar(res9.SelectedValue) == '1' || Convert.ToChar(res10.SelectedValue) == '1' || Convert.ToChar(res11.SelectedValue) == '1' || (edad >= 40 && edad <= 49)) //Etapa 4
            {
                path = "<img src='https://pbs.twimg.com/media/ErtcAS7XcAQOdtL?format=jpg&name=medium' alt='Etapa 4 Covid-19'/>";
                etapa = '4';
            }
            else
            {
                path = "<img src='https://pbs.twimg.com/media/ErtcAS7XcAQOdtL?format=jpg&name=medium' alt='Etapa 5 Covid-19'/>";
                etapa = '5';
            }
        }
        else if (Convert.ToChar(resE9.SelectedValue) == '1')//No incluido Embarazo
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
        body += "<p>Departamento: <b class='data'> " + dropDepto.Text + " </b></p>";
        body += "<p>Municipio: <b class='data'> " + dropMun.Text + " </b></p>";
        body += "<p>EPS: <b class='data'> " + txtEps.Text + " </b></p>";
        body += "<p>1- ¿Ha sido usted diagnosticado en algún momento durante la actual contingencia de salud con COVID-19? <b class='data'> " + Convert.ToChar(res1.SelectedValue) + " </b></p>";
        body += "<p>2- ¿Trabajas en el area de la salud dando apoyo en areas COVID-19? <b class='data'> " + Convert.ToChar(res2.SelectedValue) + " </b></p>";
        body += "<p>3- ¿Trabajas en el area de la salud, en areas no COVID-19? <b class='data'> " + Convert.ToChar(res3.SelectedValue) + " </b></p>";
        body += "<p>4- ¿Eres estudiante de pregrado de programas de ciencia de la salud haciendo prácticas?  <b class='data'> " + Convert.ToChar(res4.SelectedValue) + " </b></p>";
        body += "<p>5- ¿Eres cuidador de adultos mayores en atención domiciliaria, identificado por un prestador de servicio de salud? <b class='data'> " + Convert.ToChar(res5.SelectedValue) + " </b></p>";
        body += "<p>6- ¿Eres personal docente o administrativo educativo, inluye ICBF? <b class='data'> " + Convert.ToChar(res6.SelectedValue) + " </b></p>";
        body += "<p>7- ¿Perteneces a las fuerzas militares, policía o cuerpo de seguridad? <b class='data'> " + Convert.ToChar(res7.SelectedValue) + " </b></p>";
        body += "<p>8- ¿Trabajas en proximidad a cadáveres? <b class='data'> " + Convert.ToChar(res8.SelectedValue) + " </b></p>";
        body += "<p>9- ¿Perteneces al personal de custodia y vigilancia de la población privada de la libertad? <b class='data'> " + Convert.ToChar(res9.SelectedValue) + " </b></p>";
        body += "<p>10- ¿Perteneces a los bomberos, defensa civil o socorristas de la cruz roja? <b class='data'> " + Convert.ToChar(res10.SelectedValue) + " </b></p>";
        body += "<p>11- ¿Eres trabajador aéreo o aeroportuario (piloto o auxiliar)? <b class='data'> " + Convert.ToChar(res11.SelectedValue) + " </b></p>";
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
        body += "<tr><td>" + Convert.ToChar(resE1.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE2.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE3.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE4.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE5.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE6.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE7.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE8.SelectedValue) + "</td>";
        body += "<td>" + Convert.ToChar(resE9.SelectedValue) + "</td>";
        body += "</tr>";
        body += "</table>";
        body += "<br><h2>Tenga en Cuenta...</h2>";
        body += "<img src='https://www.occidentesp.com.co/wp-content/uploads/2020/05/sinttomas.png' alt='Cuidados Covid'/>";
        body += "</body>";
        body += "</body>";
        body += "</html>";

        recursos.SendMail(((EUsuario)Session["user"]).Correo, body, asunto);
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        HttpContext.Current.Response.Redirect("../Views/Inicio.html");
    }
}
