using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libDesarrollo_8_10.BaseDatos
{
    public class clsTipoServicio
    {
        #region "Atributos"
            private DropDownList ocboTipoServicio;
            private string sError;
            private string sSQL;
        #endregion

        #region "Propiedades"
            public DropDownList cboTipoServicio
            {
                get { return ocboTipoServicio; }
                set { ocboTipoServicio = value; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            public bool LlenarCombo()
            {
                if (ocboTipoServicio == null)
                {
                    sError = "No definió el combo del tipo de servicio";
                    return false;
                }
                sSQL = "Execute TipoServicio_S_Combo";

                clsCombos oCombo = new clsCombos();
                oCombo.SQL = sSQL;
                oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
                oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
                oCombo.cboGenericoWeb = ocboTipoServicio;

                if (oCombo.LlenarComboWeb())
                {
                    ocboTipoServicio = oCombo.cboGenericoWeb;
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
