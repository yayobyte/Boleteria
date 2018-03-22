using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.Eventos;

namespace WEB_Desarrollo_8_10.Boleto
{
    public partial class VentaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarGrid();
                LlenarComboProducto();
                LlenarComboProveedor();
            }
        }

        private void LlenarGrid()
        {

            clsVentaProveedor oVentaProveedor = new clsVentaProveedor();

            oVentaProveedor.gridVentaProveedor = grdVentaProveedor;
            if (!oVentaProveedor.LlenarGrid())
            {
                lblError.Text = oVentaProveedor.error;
            }
            oVentaProveedor = null;
            
        }

        private void LlenarComboProducto()
        {

            clsProducto oProducto = new clsProducto();
            oProducto.ComboProducto = comboViewProducto;
            if (!oProducto.LlenarCombo())
            {
                lblError.Text = oProducto.error;
            }
            oProducto = null;
        }

        private void LlenarComboProveedor()
        {

            clsProveedor oProveedor = new clsProveedor();
            oProveedor.ComboProveedor = comboViewProveedor;
            if (!oProveedor.LlenarCombo())
            {
                lblError.Text = oProveedor.error;
            }
            oProveedor = null;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            
            Int32 iIdProveedor, iIdProducto;

            iIdProveedor = Convert.ToInt32(comboViewProveedor.SelectedValue);
            iIdProducto = Convert.ToInt32(comboViewProducto.SelectedValue);

            clsVentaProveedor oVentaProveedor = new clsVentaProveedor();

            oVentaProveedor.idProducto = iIdProducto;
            oVentaProveedor.idProveedor = iIdProveedor;

            
            if (oVentaProveedor.Grabar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = oVentaProveedor.error;
            }
            oVentaProveedor = null;
            

        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            
        }
    }
}