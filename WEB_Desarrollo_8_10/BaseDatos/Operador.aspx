<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Operador.aspx.cs" Inherits="WEB_Desarrollo_8_10.BaseDatos.Operador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="70%">
        <tr>
            <td colspan="2" style="text-align: center; font-size: xx-large; font-weight: 700">OPERADORES DE CELULAR</td>
        </tr>
        <tr>
            <td style="font-size: xx-large; height: 27px"><b>CODIGO:</b></td>
            <td style="height: 27px">
                <asp:TextBox ID="txtCodigo" runat="server" style="font-size: xx-large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: xx-large"><b>NOMBRE:</b></td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" style="font-size: xx-large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: xx-large"><b>ACTIVO:</b></td>
            <td>
                <asp:CheckBox ID="chkActivo" runat="server" style="font-size: xx-large" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="height: 25px">
                <asp:Button ID="btnGrabar" runat="server" Text="GRABAR" BackColor="#0066FF" ForeColor="White" OnClick="btnGrabar_Click" style="font-size: xx-large" Width="300px" />
            </td>
            <td style="height: 25px; text-align: center">
                <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" BackColor="#0066FF" ForeColor="White" style="font-size: xx-large" Width="300px" OnClick="btnActualizar_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="height: 25px">
                <asp:Button ID="btnBorrar" runat="server" Text="BORRAR" BackColor="#0066FF" ForeColor="White" style="font-size: xx-large" Width="300px" OnClick="btnBorrar_Click" />
            </td>
            <td class="text-center" style="height: 25px; text-align: center;">
                <asp:Button ID="btnConsultar" runat="server" Text="CONSULTAR" BackColor="#0066FF" ForeColor="White" style="font-size: xx-large" Width="300px" OnClick="btnConsultar_Click" />
            </td>
        </tr>
        <tr>
            <td style="height: 37px">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td style="height: 37px"></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdOperador" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
