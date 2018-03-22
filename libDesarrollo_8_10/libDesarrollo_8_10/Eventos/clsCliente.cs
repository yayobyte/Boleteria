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
    public class clsCliente
    {
        #region Atributes
        /*Table attributes */
        private string sNombre;
        private string sCorreo;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboCliente;
        private GridView oGridCliente;
        private string sSQL;

        #endregion

        #region Properties

        public string nombre {
            set { sNombre = value; }
            get { return sNombre; }
        }

        public string correo {
            set { sCorreo = value; }
            get { return sCorreo; }
        }

        public string error {
            get { return sError; }
        }

        public DropDownList comboCliente {
            set { oComboCliente = value; }
            get { return oComboCliente; }
        }

        public GridView gridCliente
        {
            set { oGridCliente = value; }
            get { return oGridCliente; }
        }

        public string SQL {
            set { sSQL = value; }
            get { return sSQL; }
        }

        #endregion

        #region Methods
        public bool LlenarCombo()
        {
            if (oComboCliente == null)
            {
                sError = "No definió el combo del Cliente";
                return false;
            }
            sSQL = "Execute tblCliente_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
            oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
            oCombo.cboGenericoWeb = oComboCliente;

            if (oCombo.LlenarComboWeb())
            {
                oComboCliente = oCombo.cboGenericoWeb;
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

        public bool LlenarGrid()
        {
            if (oGridCliente == null)
            {
                sError = "No definió el grid del Boleto";
                return false;
            }
            sSQL = "Execute tblCliente_Grid";

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridCliente;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridCliente = oGrid.gridGenerico;
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

        private bool validar()
        {
            
            if (string.IsNullOrEmpty(sNombre))
            {
                sError = "No definió el nombre del cliente";
                return false;
            }

            if (string.IsNullOrEmpty(sNombre))
            {
                sError = "No definió el nombre del cliente";
                return false;
            }
            
            return true;
        }

        public bool Grabar()
        {
            if (validar())
            {
                clsConexion oConexion = new clsConexion();
                //Lo unico que se pasa en el SQL es el nombre del procedimiento
                sSQL = "tblCliente_Grabar";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_Nombre", System.Data.SqlDbType.VarChar, 50, sNombre);
                oConexion.AgregarParametro("@pr_Correo", System.Data.SqlDbType.VarChar, 50, sCorreo);

                if (oConexion.EjecutarSentencia())
                {
                    oConexion = null;
                    return true;
                }
                else
                {
                    sError = oConexion.Error;
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
