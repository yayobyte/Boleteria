using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libDesarrollo_8_10.BaseDatos
{
    public class clsOperador
    {
        #region "Constructor"
            public clsOperador()
            {
                sNombre = "";
                iCodigo = 0;
            }
        #endregion

        #region "Atributos"
        private Int32 iCodigo;
            private string sNombre;
            private bool bActivo;
            private GridView ogrdOperador;
            private string sSQL;
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

            public GridView grdOperador
            {
                get { return ogrdOperador; }
                set { ogrdOperador = value; }
            }

            public bool Activo
            {
                get { return bActivo; }
                set { bActivo = value; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            public bool Consultar() {

                if (iCodigo <= 0)
                {
                    sError = "NO DEFINIÓ EL CODIGO DEL OPERADOR";
                    return false;
                }
                sSQL = "SELECT Nombre, Activo " +
                        "FROM  tblOperador " +
                        "WHERE Codigo = " + iCodigo;
                clsConexion oConexion = new clsConexion();
                oConexion.SQL = sSQL;

                if (oConexion.Consultar())
                {
                    if (oConexion.Reader.HasRows)
                    {
                        oConexion.Reader.Read();
                        sNombre = oConexion.Reader.GetString(0);
                        bActivo = oConexion.Reader.GetBoolean(1);
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return true;
                    }
                    else
                    {
                        sError = "No hay datos de operador para el codigo" + iCodigo;
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

            public bool Grabar()
            {
                Int16 iActivo;
                if (bActivo) iActivo = 1;
                else iActivo = 0;

                if (Validar())
                {
                    sSQL = "INSERT INTO tblOperador(Nombre, Activo) " +
                            "VALUES('" + sNombre + "', " + iActivo + ")";

                    clsConexion oConexion = new clsConexion();

                    oConexion.SQL = sSQL;
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
                Int16 iActivo;
                if (bActivo) iActivo = 1;
                else iActivo = 0;

                if (Validar())
                {
                    if (iCodigo <= 0)
                    {
                        sError = "No definió el código del operador";
                        return false;
                    }

                    sSQL = "UPDATE tblOperador " +
                           "SET Nombre='" + sNombre + "', " +
                                "Activo=" + iActivo + " " +
                            "WHERE Codigo = " + iCodigo;

                    clsConexion oConexion = new clsConexion();

                    oConexion.SQL = sSQL;
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
                    sError = "No definió el código del operador";
                    return false;
                }
                sSQL = "DELETE tblOperador " +
                        "WHERE Codigo = " + iCodigo;

                clsConexion oConexion = new clsConexion();

                oConexion.SQL = sSQL;
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

            private bool Validar()
            {
                if (string.IsNullOrEmpty(sNombre))
                {
                    sError = "No definió el nombre";
                    return false;
                }
                return true;
            }

            public bool LlenarGrid()
            {
                if (ogrdOperador == null)
                {
                    sError = "No definió el grid del operador";
                    return false;
                }
                sSQL = "Execute Operador_S_Grid";

                clsGrid oGrid = new clsGrid();
                //Se pasa el grid vacío
                oGrid.gridGenerico = ogrdOperador;
                //se pasa el sql
                oGrid.SQL = sSQL;
                if (oGrid.LlenarGridWeb())
                {
                    ogrdOperador = oGrid.gridGenerico;
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
