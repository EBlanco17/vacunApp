﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/MensajeSolicitudAdmin.aspx.cs" Inherits="Views_MensajeSolicitudAdmin" %>

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
    <title>Mensaje || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color: cadetblue;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html">
                    <img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt="" />VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/Perfil.aspx">Perfil</a>
                        </li>
                        
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                </div>
            </div>
        </nav>
        <div class="mensajebox">
            <h1>Razón de su solicitud</h1>
            <asp:Label Text="Ingrese su razón: " runat="server" CssClass="lblReport" />
            <asp:TextBox runat="server" CssClass="txtReport" ID="txtReport" TextMode="MultiLine" MaxLength="200" Height="120px" BackColor="WindowFrame" />
            <asp:Button Text="Enviar" CssClass="btnEnviar" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />

        </div>
    </form>
    <footer class="text-center text-white" style="background-color: cadetblue;">
        <div class="container">
            <div class="">
                <!-- Facebook -->
                <a class="btn btn-floating m-1" href="#" role="button">
                    <img src="../Assets/imagenes/icon-facebook.png" style="width: 27px; height: 27px;" />
                </a>

                <!-- Gmail -->
                <a class="btn btn-floating m-1" href="mailto:vacunapp21@gmail.com?subject=Mail Desde vacunapp.com" role="button">
                    <img src="../Assets/imagenes/icon-gmail.png" style="width: 27px; height: 27px;" />
                </a>

            </div>
        </div>


        <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
            © 2021 Copyright: VacunApp
        </div>

    </footer>
</body>
</html>
