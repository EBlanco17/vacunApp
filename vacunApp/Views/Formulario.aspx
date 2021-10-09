<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Formulario.aspx.cs" Inherits="Views_Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/styleForm.css" rel="stylesheet" />
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
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                </div>
            </div>

        </nav>
        <div class="Formbox">
            <h1>Formulario de Vacunación VacunApp</h1>

            <h2>Datos Básicos</h2>
            <asp:Label Text="Localidad:" CssClass="lbl" runat="server" />
            <asp:DropDownList  ID="dropLocal" CssClass="dropMun"  AutoPostBack="true" OnSelectedIndexChanged="dropLocal_SelectedIndexChanged" runat="server">
            </asp:DropDownList><br />
            <asp:Label Text="Sector:" CssClass="lbl" runat="server" />
            <asp:DropDownList ID="dropBarrio" CssClass="dropMun" AutoPostBack="true" runat="server">
            </asp:DropDownList><br />
            <asp:Label Text="EPS:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEps" placeholder="Ingrese EPS" /><br />

            <asp:Label Text="1- ¿Ha sido usted diagnosticado en algún momento durante la actual contingencia de salud con COVID-19?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res1" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="2- ¿Trabajas en el area de la salud dando apoyo en areas COVID-19?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res2" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="3- ¿Trabajas en el area de la salud, en areas no COVID-19?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res3" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="4- ¿Eres estudiante de pregrado de programas de ciencia de la salud haciendo prácticas? " CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res4" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>

            <asp:Label Text="5- ¿Eres cuidador de adultos mayores en atención domiciliaria, identificado por un prestador de servicio de salud?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res5" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="6- ¿Eres personal docente o administrativo educativo, inluye ICBF?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res6" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="7- ¿Perteneces a las fuerzas militares, policía o cuerpo de seguridad?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res7" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="8- ¿Trabajas en proximidad a cadáveres?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res8" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>

            <asp:Label Text="9- ¿Perteneces al personal de custodia y vigilancia de la población privada de la libertad?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res9" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="10- ¿Perteneces a los bomberos, defensa civil o socorristas de la cruz roja?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res10" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="11- ¿Eres trabajador aéreo o aeroportuario (piloto o auxiliar)?" CssClass="lbl" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="res11" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label Text="12- ¿Te han diagnosticado alguna(s) de las siguientes enfermedades? " CssClass="lbl" runat="server" />
            <br />
            <asp:Label CssClass="lbl3" Text="Diabetes" runat="server" />
            <br />
            <asp:RadioButtonList runat="server" ID="resE1" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="Insuficiencia renal" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE2" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="VIH" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE3" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="Cáncer" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE4" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="Tuberculosis" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE5" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="Enfermedad pulmonar obstructiva crónica (EPOC)" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE6" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="Asma" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE7" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="Obesidad" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE8" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>
            <asp:Label CssClass="lbl3" Text="Embarazo" runat="server" /><br />
            <asp:RadioButtonList runat="server" ID="resE9" CssClass="radio" RepeatDirection="Horizontal">
                <asp:ListItem Text="SI" Value="S" />
                <asp:ListItem Text="NO" Value="N" />
            </asp:RadioButtonList>


            <asp:Button Text="Guardar" CssClass="btnSubmit" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />

        </div>
    </form>
   
</body>
</html>

