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
    public class clsEvento
    {
        #region Constructor
        public clsEvento() {
            iIdArtista = -1;
            iIdTipoEvento = -1;
            iIdEstablecimiento = -1;
        }
        #endregion

        #region Attributes
        /*Table attributes*/
        private Int32 iIdEvento;
        private string sNombreEvento;
        private Int32 iIdArtista;
        private DateTime dtFecha;
        private Int32 iIdTipoEvento;
        private Int32 iIdEstablecimiento;

        /*Local Attributes*/
        private string sError;
        private GridView oGridEvento;
        private DropDownList oComboEvento;
        private string sSQL;
        #endregion

        #region Properties
        /*Table Properties*/
        public Int32 idEvento {
            set { iIdEvento = value; }
            get { return iIdEvento; }
        }

        public string nombreEvento {
            set { sNombreEvento = value; }
            get { return sNombreEvento; }
        }

        public Int32 idArtista {
            set { iIdArtista = value; }
            get { return iIdArtista; }
        }

        public DateTime fecha {
            set { dtFecha = value; }
            get { return dtFecha; }
        }

        public Int32 idTipoEvento {
            set { iIdTipoEvento = value; }
            get { return iIdTipoEvento; }
        }

        public Int32 idEstablecimiento {
            set { iIdEstablecimiento = value; }
            get { return iIdEstablecimiento; }
        }

        /*Local Properties*/
        public string error {
            get { return sError; }
        }

        public GridView gridEvento
        {
            set { oGridEvento = value; }
            get { return oGridEvento; }
        }

        public DropDownList comboEvento {
            set { oComboEvento = value; }
            get { return oComboEvento; }
        }

        #endregion

        #region Methods

        public bool LlenarGrid()
        {
            if (oGridEvento == null)
            {
                sError = "No definió el grid del Boleto";
                return false;
            }
            sSQL = "Execute tblEvento_Grid";

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridEvento;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridEvento = oGrid.gridGenerico;
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
        public bool LlenarCombo()//Combo Evento
        {
            if (oComboEvento == null)
            {
                sError = "No definió el combo del Evento";
                return false;
            }
            sSQL = "Execute tblEvento_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = sSQL;
            oCombo.ColumnaTexto = "Nombre";
            oCombo.ColumnaValor = "Codigo";
            oCombo.cboGenericoWeb = oComboEvento;

            if (oCombo.LlenarComboWeb())
            {
                oComboEvento = oCombo.cboGenericoWeb;
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
        private bool validar()
        {
            if (iIdArtista < 0)
            {
                sError = "No se especifico Artista";
                return false;
            }
            if (iIdTipoEvento < 0)
            {
                sError = "No se especifico tipo de evento";
                return false;
            }
            if (iIdEstablecimiento < 0)
            {
                sError = "No se especifico el establecimiento";
            }
            if (string.IsNullOrEmpty(sNombreEvento))
            {
                sError = "No definió el nombre del servicio";
                return false;
            }
            if (dtFecha == DateTime.MinValue)
            {
                sError = "No definió fecha";
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
                sSQL = "tblEvento_Grabar";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_NombreEvento", System.Data.SqlDbType.VarChar, 32, sNombreEvento);
                oConexion.AgregarParametro("@pr_IDArtista", System.Data.SqlDbType.Int, 4, iIdArtista);
                oConexion.AgregarParametro("@pr_Fecha", System.Data.SqlDbType.DateTime, 4, dtFecha);
                oConexion.AgregarParametro("@pr_IDTipoEvento", System.Data.SqlDbType.Int, 4, iIdTipoEvento);
                oConexion.AgregarParametro("@pr_IDEstablecimiento", System.Data.SqlDbType.Int, 4, iIdEstablecimiento);

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

        public bool Consultar()
        {
            if (string.IsNullOrEmpty(sNombreEvento))
            {
                sError = "No definió el nombre del evento para consultar la información";
                return false;
            }
            if (oGridEvento == null)
            {
                sError = "No definió el grid del Evento";
                return false;
            }
            sSQL = "exec tblEvento_Consultar '" + sNombreEvento + "'";

            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.gridGenerico = oGridEvento;
            //se pasa el sql
            oGrid.SQL = sSQL;
            if (oGrid.LlenarGridWeb())
            {
                oGridEvento = oGrid.gridGenerico;
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
        
        public bool Borrar()
        {
            if (iIdEvento <= 0)
            {
                sError = "No definió el código para borrar la información";
                return false;
            }

            clsConexion oConexion = new clsConexion();
            //Lo unico que se pasa en el SQL es el nombre del procedimiento
            sSQL = "tblEvento_Borrar";

            oConexion.SQL = sSQL;

            //Se pasan los parámetros
            //El tamaño de los parámetros "sólo aplica" para los tipo varchar
            oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, iIdEvento);

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
        



        #endregion

    }
}

