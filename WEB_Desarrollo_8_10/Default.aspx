<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB_Desarrollo_8_10._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TicketApp</h1>
        <h2>Proyecto final</h2>
        
        <p class="lead">Bienvenido al proyecto de compra de tickets, en este software podrá manejar clientes, proveedores y gestionar la venta de tickets,
            eventos, compras a proveedores asi como consultar y eliminar algunas transacciones
        </p>
        <p><a href="Boleto/Evento" class="btn btn-info btn-large">Iniciar</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Crear Evento</h2>
            <p>
                En este link podrá crear eventos, consultar y eliminarlos.
            </p>
            <p>
                <a class="btn btn-success" href="Boleto/Evento">Crear Evento &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Venta de boletos</h2>
            <p>
                En este link podrá realizar la venta de boletos a los clientes previamente ingresador al sistema
            </p>
            <p>
                <a class="btn btn-success" href="Boleto/Boleto">Venta de Boletos &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Compras a Proveedores</h2>
            <p>
                En este link se pueden gestionar las compras que se le harán a los clientes para la venta en los eventos
            </p>
            <p>
                <a class="btn btn-success" href="Boleto/VentaProveedor">Compra a proveedores &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
