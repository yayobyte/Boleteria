using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;

namespace libDesarrollo_8_10.Reglas_Negocio
{
    public class cls_RN_SobrecargoVuelos
    {
        private Int32 iDistanciaViaje;
        private string sError;
        private double dDescuento;
        private string sPais;

        public double CalcularSobrecargo()
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
                XElement oDocumentoXML = XElement.Load(@"C:\Users\docenteitm\Documents\Desarrollo 8-10 - compartida\libDesarrollo_8_10\libDesarrollo_8_10\XML\RN_XMLViajes.xml");
                //Para consultar información se utilizan el xpath y xquery
                //El objeto Ienumerable, permite armar listas de nodos (Arreglo)
                IEnumerable<XElement> NodosVuelos =
                            from Vuelos in oDocumentoXML.Descendants("VUELO")
                            where (Int64)Vuelos.Element("VENTA_MINIMA") <= iDistanciaViaje &&
                                    (Int64)Vuelos.Element("VENTA_MAXIMA") >= iDistanciaViaje
                            select Vuelos;
                //En el objeto NodosDescuento, queda el nodo que cumple las condiciones
                //Para consultar el porcentaje de descuento
                //Necesitamos leer el atributo del porcentaje
                foreach (XElement oVuelo in NodosVuelos)
                {
                    return Convert.ToDouble(oVuelo.Attribute("SOBRECARGO").Value) / 100.0;
                }
                return -1.0;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return -999.9;
            }
        }

        public bool ConsultarDescuentos()
        {
            try
            {
                CultureInfo ci = new CultureInfo("Es-Es");

                string sDiaSemana = ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToUpper();
                Int16 iDescuentoPais = 0;
                
                XElement oDocumentoXML = XElement.Load(@"C:\Users\docenteitm\Documents\Desarrollo 8-10 - compartida\libDesarrollo_8_10\libDesarrollo_8_10\XML\RN_Aerolinea.xml");

                XElement oPaisDescuento = oDocumentoXML.Element("DESTINO_DESCUENTO");

                foreach(XElement oPais in oPaisDescuento.Descendants())
                {
                    if (oPais.Value.ToUpper() == sPais.ToUpper())
                    {
                        iDescuentoPais = 1;
                    }
                }

                XElement oDiasSemana = oDocumentoXML.Element("DESCUENTO");
                foreach (XElement oDia in oDiasSemana.Descendants())
                {
                    if (oDia.Value.ToUpper() == sDiaSemana)
                    {
                        dDescuento = iDescuentoPais * 
                            Convert.ToDouble(oDia.Attribute("Porcentaje").Value) / 100.0;
                        return true;
                    }
                }
                dDescuento = 0;
                oPaisDescuento = null;
                oDocumentoXML = null;
                oDiasSemana = null;
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
        }
    }
}
