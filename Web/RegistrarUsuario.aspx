<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="Web.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1 class="mt-2 mb-2">Registrarse</h1>
        <div class="col-4">
            <div class="mb-2">
                <asp:Label Text="Email" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <div class=" invalid-feedback">
                    Por favor, complete el campo...
                </div>
            </div>
            <div class="mb-2">
                <asp:Label Text="Pass " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" />
                <div class=" invalid-feedback">
                    Por favor, complete el campo...
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Button Text="Registrarse" runat="server" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" />
        </div>
    </div>
</asp:Content>
