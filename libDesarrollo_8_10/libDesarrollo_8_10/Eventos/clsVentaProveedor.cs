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
    public class clsVentaProveedor
    {
        #region Constructor
        public clsVentaProveedor() {
            iIdProveedor = -1;
            iIdProducto = -1;
        }

        #endregion

        #region Attributes
        /*Table attributes*/
        private Int32 iIdVenta;
        private Int32 iIdProveedor;
        private Int32 iIdProducto;

        /*Local Attributes*/
        private string sError;
        private DropDownList oComboVentaProveedor;
        private GridView oGridVentaProveedor;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 idProveedor
        {
            set { iIdProveedor = value; }
            get { return iIdProveedor; }
        }

        public Int32 idProducto
        {
            set { iIdProducto = value; }
            get { return iIdProducto; }
        }

        /*Local Properties*/
        public string error
        {
            get { return sError; }
        }

        public DropDownList comboVentaProveedor
        {
            set { oComboVentaProveedor = value; }
            get { return oComboVentaProveedor; }
        }
        public GridView gridVentaProveedor {
            set { oGridVentaProveedor = value; }
            get { return oGridVentaProveedor; }
        }


        #endregion

        #region Methods
        public bool LlenarGrid()
        {
            if (oGridVentaProveedor == null)
            {
                sError = "No definió el grid de las Compras a los proveedores";
                return false;
            }
            sSQL = "Exec tblVentaProveedor_Grid";

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridVentaProveedor;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridVentaProveedor = oGrid.gridGenerico;
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
            if (iIdProducto < 0)
            {
                sError = "No se especifico tipo de Producto";
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
                sSQL = "tblVentaProveedor_Grabar";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_IDProveedor", System.Data.SqlDbType.Int, 32, iIdProveedor);
                oConexion.AgregarParametro("@pr_IDProducto", System.Data.SqlDbType.Int, 4, iIdProducto);

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
