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
    public class clsBoleto
    {
        #region Constructor
        public clsBoleto() {
            iIdCliente = -1;
            iIdEvento = -1;
            iIdTipoBoleto = -1;
        }
        #endregion

        #region  Attributes
        /*Table attributes*/
        private Int32 iId;
        private Int32 iIdCliente;
        private Int32 iIdEvento;
        private Int32 iIdTipoBoleto;

        /*Local attributes*/
        private string sError;
        private GridView oGridBoleto;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 id {
            set { iId = value; }
            get { return iId; }
        }
        public Int32 idCliente {
            set { iIdCliente = value; }
            get { return iIdCliente; }
        }

        public Int32 idEvento {
            set { iIdEvento = value; }
            get { return iIdEvento;  }
        }

        public Int32 idTipoBoleto {
            set { iIdTipoBoleto = value; }
            get { return iIdTipoBoleto; }
        }

        /*Local Properties*/

        public string error {
            get { return sError; }
        }

        public GridView gridBoleto {
            set { oGridBoleto = value; }
            get { return oGridBoleto; }
        }

        #endregion

        #region Methods
        /*CRUD METODS*/
        private bool validar() { 
            if (iIdCliente<0){
                sError = "No se especifico cliente";
                return false;
            }
            if(iIdEvento<0){
                sError = "No se especifico evento";
                return false;
            }
            if (iIdTipoBoleto<0){
                sError = "No se especifico el tipo de boleto";            
            }
            return true;
        }

        public bool Grabar()
        {
            if (validar())
            {
                clsConexion oConexion = new clsConexion();
                //Lo unico que se pasa en el SQL es el nombre del procedimiento
                sSQL = "tblBoleto_Grabar";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_IDCliente", System.Data.SqlDbType.Int, 4, iIdCliente);
                oConexion.AgregarParametro("@pr_IDEvento", System.Data.SqlDbType.Int, 4, iIdEvento);
                oConexion.AgregarParametro("@pr_IDTipoBoleto", System.Data.SqlDbType.Int, 4, iIdTipoBoleto);

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
        public bool LlenarGrid()
        {
            if (oGridBoleto == null)
            {
                sError = "No definió el grid del Boleto";
                return false;
            }
            sSQL = "Execute tblBoleto_Grid";

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridBoleto;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridBoleto = oGrid.gridGenerico;
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
        public bool Consultar()
        {
            if (iIdCliente <= 0)
            {
                sError = "No definió el nombre para consultar la información";
                return false;
            }
            if (oGridBoleto == null)
            {
                sError = "No definió el grid del Boleto";
                return false;
            }
            sSQL = "Execute tblBoleto_Consultar "+iIdCliente;

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridBoleto;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridBoleto = oGrid.gridGenerico;
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


        



        #endregion
    }
}
