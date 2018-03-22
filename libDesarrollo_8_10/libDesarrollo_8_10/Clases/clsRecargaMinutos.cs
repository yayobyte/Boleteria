using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libDesarrollo_8_10.Reglas_Negocio;

namespace libDesarrollo_8_10.Clases
{
    public class clsRecargaMinutos
    {
        #region "Constructor"
            public clsRecargaMinutos()
            {
                iValorMinuto = 200;
                iValorRecarga = 0;
                sNumeroCelular = "";
            }
        #endregion

        #region "Atributos"
            private string sNumeroCelular;
            private Int32 iValorRecarga;
            private Int32 iMinutosAdicionales;
            private Int32 iValorMinuto;
            private Int32 iMinutosRecargados;
            private Int32 iTotalMinutos;
            private string sError;
        #endregion

        #region "Propiedades"
            public string NumeroCelular
            {
                get { return sNumeroCelular; }
                set { sNumeroCelular = value; }
            }

            public Int32 ValorRecarga
            {
                get { return iValorRecarga; }
                set { iValorRecarga = value; }
            }

            public Int32 MinutosAdicionales
            {
                get { return iMinutosAdicionales; }
            }

            public Int32 MinutosRecargados
            {
                get { return iMinutosRecargados; }
            }

            public Int32 TotalMinutos
            {
                get { return iTotalMinutos; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            public bool Recargar()
            {
                if (CalcularMinutosAdicionales())
                {
                    iMinutosRecargados = iValorRecarga / iValorMinuto;
                    iTotalMinutos = iMinutosRecargados + iMinutosAdicionales;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool CalcularMinutosAdicionales()
            {
                cls_RN_Minutos_Celular oMinutos = new cls_RN_Minutos_Celular();

                oMinutos.ValorRecarga = iValorRecarga;
                oMinutos.NumeroCelular = sNumeroCelular;

                if (oMinutos.CalcularMinutosAdicionales())
                {
                    iMinutosAdicionales = oMinutos.MinutosAdicionales;
                    oMinutos = null;
                    return true;
                }
                else
                {
                    sError = oMinutos.Error;
                    oMinutos = null;
                    return false;
                }
            }
        #endregion
    }
}
