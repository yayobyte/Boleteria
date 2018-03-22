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
    public class clsProveedorPorEvento
    {
        #region Constructor
        public clsProveedorPorEvento()
        {
            iIdProveedor = -1;
            iIdEvento = -1;
        }

        #endregion

        #region Attributes
        /*Table attributes*/
        private Int32 iIdVProveedorPorEvento;
        private Int32 iIdProveedor;
        private Int32 iIdEvento;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboProveedorPorEvento;
        private GridView oGridProveedorPorEvento;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 idProveedor
        {
            set { iIdProveedor = value; }
            get { return iIdProveedor; }
        }

        public Int32 idEvento
        {
            set { iIdEvento = value; }
            get { return iIdEvento; }
        }

        /*Local Properties*/
        public string error
        {
            get { return sError; }
        }

        public DropDownList comboVentaProveedor
        {
            set { oComboProveedorPorEvento = value; }
            get { return oComboProveedorPorEvento; }
        }
        public GridView gridProveedorPorEvento {
            set { oGridProveedorPorEvento = value; }
            get { return oGridProveedorPorEvento; }
        }


        #endregion

        #region Methods
        public bool LlenarGrid()
        {
            if (oGridProveedorPorEvento == null)
            {
                sError = "No definió el grid de las Compras a los proveedores";
                return false;
            }
            sSQL = "Exec tblProveedorxEvento_Grid";

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridProveedorPorEvento;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridProveedorPorEvento = oGrid.gridGenerico;
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
            if (iIdProveedor < 0)
            {
                sError = "No se especifico Proveedor";
                return false;
            }
            if (iIdEvento < 0)
            {
                sError = "No se especifico Evento";
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
                sSQL = "tblProveedorxEvento_Grabar";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_IDProveedor", System.Data.SqlDbType.Int, 32, iIdProveedor);
                oConexion.AgregarParametro("@pr_IDEvento", System.Data.SqlDbType.Int, 4, iIdEvento);

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
