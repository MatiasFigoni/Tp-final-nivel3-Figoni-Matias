<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="ArticulosFavoritosUser.aspx.cs" Inherits="Web.ArticulosFavoritosUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">        
<div class="row">

<asp:Repeater ID="repArticulos" runat="server">
    <ItemTemplate>
            <div class="card m-3" style="max-width: 628px">
                <div class="row g-0">
                    <div class="col-md-2">
                        <img src="<%#Eval("UrlImagen")%>" class="img-fluid rounded-start" alt="Imagen <%#Eval("Nombre")%>">
                    </div>
                    <div class="col-md-4">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <p class="card-text">Precio: <%#Eval("Precio") %></p>
                            <a href="DescripcionArticulo.aspx?id=<%#Eval("Id")%>" class="btn link-primary">Ver descripcion</a>
                            <asp:Button ID="btnQuitarFav" runat="server" Text="Quitar de favoritos" CssClass="btn link-primary" CommandArgument='<%#Eval("Id")%>' OnClick="btnQuitarFav_Click"/>
                        </div>
                    </div>
                </div>
            </div>
    </ItemTemplate>
</asp:Repeater>
    </div>
    <%if (ConfirEliminarFav)
    { %>
<div class="toast align-items-center show text-white bg-success border-0" role="alert" aria-live="assertive" aria-atomic="true" style="position: fixed; bottom: 20px; right: 20px; z-index: 1050;">
    <div class="d-flex">
        <div class="toast-body">
            <span>Quitado de favoritos exitosamente!</span>
        </div>
        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
    </div>
</div>
<%} %>
</asp:Content>
