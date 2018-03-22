using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libDesarrollo_8_10.Reglas_Negocio;

namespace libDesarrollo_8_10.Clases
{
    public class clsTiendaDeportiva
    {

        #region Constructor
        public clsTiendaDeportiva()
        {
            sError = "";
            iValorUnitario = 0;
            iCantidad = 0;
        }
        #endregion

        #region Atributos
        private string sMarca;
        private Int32 iCantidad;
        private Int32 iValorUnitario;
        private Int32 iValorPagar;
        private Int32 iValorDescuento;
        private double dPorcentajeDescuento;
        private Int32 ivalorCompra;
        private Int32 iValorAntesIva;
        private Int32 iValorIva;
        private string sError;
        #endregion

        #region Propiedades
        public string Marca
        {
            get { return sMarca; }
            set { sMarca = value; }
        }

        public Int32 Cantidad
        {
            get { return iCantidad; }
            set { iCantidad = value; }
        }
        public Int32 ValorUnitario
        {
            get { return iValorUnitario; }
            set { iValorUnitario = value; }
        }
        public Int32 ValorPagar
        {
            get { return iValorPagar; }
        }

        public Int32 ValorDescuento
        {
            get { return iValorDescuento; }

        }

        public Int32 valorCompra
        {
            get { return ivalorCompra; }

        }

        public Int32 ValorAntesIva
        {
            get { return iValorAntesIva; }

        }

        public Int32 ValorIva
        {
            get { return iValorIva; }

        }

        public string Error
        {
            get { return sError; }

        }
        #endregion


        #region Metodos
        private bool Validar()
        {
            if (iValorUnitario <= 0)
            {
                sError = "El valor unitario debe ser mayor que 0";
                return false;
            }
            if (iCantidad <= 0)
            {
                sError = "La cantidad debe ser mayor que 0";
                return false;
            }
            if (string.IsNullOrEmpty(sMarca))
            {
                sError = "Debe definir la marca";
                return false;
            }
            return true;
        }

        public bool CalcularValorPagar()
        {
            if (Validar())
            {
                ivalorCompra = iValorUnitario * iCantidad;

                if (CalcularDescuento())
                {
                    iValorPagar = ivalorCompra - iValorDescuento;
                    CalcularIva();
                        return true;
                    
                
                    }
                return false; 

            }
            else {

                return false;
            }
        }

        private bool CalcularDescuento()
        {

            clsRN_DescuentoVenta oDescuento = new clsRN_DescuentoVenta();

            oDescuento.Marca = sMarca;
            oDescuento.ValorCompra = ivalorCompra;
            if(oDescuento.CalcularPorcentajeDescuento())
            {
                dPorcentajeDescuento = oDescuento.PorcentajeDescuento;
                iValorDescuento = (Int32)(ivalorCompra * dPorcentajeDescuento);
                oDescuento = null;
                return true;
            }
            else
            {
                sError = oDescuento.Error;
                oDescuento = null;
                return false;
            }
  
        }

        private void CalcularIva()
        {

            iValorAntesIva =(Int32) (iValorPagar / 1.16);
            iValorIva = iValorPagar - iValorAntesIva;
return;
           
        }
        #endregion


    }

}


