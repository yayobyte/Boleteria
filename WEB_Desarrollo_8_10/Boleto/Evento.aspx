<%@ Page Title="Eventos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Evento.aspx.cs" Inherits="WEB_Desarrollo_8_10.Boleto.Evento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Creaci&oacute;n de eventos</h1>
    <table class="table" >
        <tr>
            <td class="auto-style4" style="font-weight: bold"><label for="txtNombreEvento">Nombre de Evento:</label></td>
            <td class="auto-style2">
                <asp:TextBox ID="txtNombreEvento" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Artista:</td>
            <td>
                <asp:DropDownList ID="comboViewArtista" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" style="font-weight: bold"><label for="txtFecha">Fecha:</label></td>
            <td class="auto-style2">
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Tipo de Evento:</td>
            <td>
                <asp:DropDownList ID="comboViewTipoEvento" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Establecimiento:</td>
            <td>
                <asp:DropDownList ID="comboViewEstablecimiento" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <div>
    <table >
        <tr>
            <td class="auto-style7" >
                <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success"  OnClick="btnGrabar_Click" Text="Crear Evento"  />
            </td>
            <td class="auto-style7">
                
                <div class="input-group">
                    <asp:TextBox ID="txtBuscarEvento" runat="server" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnConsultar" runat="server"  CssClass="btn btn-info" Text="Buscar"  OnClick="btnConsultar_Click" />
                    </span>
                </div><!-- /input-group -->
            </td>
            <td>
                <div class="input-group">
                    <asp:TextBox ID="txtEliminarEvento" runat="server" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnBorrar" runat="server"  CssClass="btn btn-danger" Text="Borrar"  OnClick="btnBorrar_Click" />
                    </span>
                </div><!-- /input-group -->

            </td>
        </tr>
    </table>    
    </div>
    <br />
    <br />

    <div >
        <asp:Label ID="lblError" runat="server" CssClass="auto-style6" ForeColor="#CC0000"></asp:Label>
    </div>
    <asp:GridView ID="grdEvento" runat="server" ForeColor="#333333" GridLines="None" CssClass="table table-condensed table-bordered table-striped table-hover"></asp:GridView>
</asp:Content>
