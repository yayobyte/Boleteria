using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.Eventos;

namespace WEB_Desarrollo_8_10.Boleto
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                txtNombre.Attributes.Add("placeholder", "ej: Ana Luisa Portillo");
                txtCorreo.Attributes.Add("placeholder", "ej: anny@gmail.com");
                
                LlenarGrid();
            }

        }

        private void LlenarGrid()
        {

            clsCliente oCliente = new clsCliente();

            oCliente.gridCliente = gridViewCliente;
            if (!oCliente.LlenarGrid())
            {
                lblError.Text = oCliente.error;
            }
            oCliente = null;

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            string sNombre, sCorreo;

            sNombre = txtNombre.Text;
            sCorreo = txtCorreo.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.nombre = sNombre;
            oCliente.correo = sCorreo;


            if (oCliente.Grabar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = oCliente.error;
            }
            oCliente = null;


        }
    }
}