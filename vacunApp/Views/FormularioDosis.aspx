<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/FormularioDosis.aspx.cs" Inherits="Views_FormDosis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/StyleFormdosis.css" rel="stylesheet" />
     <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Fecha Dosis || VacunApp</title>
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
                            <a class="nav-link active" aria-current="page" href="../Views/FormularioDosis.aspx">Fechas de Dosis</a>
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
            <h1>Fechas de segunda dosis</h1>
            <asp:Label Text="Elija la vacuna aplicada en la primera dosis: " runat="server" CssClass="lblTipo" />
            <asp:DropDownList runat="server" ID="dropDosis" CssClass="dropDosis">
                <asp:ListItem Text="PFIZER" Value="1" />
                <asp:ListItem Text="ASTRAZENECA" Value="2" />
                <asp:ListItem Text="JOHNSON & JOHNSON (JANSEN)" Value="3" />
                <asp:ListItem Text="MODERNA" Value="4" />
                <asp:ListItem Text="SINOVAC" Value="5" />
            </asp:DropDownList>
            <asp:Label Text="Ingrese la fecha de aplicación" runat="server" CssClass="lblFecha" />
            <asp:TextBox runat="server" CssClass="txtFecha" ID="txtFecha" TextMode="Date" required />
            <asp:Button Text="Calcular" CssClass="btnCalcular" ID="btnCalcular" OnClick="btnCalcular_Click" runat="server" />
            <asp:Label Text="Fecha de segunda dosis: " CssClass="lblFecha" runat="server" />
            <asp:TextBox runat="server" CssClass="txtFecha" ID="txtFecha2" />
        </div>
    </form>
        <footer class="text-center text-white" style="background-color: cornflowerblue;">
       <div class="container">
            <div class="">
                <!-- Facebook -->
                <a class="btn btn-floating m-1" href="#" role="button" >
                    <img src="../Assets/imagenes/icon-facebook.png" style="width:27px; height:27px;"/>
                </a>

                <!-- Gmail -->
                <a class="btn btn-floating m-1" href="mailto:vacunapp21@gmail.com?subject=Mail Desde vacunapp.com" role="button" >
                    <img src="../Assets/imagenes/icon-gmail.png" style="width:27px; height:27px;"/>
                </a>

            </div>
        </div>


        <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
            © 2021 Copyright: VacunApp
        </div>

    </footer>
</body>
</html>
