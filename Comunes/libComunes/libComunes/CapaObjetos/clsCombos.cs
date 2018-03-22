using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using libComunes.CapaDatos;

namespace libComunes.CapaObjetos
{
    public class clsCombos
    {
        #region "Atributos"
            private string strNombreTabla;
            private string strSQL;
            private string strError;
            private string strColumnaTexto;
            private string strColumnaValor;
            //private ComboBox cboGenerico;
            private DropDownList objcboGenericoWeb;
        #endregion

        #region "Propiedades"
            public DropDownList cboGenericoWeb
            {
                get
                {
                    return objcboGenericoWeb;
                }
                set
                {
                    objcboGenericoWeb = value;
                }
            }
        /*
            public ComboBox comboGenerico
            {
                get
                {
                    return cboGenerico;
                }
                set
                {
                    cboGenerico = value;
                }
            }
        */
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

            public string ColumnaTexto
            {
                get
                {
                    return strColumnaTexto;
                }
                set
                {
                    strColumnaTexto = value;
                }
            }

            public string ColumnaValor
            {
                get
                {
                    return strColumnaValor;
                }
                set
                {
                    strColumnaValor = value;
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

        #region "Metodos"
            public bool LlenarComboWeb()
            {
                if (Validar())
                {
                    if (objcboGenericoWeb == null)
                    {
                        strError = "No definió el combo";
                        return false;
                    }
                    clsConexion objConexionBD = new clsConexion();

                    objConexionBD.NombreTabla = strNombreTabla;
                    objConexionBD.SQL = strSQL;
                    if (objConexionBD.LlenarDataSet())
                    {
                        objcboGenericoWeb.DataSource = objConexionBD.DATASET.Tables[strNombreTabla];
                        objcboGenericoWeb.DataTextField = strColumnaTexto;
                        objcboGenericoWeb.DataValueField = strColumnaValor;
                        objcboGenericoWeb.DataBind();
                        objConexionBD.CerrarConexion();
                        objConexionBD = null;
                        return true;
                    }
                    else
                    {
                        strError = objConexionBD.Error;

                        objConexionBD.CerrarConexion();
                        objConexionBD = null;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        /*
            public bool LlenarCombo()
            {
                if (Validar())
                {

                    clsConexion objConexionBD = new clsConexion();

                    objConexionBD.NombreTabla = strNombreTabla;
                    objConexionBD.SQL = strSQL;
                    if (objConexionBD.LlenarDataSet())
                    {
                        cboGenerico.DataSource = objConexionBD.DATASET.Tables[strNombreTabla];
                        cboGenerico.DisplayMember = strColumnaTexto;
                        cboGenerico.ValueMember  = strColumnaValor;
                    
                        objConexionBD.CerrarConexion();
                        objConexionBD = null;
                        return true;
                    }
                    else
                    {
                        strError = objConexionBD.Error;

                        objConexionBD.CerrarConexion();
                        objConexionBD = null;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
         * */
        #endregion

        #region "Metodos Privados"
            private bool Validar()
            {
                if (strSQL == "")
                {
                    strError = "No definio la instruccion SQL";
                    return false;
                }
                if (strColumnaTexto == "")
                {
                    strError = "No definio el nombre de la columna para el texto del combobox";
                    return false;
                }

                if (strColumnaValor == "")
                {
                    strError = "No definio el nombre de la columna para el valor del combobox";
                    return false;
                }
                if (string.IsNullOrEmpty( strNombreTabla))
                {
                    strNombreTabla = "Tabla";
                }
                return true;
            }
        #endregion
    }
}
