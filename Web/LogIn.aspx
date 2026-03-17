<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <asp:Label ID="lblTitulo" runat="server" Text="Log In" CssClass="h1 mb-3 mt-3 "></asp:Label>
        <div class="col-4">
            <div class="mb-2">
                <asp:Label Text="Email" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" ></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:Label Text="Pass " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password"/>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-primary" ID="btnIngresar" />
        </div>
    </div>
</asp:Content>
