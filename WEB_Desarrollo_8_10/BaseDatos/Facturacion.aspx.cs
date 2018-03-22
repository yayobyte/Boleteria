using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.BaseDatos;

namespace WEB_Desarrollo_8_10.BaseDatos
{
    public partial class Facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarComboTipoServicio();
                LlenarComboEmpleado();
            }
        }

        private void LlenarComboTipoServicio()
        {
            clsTipoServicio oTipoServicio = new clsTipoServicio();
            oTipoServicio.cboTipoServicio = cboTipoServicio;
            if (!oTipoServicio.LlenarCombo())
            {
                lblError.Text = oTipoServicio.Error;
            }
            else
            {
                LlenarComboServicio();
            }
            oTipoServicio = null;
        }

        private void LlenarComboEmpleado()
        {
            clsEmpleado oEmpleado = new clsEmpleado();
            oEmpleado.cboEmpleado = cboEmpleado;
            if (!oEmpleado.LlenarCombo())
            {
                lblError.Text = oEmpleado.Error;
            }
            oEmpleado = null;
        }

        private void LlenarComboServicio()
        {
            Int32 iCodigoTipoServicio = Convert.ToInt32(cboTipoServicio.SelectedValue);
            clsServicio oServicio = new clsServicio();
            oServicio.cboServicio = cboServicio;
            oServicio.CodigoTipoServicio = iCodigoTipoServicio;
            if (!oServicio.LlenarComboServicio())
            {
                lblError.Text = oServicio.Error;
            }
            else
            {
                ConsultarPrecio();
            }
            oServicio = null;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void cboTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboServicio();
        }

        protected void cboServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarPrecio();
        }

        private void ConsultarPrecio()
        {
            Int32 iCodigoServicio = Convert.ToInt32(cboServicio.SelectedValue);

            clsServicio oServicio = new clsServicio();

            oServicio.Codigo = iCodigoServicio;
            if (oServicio.Consultar())
            {
                lblValorServicio.Text = oServicio.Valor.ToString();
            }
            oServicio = null;
        }
    }
}