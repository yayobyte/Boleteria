using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace libDesarrollo_8_10.Reglas_Negocio
{
    public class clsRN_DescuentoVenta
    {
        #region "Constructor"
        public clsRN_DescuentoVenta()
        {
            iValorCompra = 0;
        }
        #endregion

        #region "Atributos
        private string sMarca;
        private Int32 iValorCompra;
        private double dPorcentajeDescuento;
        private string sError;
        #endregion

        #region "Propiedades"
        public string Marca
        {
            get { return sMarca; }
            set { sMarca = value; }
        }

        public Int32 ValorCompra
        {
            get { return iValorCompra; }
            set { iValorCompra = value; }
        }

        public double PorcentajeDescuento
        {
            get { return dPorcentajeDescuento; }
        }

        public string Error
        {
            get { return sError; }
        }
        #endregion

        #region "Metodos"
        private bool Validar()
        {
            if (string.IsNullOrEmpty(sMarca))
            {
                sError = "No definió la marca del producto";
                return false;
            }
            if (iValorCompra <= 0)
            {
                sError = "No definió el valor de la compra";
                return false;
            }
            return true;
        }

        public bool CalcularPorcentajeDescuento()
        {
            try
            {
                //Calcula el porcentaje de descuento leyendo la información
                //del archivo xml
                //El objeto xElement es la clase principal del xml.linq
                //Con este objeto podemos cargar el archivo xml
                //El xElement es una clase estática, es decir, que no 
                //requiere ser instanciada para ser utilizada.
                //En el load hay que pasar la ruta completa del archivo xml
                XElement oDocumentoXML = XElement.Load(@"C:\Users\SantiagoE\Desktop\Desarrollo\Desarrollo de Software_2015\libDesarrollo_8_10\libDesarrollo_8_10\XML\RN_Descuento_Tienda_Deportiva.xml");
                //Leemos la marca
                XElement oNodoMarca = oDocumentoXML.Element("MARCA_DESCUENTO");

                if (oNodoMarca.Attribute("Marca").Value.ToUpper() == sMarca.ToUpper())
                {
                    //Para consultar información se utilizan el xpath y xquery
                    //El objeto Ienumerable, permite armar listas de nodos (Arreglo)
                    IEnumerable<XElement> NodosDescuento =
                                from DescuentosZZZZZ in oDocumentoXML.Descendants("DESCUENTO")
                                where (Int64)DescuentosZZZZZ.Element("VENTA_MINIMA") <= iValorCompra &&
                                        (Int64)DescuentosZZZZZ.Element("VENTA_MAXIMA") >= iValorCompra
                                select DescuentosZZZZZ;
                    //En el objeto NodosDescuento, queda el nodo que cumple las condiciones
                    //Para consultar el porcentaje de descuento
                    //Necesitamos leer el atributo del porcentaje
                    foreach (XElement oDescuentoXX in NodosDescuento)
                    {
                        dPorcentajeDescuento = Convert.ToDouble(oDescuentoXX.Attribute("Porcentaje").Value) / 100.0;
                    }
                    return true;
                }
                else
                {
                    dPorcentajeDescuento = 0.0;
                    return true;
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
