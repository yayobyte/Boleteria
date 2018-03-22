<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="WEB_Desarrollo_8_10.BaseDatos.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table class="auto-style1">
        <tr>
            <td class="auto-style3" colspan="2"><strong>ADMINISTRACIÓN DE SERVICIOS</strong></td>
        </tr>
        <tr>
            <td class="auto-style4" style="font-weight: bold">CÓDIGO:</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="auto-style8"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">NOMBRE:</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="auto-style8"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">VALOR:</td>
            <td>
                <asp:TextBox ID="txtValor" runat="server" CssClass="auto-style8"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">TIPO DE SERVICIO:</td>
            <td>
                <asp:DropDownList ID="cboTipoServicio" runat="server" CssClass="auto-style8">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">ACTIVO:</td>
            <td>
                <asp:CheckBox ID="chkActivo" runat="server" CssClass="auto-style8" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="btnGrabar" runat="server" BackColor="#3333FF" CssClass="auto-style9" ForeColor="White" OnClick="btnGrabar_Click" Text="GRABAR" Width="280px" />
            </td>
            <td class="auto-style7">
                <asp:Button ID="btnActualizar" runat="server" BackColor="#3333FF" CssClass="auto-style9" ForeColor="White" Text="ACTUALIZAR" Width="280px" OnClick="btnActualizar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="btnConsultar" runat="server" BackColor="#3333FF" CssClass="auto-style9" ForeColor="White" Text="CONSULTAR" Width="280px" OnClick="btnConsultar_Click" />
            </td>
            <td class="auto-style7">
                <asp:Button ID="btnBorrar" runat="server" BackColor="#3333FF" CssClass="auto-style9" ForeColor="White" Text="BORRAR" Width="280px" OnClick="btnBorrar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblError" runat="server" CssClass="auto-style6" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdServicios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
