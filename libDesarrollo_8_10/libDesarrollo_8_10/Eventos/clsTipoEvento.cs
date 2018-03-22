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
    public class clsTipoEvento
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iIdTipoEvento;
        private string sNombreTipoEvento;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboTipoEvento;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 idTipoEvento {
            set { iIdTipoEvento = value; }
            get { return iIdTipoEvento; }
        }

        public string NombreTipoEvento {
            set { sNombreTipoEvento = value; }
            get { return sNombreTipoEvento;}
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public DropDownList comboTipoEvento {
            set { oComboTipoEvento = value; }
            get { return oComboTipoEvento; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboTipoEvento == null)
            {
                sError = "No definió el combo del Tipo De Evento";
                return false;
            }
            sSQL = "Execute tblTipoEvento_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboTipoEvento;

            if (oCombo.LlenarComboWeb())
            {
                oComboTipoEvento = oCombo.cboGenericoWeb;
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

