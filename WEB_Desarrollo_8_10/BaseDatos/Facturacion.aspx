<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="WEB_Desarrollo_8_10.BaseDatos.Facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4" colspan="4" style="text-align: center"><strong>FACTURACIÓN DE SERVCIOS</strong></td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Número Factura:&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="auto-style3">
                <asp:Label ID="lblNumeroFactura" runat="server"></asp:Label>
            </td>
            <td class="auto-style3"><strong>Empleado: </strong></td>
            <td class="auto-style3">
                <asp:DropDownList ID="cboEmpleado" runat="server" style="font-size: x-large">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Cliente:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtCedulaCliente" runat="server" Width="140px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="52px" ImageUrl="~/Images/Buscar.jpg" OnClick="ImageButton1_Click" Width="192px" />
            </td>
            <td class="auto-style3" colspan="2">
                <asp:Label ID="lblCliente" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Tipo Servicio:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="cboTipoServicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboTipoServicio_SelectedIndexChanged" style="font-size: x-large">
                </asp:DropDownList>
            </td>
            <td class="auto-style5" style="font-weight: bold">Servicio</td>
            <td class="auto-style3">
                <asp:DropDownList ID="cboServicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboServicio_SelectedIndexChanged" style="font-size: x-large">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Valor servicio:</td>
            <td class="auto-style3">
                <asp:Label ID="lblValorServicio" runat="server"></asp:Label>
            </td>
            <td class="auto-style5" style="font-weight: bold">Cantidad:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="4" style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Grabar factura" Width="300px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="grdFactura" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
