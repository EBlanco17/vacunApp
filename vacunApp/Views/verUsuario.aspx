<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/verUsuario.aspx.cs" Inherits="Views_verUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/StyleVerUsuario.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Ver Usuario || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt=""/>VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/PerfilAdministrador.aspx">Perfil</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/RecepcionPQRS.aspx">Recepción PQRS</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/SolicitudesAdministrador.aspx">Verificación administradores</a>
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                </div>
            </div>
        </nav>
        <div class="profilebox">

              <h2>SOLICITUD</h2>

            <asp:Label Text="Remitente:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" ID="txtRem" CssClass="txtRem" Enabled="False" />
            <asp:Label Text="Correo Remitente:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" ID="txtCorreo" CssClass="txtCorreo" Enabled="False" />
            <asp:Label Text="Fecha Nacimiento:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" ID="txtFechaNac" CssClass="txtfechaNac" Enabled="False" />
            <asp:Label Text="Genero:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" ID="txtGen" CssClass="txtGen" Enabled="False" />
            <asp:Label Text="Documento:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" ID="txtDoc" CssClass="txtDoc" Enabled="False" />
            <asp:Label Text="Fecha Ingreso:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txtFec" ID="txtFec" Enabled="False" />
            <asp:Label Text="Descripción:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txtMsg" ID="txtMsg" TextMode="MultiLine" Height="120px" BackColor="WindowFrame" Columns="50" Rows="10" Enable="False"/>

            <asp:Label Text="Contestar:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txtRes" ID="txtRes" TextMode="MultiLine" MaxLength="250" Height="120px" BackColor="WindowFrame" Columns="50" Rows="10" />

            <asp:Button Text="Volver Administrador" CssClass="btnSubmit" ID="btnCambiar" OnClick="btnCambiar_Click" runat="server" />
            <asp:Button Text="Rechazar" CssClass="btnCambiar" ID="btnRechazar" runat="server" OnClick="btnRechazar_Click" />


        </div>
    </form>
      
</body>
</html>
