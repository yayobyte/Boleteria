using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;

namespace libDesarrollo_8_10.BaseDatos
{
    public class clsCliente
    {
        #region "Constructor"
            public clsCliente()
            {
                sNombre = "";
                sPrimerApellido = "";
                sSegundoApellido = "";
                sTelefono = "";
                sDocumento = "";
                sEmail = "";
            }
        #endregion

        #region "Atributos"
        private string sDocumento;
            private string sNombre;
            private string sPrimerApellido;
            private string sSegundoApellido;
            private string sTelefono;
            private string sEmail;
            private string sSQL;
            private string sError;
        #endregion

        #region "Propiedades"
            public string Documento
            {
                get { return sDocumento; }
                set { sDocumento = value; }
            }

            public string Nombre
            {
                get { return sNombre; }
                set { sNombre = value; }
            }

            public string PrimerApellido
            {
                get { return sPrimerApellido; }
                set { sPrimerApellido = value; }
            }

            public string SegundoApellido
            {
                get { return sSegundoApellido; }
                set { sSegundoApellido = value; }
            }

            public string Telefono
            {
                get { return sTelefono; }
                set { sTelefono = value; }
            }

            public string Email
            {
                get { return sEmail; }
                set { sEmail = value; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            public bool Grabar()
            {
                if (Validar())
                {
                    sSQL = "INSERT INTO tblCliente(Documento, Nombre, PrimerApellido, SegundoApellido, Telefono,Email) " +
                            "VALUES ('" + sDocumento + "','" + sNombre + "','" + sPrimerApellido + "','" + sSegundoApellido + "','" + sTelefono + "','" + sEmail + "')";

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
                if (Validar())
                {
                    sSQL = "UPDATE tblCliente " +
                            "SET Nombre='" + sNombre + "', " +
                                 "PrimerApellido='" + sPrimerApellido + "', " +
                                 "SegundoApellido='" + sSegundoApellido + "', " +
                                 "Telefono='" + sTelefono + "', " +
                                 "Email='" + sEmail + "' " +
                            "WHERE Documento='" + sDocumento + "'";

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

            public bool Consultar()
            {
                if (string.IsNullOrEmpty(sDocumento))
                {
                    sError = "No definió el documento del cliente";
                    return false;
                }

                sSQL = "SELECT Nombre, PrimerApellido, SegundoApellido, Telefono, Email " +
                        "FROM tblCliente " +
                        "WHERE Documento='" + sDocumento + "'";

                clsConexion oConexion = new clsConexion();
                oConexion.SQL = sSQL;

                if (oConexion.Consultar())
                {
                    if (oConexion.Reader.HasRows)
                    {
                        oConexion.Reader.Read();

                        sNombre = oConexion.Reader.GetString(0);
                        sPrimerApellido = oConexion.Reader.GetString(1);
                        sSegundoApellido = oConexion.Reader.GetString(2);
                        sTelefono = oConexion.Reader.GetString(3);
                        sEmail = oConexion.Reader.GetString(4);

                        oConexion.CerrarConexion();
                        oConexion = null;
                        return true;
                    }
                    else
                    {
                        sError = "No existe el cliente con el documento " + sDocumento;
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

            public bool Validar()
            {
                if (string.IsNullOrEmpty(sDocumento))
                {
                    sError = "No definió el documento del cliente";
                    return false;
                }
                if (string.IsNullOrEmpty(sNombre))
                {
                    sError = "No definió el nombre del cliente";
                    return false;
                }
                if (string.IsNullOrEmpty(sPrimerApellido))
                {
                    sError = "No definió el primer apellido del cliente";
                    return false;
                }
                if (string.IsNullOrEmpty(sSegundoApellido))
                {
                    sError = "No definió el segundo apellido del cliente";
                    return false;
                }
                if (string.IsNullOrEmpty(sTelefono))
                {
                    sError = "No definió el teléfono del cliente";
                    return false;
                }
                if (string.IsNullOrEmpty(sEmail))
                {
                    sError = "No definió el email del cliente";
                    return false;
                }
                return true;
            }
        #endregion
    }
}
