<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/InstaurarPQRS.aspx.cs" Inherits="Views_PqrsEnvia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/StylePqrs.css" rel="stylesheet" />
     <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>PQRS || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
         <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color:cornflowerblue;">
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
                            <a class="nav-link" aria-current="page" href="../Views/Formulario.aspx">Formulario</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/FormularioDosis.aspx">Fechas de Dosis</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="../Views/InstaurarPQRS.aspx">PQRS</a>
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                </div>
            </div>

        </nav>
        <div class="pqrsbox">
            <h1>PQRS</h1>
            <asp:Label Text="Elija una opción para envíar su reporte: " runat="server" CssClass="lblReport" />
            <asp:DropDownList runat="server" ID="dropTipo" CssClass="dropReport">
                <asp:ListItem Text="Peticiones" />
                <asp:ListItem Text="Quejas" />
                <asp:ListItem Text="Reclamos" />
                <asp:ListItem Text="Sugerencias" />
            </asp:DropDownList>
            <asp:Label Text="Ingrese su reporte: " runat="server" CssClass="lblReport" />
            <asp:TextBox runat="server" CssClass="txtReport" ID="txtReport" TextMode="MultiLine" MaxLength="150" Height="120px" BackColor="WindowFrame" Columns="50" Rows="10" />
            <asp:Button Text="Enviar" CssClass="btnEnviar" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />
        </div>
    </form>
    
   </body>
</html>
