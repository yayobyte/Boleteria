using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;

namespace libDesarrollo_8_10.BaseDatos
{
    public class clsServicio
    {
        #region "Constructor"
            public clsServicio()
            {
                iCodigoTipoServicio = 0;
                Codigo = 0;
                iValor = 0;
            }
        #endregion

        #region "Atributos"
            private Int32 iCodigo;
            private string sNombre;
            private Int32 iValor;
            private Int32 iCodigoTipoServicio;
            private bool bActivo;
            private string sSQL;
            private GridView ogrdServicio;
            private DropDownList ocboServicio;
            private string sError;
        #endregion

        #region "Propiedades"
            public Int32 Codigo
            {
                get { return iCodigo; }
                set { iCodigo = value; }
            }

            public string Nombre
            {
                get { return sNombre; }
                set { sNombre = value; }
            }

            public Int32 Valor
            {
                get { return iValor; }
                set { iValor = value; }
            }

            public Int32 CodigoTipoServicio
            {
                get { return iCodigoTipoServicio; }
                set { iCodigoTipoServicio = value; }
            }

            public bool Activo
            {
                get { return bActivo; }
                set { bActivo = value; }
            }

            public GridView grdServicio
            {
                get { return ogrdServicio; }
                set { ogrdServicio = value; }
            }

            public DropDownList cboServicio
            {
                get { return ocboServicio; }
                set { ocboServicio = value; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            private bool Validar()
            {
                if (string.IsNullOrEmpty(sNombre))
                {
                    sError = "No definió el nombre del servicio";
                    return false;
                }
                if (iCodigoTipoServicio <= 0)
                {
                    sError = "No definió el tipo de servicio";
                    return false;
                }
                if (iValor <= 0)
                {
                    sError = "No definió el valor del servicio";
                    return false;
                }
                return true;
            }

            public bool Grabar()
            {
                if (Validar())
                {
                    clsConexion oConexion = new clsConexion();
                    //Lo unico que se pasa en el SQL es el nombre del procedimiento
                    sSQL = "Servicio_Grabar";

                    oConexion.SQL = sSQL;

                    //Se pasan los parámetros
                    //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                    oConexion.AgregarParametro("@pr_Nombre", System.Data.SqlDbType.VarChar, 50, sNombre);
                    oConexion.AgregarParametro("@pr_ValorServicio", System.Data.SqlDbType.Int, 4, iValor);
                    oConexion.AgregarParametro("@pr_Activo", System.Data.SqlDbType.Bit, 1, bActivo);
                    oConexion.AgregarParametro("@pr_CodigoTipoServicio", System.Data.SqlDbType.Int, 4, iCodigoTipoServicio);

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

            public bool Actualizar()
            {
                if (Validar())
                {
                    if (iCodigo <= 0)
                    {
                        sError = "No definió el código para actualizar la información";
                        return false;
                    }

                    clsConexion oConexion = new clsConexion();
                    //Lo unico que se pasa en el SQL es el nombre del procedimiento
                    sSQL = "Servicio_Actualizar";

                    oConexion.SQL = sSQL;

                    //Se pasan los parámetros
                    //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                    oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, iCodigo);
                    oConexion.AgregarParametro("@pr_Nombre", System.Data.SqlDbType.VarChar, 50, sNombre);
                    oConexion.AgregarParametro("@pr_ValorServicio", System.Data.SqlDbType.Int, 4, iValor);
                    oConexion.AgregarParametro("@pr_Activo", System.Data.SqlDbType.Bit, 1, bActivo);
                    oConexion.AgregarParametro("@pr_CodigoTipoServicio", System.Data.SqlDbType.Int, 4, iCodigoTipoServicio);

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

            public bool Borrar()
            {
                if (iCodigo <= 0)
                {
                    sError = "No definió el código para borrar la información";
                    return false;
                }

                clsConexion oConexion = new clsConexion();
                //Lo unico que se pasa en el SQL es el nombre del procedimiento
                sSQL = "Servicio_Borrar";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, iCodigo);

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

            public bool BorrarLogico()
            {
                if (iCodigo <= 0)
                {
                    sError = "No definió el código para borrar la información";
                    return false;
                }

                clsConexion oConexion = new clsConexion();
                //Lo unico que se pasa en el SQL es el nombre del procedimiento
                sSQL = "Servicio_BorrarLogico";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, iCodigo);

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

            public bool Consultar()
            {
                if (iCodigo <= 0)
                {
                    sError = "No definió el código para consultar la información";
                    return false;
                }

                clsConexion oConexion = new clsConexion();
                //Lo unico que se pasa en el SQL es el nombre del procedimiento
                sSQL = "Servicio_Consultar";

                oConexion.SQL = sSQL;

                //Se pasan los parámetros
                //El tamaño de los parámetros "sólo aplica" para los tipo varchar
                oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, iCodigo);

                if (oConexion.Consultar())
                {
                    if (oConexion.Reader.HasRows)
                    {
                        oConexion.Reader.Read();
                        sNombre = oConexion.Reader.GetString(0);
                        iValor = oConexion.Reader.GetInt32(1);
                        bActivo = oConexion.Reader.GetBoolean(2);
                        iCodigoTipoServicio = oConexion.Reader.GetInt32(3);

                        oConexion.CerrarConexion();
                        oConexion = null;
                        return true;
                    }
                    else
                    {
                        sError = "No hay datos de servicio para el código: " + iCodigo.ToString();
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return false;
                    }
                }
                else
                {
                    sError = oConexion.Error;
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }

            public bool LlenarGrid()
            {
                if (ogrdServicio == null)
                {
                    sError = "No definió el grid del servicio";
                    return false;
                }
                sSQL = "Execute Servicio_Grid";

                clsGrid oGrid = new clsGrid();
                //Se pasa el grid vacío
                oGrid.gridGenerico = ogrdServicio;
                //se pasa el sql
                oGrid.SQL = sSQL;
                if (oGrid.LlenarGridWeb())
                {
                    ogrdServicio = oGrid.gridGenerico;
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

            public bool LlenarComboServicio()
            {
                if (ocboServicio == null)
                {
                    sError = "No definió el combo del Servicio";
                    return false;
                }
                sSQL = "Execute Servicio_S_Combo " + iCodigoTipoServicio;

                clsCombos oCombo = new clsCombos();
                oCombo.SQL = sSQL;
                oCombo.ColumnaTexto = "Nombre";//Nombre de la columna que quiero mostrar en el combo
                oCombo.ColumnaValor = "Codigo";//Nombre de la columna que quiero almacenar
                oCombo.cboGenericoWeb = ocboServicio;

                if (oCombo.LlenarComboWeb())
                {
                    ocboServicio = oCombo.cboGenericoWeb;
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