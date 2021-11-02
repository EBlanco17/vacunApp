<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/verFormulario.aspx.cs" Inherits="Views_verFormulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/StyleVerFormulario.css" rel="stylesheet" />
     <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Formulario || VacunApp</title>
</head>
<body>
    <form runat="server">
         <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color:steelblue;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt=""/>VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">

                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/Perfil.aspx">Perfil</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="../Views/Formulario.aspx">Formulario</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/FormularioDosis.aspx">Fechas de Dosis</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/InstaurarPQRS.aspx">PQRS</a>
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" runat="server" />
                    </span>
                </div>
            </div>

        </nav>
        <div class="Formbox">
            <h1>Formulario VacunApp</h1>
             <h2>Datos Básicos</h2>
            <asp:Label Text="Fecha de llenado:" CssClass="lbl" runat="server" />
             <asp:TextBox runat="server" CssClass="txtD" ID="txtFecha" Enabled="false"/><br />
            <asp:Label Text="Etapa:" CssClass="lbl" runat="server" />
             <asp:TextBox runat="server" CssClass="txt" ID="txtEtapa" Enabled="false"/><br />
            <asp:Label Text="Localidad:" CssClass="lbl" runat="server" />
             <asp:TextBox runat="server" CssClass="txtD" ID="txtLocalidad" Enabled="false"/>
            <asp:Label Text="Sector:" CssClass="lbl" runat="server" />
             <asp:TextBox runat="server" CssClass="txtD" ID="txtSector" Enabled="false"/><br />
            <asp:Label Text="EPS:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txtD" ID="txtEps" Enabled="false"/>
             <asp:Label Text="Edad:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txtD" ID="txtEdad" Enabled="false"/><br />

            <asp:Label Text="1- ¿Ha sido usted diagnosticado en algún momento durante la actual contingencia de salud con COVID-19?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt1" Enabled="false"/><br />
            <asp:Label Text="2- ¿Trabajas en el area de la salud dando apoyo en areas COVID-19?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt2" Enabled="false"/><br />
            <asp:Label Text="3- ¿Trabajas en el area de la salud, en areas no COVID-19?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt3" Enabled="false"/><br />
            <asp:Label Text="4- ¿Eres estudiante de pregrado de programas de ciencia de la salud haciendo prácticas? " CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt4" Enabled="false"/><br />
            <asp:Label Text="5- ¿Eres cuidador de adultos mayores en atención domiciliaria, identificado por un prestador de servicio de salud?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt5" Enabled="false"/><br />
            <asp:Label Text="6- ¿Eres personal docente o administrativo educativo, inluye ICBF?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt6" Enabled="false"/><br />
            <asp:Label Text="7- ¿Perteneces a las fuerzas militares, policía o cuerpo de seguridad?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt7" Enabled="false"/><br />
            <asp:Label Text="8- ¿Trabajas en proximidad a cadáveres?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt8" Enabled="false"/><br />
            <asp:Label Text="9- ¿Perteneces al personal de custodia y vigilancia de la población privada de la libertad?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt9" Enabled="false"/><br />
            <asp:Label Text="10- ¿Perteneces a los bomberos, defensa civil o socorristas de la cruz roja?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt10" Enabled="false"/><br />
            <asp:Label Text="11- ¿Eres trabajador aéreo o aeroportuario (piloto o auxiliar)?" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txt11" Enabled="false"/><br />

            <asp:Label Text="12- ¿Te han diagnosticado alguna(s) de las siguientes enfermedades? " CssClass="lbl" runat="server" />
            <br />
            <asp:Label CssClass="lbl3" Text="Diabetes" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf1" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="Insuficiencia renal" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf2" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="VIH" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf3" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="Cáncer" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf4" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="Tuberculosis" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf5" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="Enfermedad pulmonar obstructiva crónica (EPOC)" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf6" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="Asma" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf7" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="Obesidad" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf8" Enabled="false"/><br />
            <asp:Label CssClass="lbl3" Text="Embarazo" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEnf9" Enabled="false"/><br />
        </div>
    </form>
</body>
</html>
