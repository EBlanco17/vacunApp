<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/RecuperarPassword.aspx.cs" Inherits="Views_RecuperarPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/StyleRecuperar.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Recuperar Contraseña || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
       <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color:indianred;">

            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt=""/>VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">

                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/Login.aspx" >Iniciar Sesión</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/Registro.aspx">Registrarse</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="../Views/RecuperarPassword.aspx">Recuperar Contraseña</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="recuperarbox">
            <img src="../Assets/imagenes/logoLogin.png" alt="Alternate Text" class="user" />
            <h1>Recuperar Contraseña</h1>
            <asp:Label Text="Correo" CssClass="lblemail" runat="server" />
            <asp:TextBox runat="server" CssClass="txtemail" ID="txtCorreo" placeholder="Ingrese Email" TextMode="Email" />
            <asp:Button Text="Enviar" CssClass="btnEnviar" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />
        </div>


    </form>

</body>
</html>
