<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="ModPerfilUsuario.aspx.cs" Inherits="Web.ModPerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi Perfil</h1>
    <div class="row">
        <div class="col">
            <!--Email-->
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <!--Contraseña-->
            <div class="mb-3">
                <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <!--Nombre-->
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <!--Apellido-->
            <div class="mb-3">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="col">
            <!--Imagen Perfil-->
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <asp:FileUpload ID="fupImagenPerfil" runat="server" CssClass="form-control" />
            </div>
            <div class="text-center">
                <asp:Image ID="imgImagenPerfil" runat="server" CssClass="img-thumbnail" Width="350px" Height="350px"/>
            </div>
        </div>
    </div>
    <%if (ConfirmarModificacion)
        { %>
    <div class="toast align-items-center show text-white bg-success border-0" role="alert" aria-live="assertive" aria-atomic="true" style="position: fixed; bottom: 20px; right: 20px; z-index: 1050;">
        <div class="d-flex">
            <div class="toast-body">
                <span>Usuario modificado correctamente!</span>
            </div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
    </div>
    <%} %>
    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
    <a href="Default.aspx" class="btn btn-outline-secondary">Volver</a>
</asp:Content>
