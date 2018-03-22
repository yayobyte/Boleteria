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
    public class clsCategoriaProducto
    {
        #region Attributes
        /*Table attributes*/
        private Int32 iIdCategoriaProducto;
        private string sNombreCategoria;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboCategoriaProducto;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 IdCategoriaProducto {
            set { iIdCategoriaProducto = value; }
            get { return iIdCategoriaProducto; }
        }

        public string NombreCategoria {
            set { sNombreCategoria = value; }
            get { return sNombreCategoria; }
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public DropDownList ComboCategoriaProducto {
            set { oComboCategoriaProducto = value; }
            get { return oComboCategoriaProducto; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboCategoriaProducto == null)
            {
                sError = "No definió el combo de la Categoria del Producto";
                return false;
            }
            sSQL = "Execute tblCategoriaProducto_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboCategoriaProducto;

            if (oCombo.LlenarComboWeb())
            {
                oComboCategoriaProducto = oCombo.cboGenericoWeb;
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

