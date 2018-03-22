<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WEB_Desarrollo_8_10.Boleto.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="clientesContent">
        <h3>Clientes</h3>
            
        <table class="table" >
            <tr>
                <td class="auto-style4" style="font-weight: bold"><label for="txtNombre">Nombre de cliente:</label></td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
                
            <tr>
                <td class="auto-style4" style="font-weight: bold"><label for="txtCorreo">Correo del cliente:</label></td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
                
        </table>
        <br />
        <table >
            <tr>
                <td class="auto-style7" >
                    <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success"  OnClick="btnGrabar_Click" Text="Crear Cliente"  />
                </td>
            </tr>
        </table>
        <br />
        <br />

            <asp:Label ID="lblError" runat="server" CssClass="auto-style6" ForeColor="#CC0000"></asp:Label>
            <asp:GridView ID="gridViewCliente" runat="server" ForeColor="#333333" GridLines="None" CssClass="table table-condensed table-bordered table-striped table-hover"></asp:GridView>

    </div>

</asp:Content>
