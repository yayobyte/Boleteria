using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.BaseDatos;

namespace WEB_Desarrollo_8_10.BaseDatos
{
    public partial class Servicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarCombo();
                LlenarGrid();
            }
        }

        private void LlenarGrid()
        {
            clsServicio oServicio = new clsServicio();

            oServicio.grdServicio = grdServicios;
            if (!oServicio.LlenarGrid())
            {
                lblError.Text = oServicio.Error;
            }
            oServicio = null;
        }

        private void LlenarCombo()
        {
            clsTipoServicio oTipoServicio = new clsTipoServicio();
            oTipoServicio.cboTipoServicio = cboTipoServicio;
            if (!oTipoServicio.LlenarCombo())
            {
                lblError.Text = oTipoServicio.Error;
            }
            oTipoServicio = null;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string sNombre;
            Int32 iValor, iCodigoTipoServicio;
            bool bActivo;

            sNombre = txtNombre.Text;
            iValor = Convert.ToInt32(txtValor.Text);
            bActivo = chkActivo.Checked;
            iCodigoTipoServicio = Convert.ToInt32(cboTipoServicio.SelectedValue);

            clsServicio oServicio = new clsServicio();

            oServicio.Nombre = sNombre;
            oServicio.Valor = iValor;
            oServicio.Activo = bActivo;
            oServicio.CodigoTipoServicio = iCodigoTipoServicio;

            if (oServicio.Grabar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = oServicio.Error;
            }
            oServicio = null;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string sNombre;
            Int32 iValor, iCodigoTipoServicio, iCodigo;
            bool bActivo;

            iCodigo = Convert.ToInt32(txtCodigo.Text);
            sNombre = txtNombre.Text;
            iValor = Convert.ToInt32(txtValor.Text);
            bActivo = chkActivo.Checked;
            iCodigoTipoServicio = Convert.ToInt32(cboTipoServicio.SelectedValue);

            clsServicio oServicio = new clsServicio();

            oServicio.Codigo = iCodigo;
            oServicio.Nombre = sNombre;
            oServicio.Valor = iValor;
            oServicio.Activo = bActivo;
            oServicio.CodigoTipoServicio = iCodigoTipoServicio;

            if (oServicio.Actualizar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = oServicio.Error;
            }
            oServicio = null;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 iCodigo;

            iCodigo = Convert.ToInt32(txtCodigo.Text);
            clsServicio oServicio = new clsServicio();

            oServicio.Codigo = iCodigo;

            if (oServicio.Borrar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = oServicio.Error;
            }
            oServicio = null;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 iCodigo;

            iCodigo = Convert.ToInt32(txtCodigo.Text);

            clsServicio oServicio = new clsServicio();

            oServicio.Codigo = iCodigo;

            if (oServicio.Consultar())
            {
                txtNombre.Text = oServicio.Nombre;
                txtValor.Text = oServicio.Valor.ToString();
                chkActivo.Checked = oServicio.Activo;
                cboTipoServicio.SelectedValue = oServicio.CodigoTipoServicio.ToString();
            }
            else
            {
                lblError.Text = oServicio.Error;
            }
            oServicio = null;
        }
    }
}