<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Perfil.aspx.cs" Inherits="Views_Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/styleProfile.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Perfil || VacunApp</title>
</head>
<body>

    <form runat="server">
         <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color:cornflowerblue;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt=""/>VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">

                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="../Views/Perfil.aspx">Perfil</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/Formulario.aspx">Formulario</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/FormularioDosis.aspx">Fechas de Dosis</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/InstaurarPQRS.aspx">PQRS</a>
                        </li>
                        
                        <li class="nav-item">
                            <asp:LinkButton Text="¿Desea ser administrador?" CssClass="nav-link botonadmin" ID="lkbSolAmd" OnClick="lkbSolAmd_Click" runat="server" />
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                    
                </div>
            </div>

        </nav>
        <div class="profilebox">

            <h2>Perfil Usuario</h2>


            <asp:TextBox runat="server" CssClass="idU" ID="txtId" Enabled="False" Visible="True" placeholder="ID User" /><br />

            <asp:Label Text="Nombres:" CssClass="lblNombre" runat="server" />
            <asp:TextBox runat="server" CssClass="txtNombre" ID="txtNombre" Required="true" SetFocusOnError="true"/>
            <asp:Label Text="Apellidos:" CssClass="lblApellido" runat="server" />
            <asp:TextBox runat="server" CssClass="txtApellido" ID="txtApellido" Required="true" SetFocusOnError="true"/>
            <asp:Label Text="Fecha de Nacimiento:" CssClass="lblNaci" runat="server" Enabled="false"/>
            <asp:TextBox runat="server" CssClass="txtNaci" ID="txtNac" placeholder="DD/MM/AAAA" Enabled="false"/>
            <asp:Label Text="Edad:" CssClass="lblEdad" runat="server" />
            <asp:TextBox runat="server" CssClass="txtEdad" ID="txtEdad" Enabled="false" />
            <asp:Label Text="Genero:" CssClass="lblGen" runat="server" />
            <asp:TextBox runat="server" CssClass="txtGen" ID="txtGen" Enabled="false" />
            <asp:Label Text="Documento:" CssClass="lblDoc" runat="server" />
            <asp:TextBox runat="server" CssClass="txtDoc" ID="txtDoc" Enabled="false"/>
            <asp:Label Text="Correo:" CssClass="lblemail" runat="server" />
            <asp:TextBox runat="server" CssClass="txtemail" ID="txtemail" TextMode="Email" Required="true" SetFocusOnError="true"/>
            <asp:Label Text="Telefono:" CssClass="lblTel" runat="server" />
            <asp:TextBox runat="server" CssClass="txtTel" ID="txtTel" TextMode="Phone" Required="true" SetFocusOnError="true" MaxLength="10"/>

            <asp:Button Text="Actualizar Datos" CssClass="btnSubmit" ID="btnActualizar" OnClick="btnActualizar_Click" runat="server" />
            <asp:Button Text="Cambiar Contraseña" CssClass="btnCambiar" ID="btnCambiar" runat="server" OnClick="btnCambiar_Click" />

        </div>
    </form>

</body>
</html>
