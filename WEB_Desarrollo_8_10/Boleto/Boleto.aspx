<%@ Page Title="Boletos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Boleto.aspx.cs" Inherits="WEB_Desarrollo_8_10.Boleto.Boleto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Venta de boletos</h1>
    <table class="table">
        <tr>
            <td class="auto-style4" style="font-weight: bold">Cliente:</td>
            <td class="auto-style2">
                <asp:DropDownList ID="comboViewCliente" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Evento:</td>
            <td>
                <asp:DropDownList ID="comboViewEvento" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="font-weight: bold">Tipo de Boleto:</td>
            <td>
                <asp:DropDownList ID="comboViewTipoEvento" runat="server" CssClass="form-control">
                </asp:DropDownList>
            
            </td>
        </tr>
    </table>
    
    <br />
        <table>
        
        <tr>
            <td class="auto-style7" >

                <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success"  OnClick="btnGrabar_Click" Text="Vender Boleto"  />
            </td>
            <td class="auto-style7">
                <asp:Button ID="btnConsultar" runat="server"  CssClass="btn btn-info" Text="Consultar Cliente"  OnClick="btnConsultar_Click" />
            </td>
        </tr>
        </table>    
    <br />
    <br />
       
    <div >
        <asp:Label ID="lblError" runat="server" CssClass="auto-style6" ForeColor="#CC0000"></asp:Label>
    </div>
    <asp:GridView ID="grdBoleto" runat="server"  ForeColor="#333333" GridLines="None" CssClass="table table-condensed table-bordered table-striped"></asp:GridView>
</asp:Content>
