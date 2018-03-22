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
    public class clsNacionalidad
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iIdNacionalidad;
        private string sNombreNacionalidad;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboNacionalidad;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 IdNacionalidad {
            set { iIdNacionalidad = value; }
            get { return iIdNacionalidad; }
        }

        public string NombreNacionalidad {
            set { sNombreNacionalidad = value; }
            get { return sNombreNacionalidad; }
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public DropDownList ComboNacionalidad {
            set { oComboNacionalidad = value; }
            get { return oComboNacionalidad; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboNacionalidad == null)
            {
                sError = "No definió el combo de la Nacionalidad";
                return false;
            }
            sSQL = "Execute tblNacionalidad_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboNacionalidad;

            if (oCombo.LlenarComboWeb())
            {
                oComboNacionalidad = oCombo.cboGenericoWeb;
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

