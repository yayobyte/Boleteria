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
    public class clsProveedor
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iIdProveedor;
        private string sNombreProveedor;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboProveedor;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 IdProveedor {
            set { iIdProveedor = value; }
            get { return iIdProveedor; }
        }

        public string NombreProveedor {
            set { sNombreProveedor = value; }
            get { return sNombreProveedor; }
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public DropDownList ComboProveedor {
            set { oComboProveedor = value; }
            get { return oComboProveedor; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboProveedor == null)
            {
                sError = "No definió el combo del Proveedor";
                return false;
            }
            sSQL = "Execute tblProveedor_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboProveedor;

            if (oCombo.LlenarComboWeb())
            {
                oComboProveedor = oCombo.cboGenericoWeb;
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

