using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;

namespace libDesarrollo_8_10.Reglas_Negocio
{
    public class cls_RN_Minutos_Celular
    {
        #region "Atributos"
            private string sNumeroCelular;
            private Int32 iValorRecarga;
            private Int32 iMinutosAdicionales;
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

            public string Error
            {
                get { return sError; }
            }
        #endregion

        #region "Metodos"
            public bool CalcularMinutosAdicionales()
            {
                Int32 iRpta;
                iRpta = CalcularPicoYPlaca();

                if (iRpta == 255)
                {
                    //Hubo error en la consulta del pico y placa
                    return false;
                }
                else
                {
                    if (ConsultarMinutosAdicionales())
                    {
                        iMinutosAdicionales = iMinutosAdicionales * iRpta;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            private byte CalcularPicoYPlaca()
            {
                try
                {
                    CultureInfo ci = new CultureInfo("Es-Es");

                    string sDiaSemana = ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToUpper();
                    string sUltimoDigito1 = "", sUltimoDigito2 = "", sUltimoDigito;

                    //Calcula el último digito del celular
                    sUltimoDigito = sNumeroCelular.Substring(sNumeroCelular.Length - 1, 1);

                    XElement oDocumentoXML =
                     XElement.Load(@"C:\Users\docenteitm\Documents\Desarrollo 8-10\libDesarrollo_8_10\libDesarrollo_8_10\XML\RN_MinutosAdicionales.xml");

                    XElement NodosMinutos = oDocumentoXML.Element("Pico_y_Placa");

                    foreach (XElement oDia in NodosMinutos.Descendants())
                    {
                        if (oDia.Value.ToUpper() == sDiaSemana)
                        {
                            sUltimoDigito1 = oDia.Attribute("Digito1").Value;
                            sUltimoDigito2 = oDia.Attribute("Digito2").Value;
                            break;
                        }
                    }
                    if (sUltimoDigito == sUltimoDigito1 || sUltimoDigito == sUltimoDigito2)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    sError = ex.Message;
                    return 255;
                }
            }

            private bool ConsultarMinutosAdicionales()
            {
                try{
                    XElement oDocumentoXML =
                        XElement.Load(@"C:\Users\docenteitm\Documents\Desarrollo 8-10\libDesarrollo_8_10\libDesarrollo_8_10\XML\RN_MinutosAdicionales.xml");
                    //Leemos la marca
                    
                    //Para consultar información se utilizan el xpath y xquery
                    //El objeto Ienumerable, permite armar listas de nodos (Arreglo)
                    IEnumerable<XElement> NodosMinutos =
                                from Minutos in oDocumentoXML.Descendants("Valor_Recarga")
                                where (Int64)Minutos.Element("Valor_Minimo") <= iValorRecarga &&
                                        (Int64)Minutos.Element("Valor_Maximo") >= iValorRecarga
                                select Minutos;
                    //En el objeto NodosDescuento, queda el nodo que cumple las condiciones
                    //Para consultar el porcentaje de descuento
                    //Necesitamos leer el atributo del porcentaje
                    foreach (XElement oNodoMinutos in NodosMinutos)
                    {
                        iMinutosAdicionales = Convert.ToInt32(oNodoMinutos.Attribute("Minutos_Adicionales").Value);
                    }
                    return true;
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
