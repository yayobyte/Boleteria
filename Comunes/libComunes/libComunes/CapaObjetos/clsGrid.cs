using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using libComunes.CapaDatos;

namespace libComunes.CapaObjetos
{
    public class clsGrid
    {
        #region "Constructor"
            public clsGrid()
            {
                strNombreTabla = "Tabla_Grid";
            }
        #endregion

        #region "Atributos"
        private string strNombreTabla;
            private string strSQL;
            private string strError;
            private GridView grdGenerico;
        #endregion

        #region "Propiedades"
            public GridView gridGenerico
            {
                get
                {
                    return grdGenerico;
                }
                set
                {
                    grdGenerico = value;
                }
            }

            public string NombreTabla
            {
                get
                {
                    return strNombreTabla;
                }
                set
                {
                    strNombreTabla = value;
                }
            }

            public string SQL
            {
                get
                {
                    return strSQL;
                }
                set
                {
                    strSQL = value;
                }
            }

            public string Error
            {
                get
                {
                    return strError;
                }
            }
        #endregion

        #region "Metodos Publicos"clsConexion
            public bool LlenarGridWeb()
            {
                if (grdGenerico == null)
                {
                    strError = "No ha definido el grid que se va a llenar";
                    return false;
                }
                if (strSQL == "")
                {
                    strError = "Debe definir una instrucción SQL";
                    return false;
                }

                clsConexion objConexionBd = new clsConexion();
                if (string.IsNullOrEmpty( strNombreTabla ))
                {
                    strNombreTabla = "Tabla";
                }
                objConexionBd.NombreTabla = strNombreTabla;
                objConexionBd.SQL = strSQL;

                if (objConexionBd.LlenarDataSet())
                {
                    grdGenerico.DataSource = objConexionBd.DATASET.Tables[strNombreTabla];
                    grdGenerico.DataBind();
                    objConexionBd.CerrarConexion();
                    objConexionBd = null;
                    return true;
                }
                else
                {
                    strError = objConexionBd.Error;
                    objConexionBd.CerrarConexion();
                    objConexionBd = null;
                    return false;
                }
            }

        #endregion
    }
}
