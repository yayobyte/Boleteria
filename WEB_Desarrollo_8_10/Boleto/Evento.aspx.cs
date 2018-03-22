using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.Eventos;

namespace WEB_Desarrollo_8_10.Boleto
{
    public partial class Evento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtNombreEvento.Attributes.Add("placeholder", "ej: Feria de las dos ruedas");
                txtFecha.Attributes.Add("placeholder", "ej: 2015-12-01");
                txtBuscarEvento.Attributes.Add("placeholder", "Nombre de evento");
                txtEliminarEvento.Attributes.Add("placeholder", "#de evento");
                LlenarGrid();
                LlenarComboArtista();
                LlenarComboTipoEvento();
                LlenarComboEstablecimiento();
            }
        }
        private void LlenarGrid()
        {
            
            clsEvento oEvento = new clsEvento();

            oEvento.gridEvento = grdEvento;
            if (!oEvento.LlenarGrid())
            {
                lblError.Text = oEvento.error;
            }
            oEvento = null;
             
        }

        private void LlenarComboArtista()
        {

            clsArtista oArtista = new clsArtista();
            oArtista.ComboArtista = comboViewArtista;
            if (!oArtista.LlenarCombo())
            {
                lblError.Text = oArtista.error;
            }
            oArtista = null;
        }
        private void LlenarComboTipoEvento()
        {

            clsTipoEvento oTipoEvento = new clsTipoEvento();
            oTipoEvento.comboTipoEvento = comboViewTipoEvento;
            if (!oTipoEvento.LlenarCombo())
            {
                lblError.Text = oTipoEvento.error;
            }
            oTipoEvento = null;
        }

        private void LlenarComboEstablecimiento()
        {

            clsEstablecimiento oEstablecimiento = new clsEstablecimiento();
            oEstablecimiento.ComboEstablecimiento = comboViewEstablecimiento;
            if (!oEstablecimiento.LlenarCombo())
            {
                lblError.Text = oEstablecimiento.error;
            }
            oEstablecimiento = null;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            Int32 iIdArtista, iIdTipoEvento, iIdEstablecimiento;
            string sNombreEvento;
            DateTime dtFecha;

            sNombreEvento = txtNombreEvento.Text;
            iIdArtista = Convert.ToInt32(comboViewArtista.SelectedValue);
            dtFecha = Convert.ToDateTime(txtFecha.Text);
            iIdTipoEvento = Convert.ToInt32(comboViewTipoEvento.SelectedValue);
            iIdEstablecimiento = Convert.ToInt32(comboViewEstablecimiento.SelectedValue);

            clsEvento oEvento = new clsEvento();

            oEvento.nombreEvento = sNombreEvento;
            oEvento.idArtista = iIdArtista;
            oEvento.fecha = dtFecha;
            oEvento.idTipoEvento = iIdTipoEvento;
            oEvento.idEstablecimiento = iIdEstablecimiento;


            if (oEvento.Grabar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = oEvento.error;
            }
            oEvento = null;
            

        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            clsEvento oEvento = new clsEvento();

            oEvento.nombreEvento = txtBuscarEvento.Text;
            oEvento.gridEvento = grdEvento;
            if (!oEvento.Consultar())
            {
                lblError.Text = oEvento.error;
            }
            oEvento = null;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 iCodigo;

            iCodigo = Convert.ToInt32(txtEliminarEvento.Text);
            clsEvento oEvento = new clsEvento();

            oEvento.idEvento = iCodigo;
            
            if (oEvento.Borrar())
            {
                //Llenar grid
                LlenarGrid();
            }
            else
            {
                lblError.Text = "No se puede borrar el evento, posiblemente ya se encuentren boletas vendidas <br><small>" + oEvento.error + "</small>";
            }
            oEvento = null;
            
        }
    }
}