<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="ABMArticulo.aspx.cs" Inherits="Web.ABMArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col">
            <%--campo Id --%>
            <div class="mb-3">
                <asp:Label ID="lblId" runat="server" Text="Id" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <%--campo Codigo --%>
            <div class="mb-3">
                <asp:Label ID="lblCodigo" runat="server" Text="Codigo" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <%--campo Nombre--%>
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <%--campo Descripcion--%>
            <div class="mb-3">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control" Height="140px"></asp:TextBox>
            </div>
            <%--campo Precio--%>
            <div class="mb-3">
                <asp:Label ID="lblPrecio" runat="server" Text="Precio" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="invalid-feedback">
                    Por favor, ingrese solo numeros.
                </div>
            </div>
        </div>
        <div class="col">
            <%--campo Categoria--%>
            <div class="mb-3">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <%--campo Marca--%>
            <div class="mb-3">
                <asp:Label ID="lblMarca" runat="server" Text="Marca" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <%--campo Imagen --%>
            <div class="mb-3">
                <asp:Label ID="lblImagenArticulo" runat="server" Text="Imagen Articulo" CssClass="form-label"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtUrlImagen" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged" TextMode="Url"></asp:TextBox>
                        <asp:Image ID="imgArticulo" runat="server" CssClass="img-fluid" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <%if (MostrarConfirmacion)
        { %>
    <div class="toast align-items-center show text-white bg-success border-0" role="alert" aria-live="assertive" aria-atomic="true" style="position: fixed; bottom: 20px; right: 20px; z-index: 1050;">
        <div class="d-flex">
            <div class="toast-body">
                <asp:Label ID="lblAddMod" runat="server"></asp:Label>
            </div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
    </div>
    <%} %>
    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
    <a href="ListadoArticulos.aspx" class="btn btn-secondary">Voler</a>

    <%--Boton de eliminar--%>
    <%if (MostrarBotonEliminar)
        {%>
    <div class="row">
        <div class="col-6">
            <div class="mt-3 mb-3">
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal">
                    Eliminar
               
                </button>
            </div>
        </div>
    </div>
    <!-- Confirmar Eliminacion-->
    <div class="modal fade" id="eliminarModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5">Desea eliminar el articulo?</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Confirmmar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" />
                </div>
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>
