<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Login.aspx.cs" Inherits="Views_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/StyleLogin.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>VacunApp || Login</title>
</head>
<body>
    <form runat="server">

         <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color:indianred;">

            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt=""/>VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">

                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" href="../Views/Login.aspx" >Iniciar Sesión</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/Registro.aspx">Registrarse</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/RecuperarPassword.aspx">Recuperar Contraseña</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="loginbox">
            <img src="../Assets/imagenes/logoLogin.png" alt="Alternate Text" class="user" />
            <h2>Ingresar</h2>

            <asp:Label Text="Correo" CssClass="lblemail" runat="server" />
            <asp:TextBox runat="server" CssClass="txtemail" ID="txtCorreo" placeholder="Ingrese Email" TextMode="Email" />
            <asp:Label Text="Clave" CssClass="lblemail" runat="server" />
            <asp:TextBox runat="server" CssClass="txtemail" placeholder="Ingrese Clave" ID="txtClave" TextMode="Password" />
            <asp:Button Text="Ingresar" CssClass="btnSubmit" ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" />
            </div>
    </form>
      
   </body>
</html>
