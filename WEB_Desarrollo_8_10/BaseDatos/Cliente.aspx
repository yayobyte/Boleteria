<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="WEB_Desarrollo_8_10.BaseDatos.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="text-align: center; font-size: large">CLIENTES</td>
        </tr>
        <tr>
            <td style="font-size: large">Documento:</td>
            <td>
                <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large">Nombre:</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large">Primer Aperllido</td>
            <td>
                <asp:TextBox ID="txtPrimerApellido" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large">Segundo Apellido:</td>
            <td>
                <asp:TextBox ID="txtSegundoApellido" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large">Telefono:</td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large">Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Button ID="btnGrabar" runat="server" BackColor="#3333CC" BorderColor="#0066FF" ForeColor="White" Text="GRABAR" Width="220px" OnClick="btnGrabar_Click" />
            </td>
            <td class="text-center">
                <asp:Button ID="btnActualizar" runat="server" BackColor="#3333CC" BorderColor="#0066FF" ForeColor="White" Text="ACTUALIZAR" Width="220px" OnClick="btnActualizar_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Button ID="btnConsultar" runat="server" BackColor="#3333CC" BorderColor="#0066FF" ForeColor="White" Text="CONSULTAR" Width="220px" OnClick="btnConsultar_Click" />
            </td>
            <td class="text-center">
                <asp:Button ID="btnBorrar" runat="server" BackColor="#3333CC" BorderColor="#0066FF" ForeColor="White" Text="BORRAR" Width="220px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
