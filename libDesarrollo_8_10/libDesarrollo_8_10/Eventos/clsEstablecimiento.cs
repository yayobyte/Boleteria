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
    public class clsEstablecimiento
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iIDEstablecimiento;
        private string sNombreEstablecimiento;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboEstablecimiento;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 IDEstablecimiento {
            set { IDEstablecimiento = value; }
            get { return iIDEstablecimiento; }
        }

        public string NombreEstablecimiento {
            set { sNombreEstablecimiento = value; }
            get { return sNombreEstablecimiento;}
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public DropDownList ComboEstablecimiento {
            set { oComboEstablecimiento = value; }
            get { return oComboEstablecimiento; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboEstablecimiento == null)
            {
                sError = "No definió el combo del Establecimiento";
                return false;
            }
            sSQL = "Execute tblEstablecimiento_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboEstablecimiento;

            if (oCombo.LlenarComboWeb())
            {
                oComboEstablecimiento = oCombo.cboGenericoWeb;
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

