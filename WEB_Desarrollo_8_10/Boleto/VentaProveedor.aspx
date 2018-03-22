<%@ Page Title="Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentaProveedor.aspx.cs" Inherits="WEB_Desarrollo_8_10.Boleto.VentaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Compra de productos a Proveedores</h1>
    <table class="table" >
        <tr>
            <td class="auto-style5" style="font-weight: bold">Producto:</td>
            <td>
                <asp:DropDownList ID="comboViewProducto" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Proveedor:</td>
            <td>
                <asp:DropDownList ID="comboViewProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <div>
    <table >
        <tr>
            <td class="auto-style7" >
                <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success"  OnClick="btnGrabar_Click" Text="Comprar producto"  />
            </td>
            
        </tr>
    </table>    
    </div>
    <br />
    <br />

    <div >
        <asp:Label ID="lblError" runat="server" CssClass="auto-style6" ForeColor="#CC0000"></asp:Label>
    </div>
    <asp:GridView ID="grdVentaProveedor" runat="server" ForeColor="#333333" GridLines="None" CssClass="table table-condensed table-bordered table-striped table-hover"></asp:GridView>
</asp:Content>
