<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ha ocurrido un error inesperado...</h1>
    <asp:Label ID="lblError" runat="server" Text="Error: "></asp:Label>
</asp:Content>
