<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maestros.aspx.cs" Inherits="WEB_Desarrollo_8_10.Boleto.Maestros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Maestros</h1>
    <ul class="nav nav-tabs" id="tabs">
        <li role="presentation" onclick="changeContent('tipoBoleto')" id="tipoBoletoLi" class="active"><a href="#">Tipo Boleto</a></li>
        <li role="presentation" onclick="changeContent('tipoArtista')" id="tipoArtistaLi"><a href="#">Tipo Artista</a></li>
        <li role="presentation" onclick="changeContent('artista')" id="artistaLi"><a href="#">Artista</a></li>
    </ul>

    <asp:Label ID="lblError" runat="server" CssClass="auto-style6" ForeColor="#CC0000"></asp:Label>
    <div id="masterContent" style="display:none"></div>

    <div style="display:none">
        

        <div id="tipoBoletoContent">
            <h3>Tipo Boleto</h3>
            <asp:GridView ID="gridViewTipoBoleto" runat="server" ForeColor="#333333" GridLines="None" CssClass="table table-condensed table-bordered table-striped table-hover"></asp:GridView>
        </div>

        <div id="tipoArtistaContent">
            <h3>Tipo Artista</h3>
            <asp:GridView ID="gridViewTipoArtista" runat="server" ForeColor="#333333" GridLines="None" CssClass="table table-condensed table-bordered table-striped table-hover"></asp:GridView>
        </div>

        <div id="artistaContent">
            <h3>Artista</h3>
            <asp:GridView ID="gridViewArtista" runat="server" ForeColor="#333333" GridLines="None" CssClass="table table-condensed table-bordered table-striped table-hover"></asp:GridView>
        </div>
    </div>
    <script type="text/javascript">
        var $master = $('#masterContent');
        $master.html($('#tipoBoletoContent').html());
        $master.show(500);

        var actual = '#tipoBoletoLi';

        function changeContent(id) {
            var $id = $('#'+id+'Content');
            var $master = $('#masterContent');

            $(actual).removeClass();
            
            actual = '#' + id + 'Li';
            $(actual).addClass('active');
            $master.hide(100);
            $master.html($id.html());
            $master.show(500);

        }
    </script>
</asp:Content>
