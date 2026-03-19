<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h2"></asp:Label>
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
                                    <a href="DescripcionArticulo.aspx?id=<%#Eval("Id")%>">Ver descripcion</a>
                                </div>
                            </div>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
                </div>
    
</asp:Content>
