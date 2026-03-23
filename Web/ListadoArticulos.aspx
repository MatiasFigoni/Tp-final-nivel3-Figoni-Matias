<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="Web.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <div class="row justify-content-start">
                <div class="mb-3 col-3">
                    <asp:Label ID="lblFiltroRapido" runat="server" Text="Filtro rapido:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtFiltro" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
                </div>

                <div class="mt-4 col">
                    <asp:CheckBox ID="cbxActivarFiltroAvanzado" CssClass="btn-check" runat="server" AutoPostBack="true" />
                    <asp:Label ID="lblActivarFiltroAvanzado" runat="server" Text="Filtro Avanzado" AssociatedControlID="cbxActivarFiltroAvanzado" CssClass="btn btn-primary"></asp:Label>
                </div>
            </div>
            <% if (FiltroAvanzado)
                { %>
            <div class="row mb-3">
                <div class="card card-body">
                    <div class="row">
                        <%--Campo--%>
                        <div class="col-3">
                            <asp:Label ID="lblCampo" runat="server" Text="Campo:" CssClass="form-text"></asp:Label>
                            <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Nombre"/>
                                <asp:ListItem Text="Marca" />
                                <asp:ListItem Text="Categoria" />
                                <asp:ListItem Text="Precio" />
                            </asp:DropDownList>
                        </div>
                        <%--Criterio--%>
                        <div class="col-3">
                            <asp:Label ID="lblCriterio" runat="server" Text="Criterio:" CssClass="form-text"></asp:Label>
                            <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Comienza por" />
                                <asp:ListItem Text="Termina por" />
                                <asp:ListItem Text="Contiene" />
                            </asp:DropDownList>
                        </div>
                        <%--Filtro--%>
                        <div class="col-3">
                            <asp:Label ID="lblFiltroAvanzado" runat="server" Text="Filtro:" CssClass="form-text"></asp:Label>
                            <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="invalid-feedback">
                                Por favor, ingrese solo numeros.
                            </div>
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class-="col-3">
                            <asp:Button ID="btnFiltroAvanzado" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnFiltroAvanzado_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <%} %>
            <div class="row">
                <asp:GridView ID="dgvArticulos" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-bordered"
                    AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvArticulos_PageIndexChanging" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <%--<asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />--%>
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />
                    </Columns>
                </asp:GridView>
            </div>
            <a href="ABMArticulo.aspx" class="btn btn-primary">Agregar articulo</a>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
