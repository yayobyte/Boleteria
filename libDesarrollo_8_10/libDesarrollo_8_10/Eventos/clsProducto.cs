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
    public class clsProducto
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iIdProducto;
        private string sNombreProducto;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboProducto;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 IdProducto {
            set { iIdProducto = value; }
            get { return iIdProducto; }
        }

        public string NombreProducto {
            set { sNombreProducto = value; }
            get { return sNombreProducto; }
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public DropDownList ComboProducto {
            set { oComboProducto = value; }
            get { return oComboProducto; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboProducto== null)
            {
                sError = "No definió el combo del Producto";
                return false;
            }
            sSQL = "Execute tblProducto_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboProducto;

            if (oCombo.LlenarComboWeb())
            {
                oComboProducto = oCombo.cboGenericoWeb;
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

