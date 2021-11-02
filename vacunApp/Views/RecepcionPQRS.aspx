<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/RecepcionPQRS.aspx.cs" Inherits="Views_PqrsRecibe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/StyleSolicitud.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>PQRS || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html">
                    <img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt="" />VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/PerfilAdministrador.aspx">Perfil</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="../Views/RecepcionPQRS.aspx">Recepción PQRS</a>
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

        <div class="divtabla">
            <asp:GridView ID="tabla" runat="server" AutoGenerateColumns="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" GridLines="None" AllowPaging="True" PageSize="8" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="tabla_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="tipoSolicitud" HeaderText="TIPO" />
                    <asp:BoundField DataField="usuarioId" HeaderText="ID USUARIO" />
                    <asp:BoundField DataField="fechaIngreso" HeaderText="FECHA INGRESO" DataFormatString="{0:d}"/>
                    <asp:BoundField DataField="fechaLimite" HeaderText="FECHA LIMITE" DataFormatString="{0:d}"/>
                    <asp:HyperLinkField HeaderText="Ver" Text="Click" DataNavigateUrlFields="id"
                        DataNavigateUrlFormatString="~/Views/verSolicitudPQRS.aspx?solicitud={0}" NavigateUrl="~/Views/verSolicitudPQRS.aspx" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
