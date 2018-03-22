using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.Eventos;

namespace WEB_Desarrollo_8_10.Boleto
{
    public partial class ProveedorPorEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarGrid();
                LlenarComboEvento();
                LlenarComboProveedor();
            }
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
        private void LlenarComboEvento()
        {

            clsEvento oEvento = new clsEvento();
            oEvento.comboEvento = comboViewEvento;
            if (!oEvento.LlenarCombo())
            {
                lblError.Text = oEvento.error;
            }
            oEvento = null;
        }

        private void LlenarGrid()
        {

            clsProveedorPorEvento oProveedorPorEvento = new clsProveedorPorEvento();

            oProveedorPorEvento.gridProveedorPorEvento = gridViewOroveedorPorEvento;
            if (!oProveedorPorEvento.LlenarGrid())
            {
                lblError.Text = oProveedorPorEvento.error;
            }
            oProveedorPorEvento = null;

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            
            Int32 iIdProveedor, iIdEvento;

            iIdProveedor = Convert.ToInt32(comboViewProveedor.SelectedValue);
            iIdEvento = Convert.ToInt32(comboViewEvento.SelectedValue);

            clsProveedorPorEvento oProveedorPorEvento = new clsProveedorPorEvento();

            oProveedorPorEvento.idEvento = iIdEvento;
            oProveedorPorEvento.idProveedor = iIdProveedor;


            if (oProveedorPorEvento.Grabar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = oProveedorPorEvento.error;
            }
            oProveedorPorEvento = null;
            
        }
    }
}