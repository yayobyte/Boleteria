using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libDesarrollo_8_10.Eventos;

namespace WEB_Desarrollo_8_10.Boleto
{
    public partial class Maestros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                LlenarGridTipoBoleto();
                LlenarGridTipoArtista();
                LlenarGridArtista();
            }

        }


        private void LlenarGridTipoBoleto()
        {

            clsTipoBoleto oTipoBoleto = new clsTipoBoleto();

            oTipoBoleto.gridTipoBoleto = gridViewTipoBoleto;
            if (!oTipoBoleto.LlenarGrid())
            {
                lblError.Text = oTipoBoleto.error;
            }
            oTipoBoleto = null;
            
        }

        private void LlenarGridTipoArtista()
        {

            clsTipoArtista oTipoArtista = new clsTipoArtista();

            oTipoArtista.gridArtista = gridViewTipoArtista;
            if (!oTipoArtista.LlenarGrid())
            {
                lblError.Text = oTipoArtista.error;
            }
            oTipoArtista = null;

        }

        private void LlenarGridArtista()
        {

            clsArtista oArtista = new clsArtista();
            
            oArtista.gridArtista = gridViewArtista;
            if (!oArtista.LlenarGrid())
            {
                lblError.Text = oArtista.error;
            }
            oArtista = null;
            
        }
    }
}