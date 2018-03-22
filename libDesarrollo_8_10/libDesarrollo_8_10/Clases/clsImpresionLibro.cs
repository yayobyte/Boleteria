using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDesarrollo_8_10.Clases
{
  public  class clsImpresionLibro
    {
        //El constructor es el método que se ejecuta cuando se crea
        //una isntancia de la clase. Se puede sobreescribir para que
        //realice unas tareas específicas
        //Usualmente los constructores se escriben para inicialzar las
        //propiedades/atributos de la clase
        //se crean con public NombreClase()
        #region "Constructor"
            public clsImpresionLibro()
            {
                sError = "";
                iCostoImagen = 500;
            }
        #endregion

        #region ATRIBUTOS
        private string sTipoPasta;
            private string sTipoImpresion;
            private Int32 iCantidadHojas;
            private Int32 iNumeroImagen;
            private Int32 iValorIVA;
            private Int32 iCostoTipoPasta;
            private Int32 iCostoTipoImpresion;
            private Int32 iCostoImagen;
            private Int32 iValorPagar;
            private String sError;
        #endregion

        #region PROPIEDADES
            public string TipoPasta 
            {
                get {return sTipoPasta;}
                set { sTipoPasta = value; }
            }

            public string TipoImpresion
            {
                get { return sTipoImpresion; }
                set { sTipoImpresion = value; }
            }

            public int CantidadHojas
            {
                get { return iCantidadHojas; }
                set { iCantidadHojas = value; }
            }

            public int NumeroImagen
            {
                get { return iNumeroImagen; }
                set { iNumeroImagen = value; }
            }

            public int ValorIVA
            {
                get { return iValorIVA; }
            }

            public int ValorPagar
            {
                get { return iValorPagar; }
            }

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region METODOS
            private void CalcularIVA()
            {
                iValorIVA = iValorPagar - Convert.ToInt32(iValorPagar / 1.16);
            }

            private void CalcularCostoXTipo()
            {
                //Calcula el costo por tipo de impresión
                if (sTipoImpresion.ToUpper() == "COLOR")
                {
                    iCostoTipoImpresion = 50;
                }
                else
                {
                    if (sTipoImpresion.ToUpper() == "BLANCO Y NEGRO")
                    {
                        iCostoTipoImpresion = 15;
                    }
                    else
                    {
                        sError = "El tipo de impresión debe ser a color o blanco y negro";
                    }
                }

                switch (sTipoPasta.ToUpper())
                {
                    case "SIMPLE":
                        iCostoTipoPasta = 1500;
                        break;
                    case "PASTA DURA":
                        iCostoTipoPasta = 7000;
                        break;
                    case "LUJO":
                        iCostoTipoPasta = 25000;
                        break;
                    default:
                        sError = "El tipo de pasta sólo puede ser simple, pasta dura o lujo";
                        break;
                }
            }

            public void CalcularTotal()
            {
                CalcularCostoXTipo();
                iValorPagar = iCantidadHojas * iCostoTipoImpresion +
                              iNumeroImagen * iCostoImagen +
                              iCostoTipoPasta;
                CalcularIVA();
            }
        #endregion

    }
}
