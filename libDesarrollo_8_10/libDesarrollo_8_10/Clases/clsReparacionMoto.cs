using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDesarrollo_8_10.Clases
{
   public class clsReparacionMoto
   {
       // comentario en una linea

       /*
        * comentario de varias lineas 
        * 
        * */

      #region Atributos
           private Int32 iValorRepuestos;
           private Int32 iValorManoObra;
           private Int32 iSubtotal;
           private Int32 iValorIva;
           private Int32 iValorTotalPagar;
           private double dPorcentajeDescuento;
           private Int32 iValorDescuento;
           private Int32 iValorAntesIva;
           private string sError = string.Empty;
      #endregion

      #region Propiedades

       public Int32 ValorRepuestos
       {
           get { return iValorRepuestos; }
           set {iValorRepuestos =value;}
       }

        public Int32 ValorManoObra
       {
           get { return iValorManoObra; }
           set {iValorManoObra =value;}
       }

        public Int32 ValorIva
       {
           get {return iValorIva;}
           
       }

        public Int32 ValorTotalPagar
       {
           get {return iValorTotalPagar;}
          
       }


       public double PorcentajeDescuento
       {
           get {return dPorcentajeDescuento;}
           set {dPorcentajeDescuento =value;}
       }

       public Int32 ValorDescuento
       {
           get {return iValorDescuento;}
          
       }

       public Int32 ValorAntesIva
       {
           get {return iValorAntesIva;}
      
       }

       public string Error
       {
           get {return sError;}
          
       }

      #endregion

       #region Métodos
           private bool CalcularIva()
           {
               iValorAntesIva = Convert.ToInt32(iValorTotalPagar / 1.16);
               iValorIva = iValorTotalPagar - iValorAntesIva;
               return true;
           }

           private bool CalcularDescuento()
           {
               iSubtotal = iValorManoObra + iValorRepuestos;
               iValorDescuento = Convert.ToInt32(iSubtotal * dPorcentajeDescuento);
               iValorTotalPagar = iSubtotal - iValorDescuento;
               return true;
           }

           public bool CalcularTotal()
           {
               if (CalcularDescuento())
               {
                   if (CalcularIva())
                   {
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }
               else
               {
                   return false;
               }
           }
       #endregion




   }
}
