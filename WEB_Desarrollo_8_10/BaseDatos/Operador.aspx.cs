using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.BaseDatos;

namespace WEB_Desarrollo_8_10.BaseDatos
{
    public partial class Operador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Es la primera vez que se carga la  página
                LlenarGrid();
            }
        }

        private void LlenarGrid()
        {
            clsOperador oOperador = new clsOperador();

            oOperador.grdOperador = grdOperador;
            if (!oOperador.LlenarGrid())
            {
                lblError.Text = oOperador.Error;
            }
            oOperador = null;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string sNombre;
            bool bActivo;

            sNombre = txtNombre.Text;
            bActivo = chkActivo.Checked;

            clsOperador oOperador = new clsOperador();
            oOperador.Nombre = sNombre;
            oOperador.Activo = bActivo;

            if (oOperador.Grabar())
            {
                LlenarGrid();
            }
            else 
            {
                lblError.Text = oOperador.Error;
            }
            oOperador = null;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 iCodigo;
            string sNombre;
            bool bActivo;

            sNombre = txtNombre.Text;
            bActivo = chkActivo.Checked;
            iCodigo = Convert.ToInt32(txtCodigo.Text);

            clsOperador oOperador = new clsOperador();
            oOperador.Nombre = sNombre;
            oOperador.Activo = bActivo;
            oOperador.Codigo = iCodigo;

            if (oOperador.Actualizar())
            {
                LlenarGrid();
            }
            else
            {
                lblError.Text = oOperador.Error;
            }
            oOperador = null;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 iCodigo;
            string sNombre;
            bool bActivo;

            sNombre = txtNombre.Text;
            bActivo = chkActivo.Checked;
            iCodigo = Convert.ToInt32(txtCodigo.Text);

            clsOperador oOperador = new clsOperador();
            oOperador.Nombre = sNombre;
            oOperador.Activo = bActivo;
            oOperador.Codigo = iCodigo;

            if (oOperador.Borrar())
            {
                LlenarGrid();
            }
            else
            {
                lblError.Text = oOperador.Error;
            }
            oOperador = null;

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 iCodigo;
            
            iCodigo = Convert.ToInt32(txtCodigo.Text);

            clsOperador oOperador = new clsOperador();
            
            oOperador.Codigo = iCodigo;

            if (oOperador.Consultar())
            {

                txtNombre.Text = oOperador.Nombre;
                chkActivo.Checked = oOperador.Activo;
                lblError.Text = "";
                

            }
            else
            {

                lblError.Text = oOperador.Error;
                txtNombre.Text="";
            }
            oOperador = null;

        }
    }
}