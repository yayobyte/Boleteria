using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libDesarrollo_8_10.BaseDatos
{
    public class clsEmpleado
    {
        #region "Atributos"
            private DropDownList ocboEmpleado;
            private string sError;
            private string sSQL;
        #endregion

        #region "Propiedades"
            public DropDownList cboEmpleado
            {
                get { return ocboEmpleado; }
                set { ocboEmpleado = value; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            public bool LlenarCombo()
            {
                if (ocboEmpleado == null)
                {
                    sError = "No definió el combo del empleado";
                    return false;
                }
                sSQL = "Execute Empleado_S_Combo";

                clsCombos oCombo = new clsCombos();
                oCombo.SQL = sSQL;
                oCombo.ColumnaTexto = "Cliente";//Nombre de la columna que quiero mostrar en el combo
                oCombo.ColumnaValor = "Cedula";//Nombre de la columna que quiero almacenar
                oCombo.cboGenericoWeb = ocboEmpleado;

                if (oCombo.LlenarComboWeb())
                {
                    ocboEmpleado = oCombo.cboGenericoWeb;
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
