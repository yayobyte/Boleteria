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
    public class clsTipoProveedor
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iTipoProveedor;
        private string sNombreTipoProveedor;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboTipoProveedor;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 TipoProveedor {
            set { iTipoProveedor = value; }
            get { return iTipoProveedor; }
        }

        public string NombreTipoProveedor{
            set { sNombreTipoProveedor = value; }
            get { return sNombreTipoProveedor; }
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public DropDownList ComboTipoProveedor {
            set { oComboTipoProveedor = value; }
            get { return oComboTipoProveedor; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboTipoProveedor == null)
            {
                sError = "No definió el combo del Tipo De Proveedor";
                return false;
            }
            sSQL = "Execute tblTipoProveedor_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboTipoProveedor;

            if (oCombo.LlenarComboWeb())
            {
                oComboTipoProveedor = oCombo.cboGenericoWeb;
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

