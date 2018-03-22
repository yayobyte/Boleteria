using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;

namespace libDesarrollo_8_10.Eventos
{
    public class clsTipoBoleto
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iIdTipoBoleto;
        private string sNombreTipoBoleto;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboTipoBoleto;
        private GridView oGridTipoBoleto;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 idTipoBoleto
        {
            set { iIdTipoBoleto = value; }
            get { return iIdTipoBoleto; }
        }

        public string nombreTipoBoleto
        {
            set { sNombreTipoBoleto = value; }
            get { return sNombreTipoBoleto; }
        }

        /*Local Properties*/
        public string error
        {
            get { return sError; }
        }

        public DropDownList comboTipoBoleto
        {
            set { oComboTipoBoleto = value; }
            get { return oComboTipoBoleto; }
        }

        public GridView gridTipoBoleto {
            set { oGridTipoBoleto = value; }
            get { return oGridTipoBoleto; }

        }

        #endregion

        #region Methods

        public bool LlenarGrid()
        {
            if (oGridTipoBoleto == null)
            {
                sError = "No definió el grid del Boleto";
                return false;
            }
            sSQL = "Execute tblTipoBoleto_Grid";

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridTipoBoleto;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridTipoBoleto = oGrid.gridGenerico;
                oGrid = null;
                return true;
            }
            else
            {
                sError = oGrid.Error;
                oGrid = null;
                return false;
            }
        }

        public bool LlenarCombo()
        {
            if (oComboTipoBoleto == null)
            {
                sError = "No definió el combo del Tipo de Boleto";
                return false;
            }
            sSQL = "Execute tblTipoBoleto_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboTipoBoleto;

            if (oCombo.LlenarComboWeb())
            {
                oComboTipoBoleto = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                sError = oCombo.Error;
                oCombo = null;
                return false;
            }
        }
        #endregion
    }
}
