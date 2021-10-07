<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Registro.aspx.cs" Inherits="Views_Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/styleRegister.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />

    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Registrarse || VacunApp</title>
</head>
<body>

    <form runat="server">

        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color: indianred;">

            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html">
                    <img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt="" />VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">

                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/Login.aspx">Iniciar Sesión</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="../Views/Registro.aspx">Registrarse</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/RecuperarPassword.aspx">Recuperar Contraseña</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="Registerbox">
            <h2>Nuevo Registro</h2>

            <asp:Label Text="Nombres:" CssClass="lblNombre" runat="server" />
            <a alt="Ingrese su nombre" class="tooltipDemo">
                <asp:TextBox runat="server" CssClass="txtNombre" ID="txtNombre" placeholder="Ingrese nombre" Required="true" SetFocusOnError="true" />
            </a>
            <asp:Label Text="Apellidos:" CssClass="lblApellido" runat="server" />
            <a alt="Ingrese sus apellidos" class="tooltipDemo">
                <asp:TextBox runat="server" CssClass="txtApellido" ID="txtApellido" placeholder="Ingrese apellido" Required="true" SetFocusOnError="true" />
            </a>
            <asp:Label Text="Fecha de Nacimiento:" CssClass="lblNaci" runat="server" />
            <a alt="Ingrese su fecha de nacimiento" class="tooltipDemo">
                <asp:TextBox runat="server" CssClass="txtNaci" ID="txtNac" TextMode="Date" />
            </a>
            <asp:Label Text="Género:" CssClass="lblGen" runat="server" />
            <a alt="Seleccione su género" class="tooltipDemo">
                <asp:DropDownList runat="server" ID="dropGenero" CssClass="dropGen">
                    <asp:ListItem Text="FEMENINO" />
                    <asp:ListItem Text="MASCULINO" />
                    <asp:ListItem Text="NO DECIR" />
                </asp:DropDownList>
            </a>
            <asp:Label Text="Documento:" CssClass="lblDoc" runat="server" />
            <a alt="Ingrese su documento" class="tooltipDemo">
                <asp:TextBox runat="server" CssClass="txtDoc" placeholder="Ingrese Documento" ID="txtDoc" Required="true" SetFocusOnError="true" MaxLength="10" />
            </a>
            <asp:Label Text="Correo:" CssClass="lblemail" runat="server" />
            <a alt="example123@proveedor.com" class="tooltipDemo">
                <asp:TextBox runat="server" CssClass="txtemail" placeholder="Ingrese Correo" ID="Txtemail" TextMode="Email" Required="true" SetFocusOnError="true" />
            </a>
            <asp:Label Text="Teléfono:" CssClass="lblTel" runat="server" />
            <a alt="60+indicativo+Número fijo" class="tooltipDemo">
                <asp:TextBox runat="server" CssClass="txtTel" placeholder="Ingrese Teléfono" ID="txtTel" TextMode="Phone" Required="true" SetFocusOnError="true" MaxLength="10" />
            </a>
            <asp:Label Text="Clave:" CssClass="lblClave" runat="server" />
            <a alt="Mínimo 6 caracteres, máximo 14" class="tooltipDemo">
                <asp:TextBox runat="server" CssClass="txtClave" placeholder="Ingrese Clave" ID="txtClave" TextMode="Password" MaxLength="14" Required="true" SetFocusOnError="true"/>
            </a>

            <asp:Button Text="Registrarse" CssClass="btnSubmit" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" />

        </div>
    </form>

    <footer class="text-center text-white" style="background-color: indianred;">
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
