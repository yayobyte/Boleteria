using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;

namespace libClasesVentaMinutos.Clases
{
    public class clsFactura
    {
        #region "Atributos"
            private Int32 iNumeroFactura;
            private string sCedulaCliente;
            private string sCedulaEmpleado;
            private string sDetalleServicio;
            private Int32 iCodigoServicio;
            private Int32 iValorServicio;
            private Int32 iCantidadServicio;
            private Int32 iOperador;
            private string sSQL;
            private string sError;
        #endregion

        #region "Propiedades"
            public Int32 NumeroFactura
            {
                get { return iNumeroFactura; }
                set { iNumeroFactura = value; }
            }

            public string CedulaCliente
            {
                get { return sCedulaCliente; }
                set { sCedulaCliente = value; }
            }

            public string CedulaEmpleado
            {
                get { return sCedulaEmpleado; }
                set { sCedulaEmpleado = value; }
            }

            public Int32 CodigoServicio
            {
                get { return iCodigoServicio; }
                set { iCodigoServicio = value; }
            }

            public Int32 Operador
            {
                get { return iOperador; }
                set { iOperador = value; }
            }

            public Int32 ValorServicio
            {
                get { return iValorServicio; }
                set { iValorServicio = value; }
            }

            public Int32 CantidadServicio
            {
                get { return iCantidadServicio; }
                set { iCantidadServicio = value; }
            }

            public string DetalleServicio
            {
                get { return sDetalleServicio; }
                set { sDetalleServicio = value; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            private bool ConsultarNumeroFactura()
            {
                return false;
            }

            public bool GrabarFactura()
            {
                return false;
            }

            public bool GrabarDetalle()
            {
                return false;
            }
        #endregion
    }
}
