using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.BaseDatos;

namespace WEB_Desarrollo_8_10.BaseDatos
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string sNombre, sPrimerApellido, sDocumento, sSegundoApellido, sTelefono, sEmail;

            sDocumento = txtDocumento.Text;
            sNombre = txtNombre.Text;
            sPrimerApellido = txtPrimerApellido.Text;
            sSegundoApellido = txtSegundoApellido.Text;
            sTelefono = txtTelefono.Text;
            sEmail = txtEmail.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = sDocumento;
            oCliente.Nombre = sNombre;
            oCliente.PrimerApellido = sPrimerApellido;
            oCliente.SegundoApellido = sSegundoApellido;
            oCliente.Telefono = sTelefono;
            oCliente.Email = sEmail;

            if (oCliente.Grabar())
            {
                lblError.Text = "Grabó";
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string sNombre, sPrimerApellido, sDocumento, sSegundoApellido, sTelefono, sEmail;

            sDocumento = txtDocumento.Text;
            sNombre = txtNombre.Text;
            sPrimerApellido = txtPrimerApellido.Text;
            sSegundoApellido = txtSegundoApellido.Text;
            sTelefono = txtTelefono.Text;
            sEmail = txtEmail.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = sDocumento;
            oCliente.Nombre = sNombre;
            oCliente.PrimerApellido = sPrimerApellido;
            oCliente.SegundoApellido = sSegundoApellido;
            oCliente.Telefono = sTelefono;
            oCliente.Email = sEmail;

            if (oCliente.Actualizar())
            {
                lblError.Text = "Actualizó";
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string sDocumento;

            sDocumento = txtDocumento.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = sDocumento;

            if (oCliente.Consultar())
            {
                txtNombre.Text = oCliente.Nombre;
                txtPrimerApellido.Text = oCliente.PrimerApellido;
                txtSegundoApellido.Text = oCliente.SegundoApellido;
                txtTelefono.Text = oCliente.Telefono;
                txtEmail.Text = oCliente.Email;
                lblError.Text = "";
            }
            else
            {
                lblError.Text = oCliente.Error;
                txtNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
            }
            oCliente = null;
        }
    }
}