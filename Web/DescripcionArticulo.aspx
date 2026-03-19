<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="DescripcionArticulo.aspx.cs" Inherits="Web.DescripcionArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card mt-3">
        <div class="row g-0">
            <div class="col-md-4">
                <asp:Image ID="imgArticulo" runat="server" CssClass="img-fluid" />
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <asp:Label ID="lblNombre" runat="server" CssClass="card-title h5"></asp:Label>
                    <br />
                    <asp:Label ID="lblCodigo" runat="server" CssClass="card-text"></asp:Label>
                    <br />
                    <asp:Label ID="lblCategoria" runat="server" CssClass="card-text"></asp:Label>
                    <span>|</span>
                    <asp:Label ID="lblMarca" runat="server" CssClass="card-text"></asp:Label>
                    <br />
                    <asp:Label ID="lblDescripcion" runat="server" CssClass="card-text"></asp:Label>
                    <br />
                    <asp:Label ID="lblPrecio" runat="server" CssClass="card-text"></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
