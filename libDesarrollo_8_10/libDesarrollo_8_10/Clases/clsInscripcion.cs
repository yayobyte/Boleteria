using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTor
{
    public class clsInscripcion
    {
        //El constructor es el método que se ejecuta cuando se crea
        //una isntancia de la clase. Se puede sobreescribir para que
        //realice unas tareas específicas
        //Usualmente los constructores se escriben para inicialzar las
        //propiedades/atributos de la clase
        //se crean con public NombreClase()
        #region "Constructor"
        public clsInscripcion()
        {
            sError = "";
            iValorEquipo = 300000;
        }
        #endregion

        #region ATRIBUTOS
        private Int32 iValorEquipo;
        private Int32 iNroEntrenadores;
        private String sCategoria;
        private Int32 iValorEntrenadores;
        private Int32 iNroPartidos;
        private Int32 iTotalInscripcion;
        private Int32 iValorCategoria;
        private String sError;
        #endregion

        #region PROPIEDADES
        public Int32 NroEntrenadores
        {
            get { return iNroEntrenadores; }
            set { iNroEntrenadores = value; }
        }

        public String Categoria
        {
            get { return sCategoria; }
            set { sCategoria = value; }
        }

        public Int32 NroPartidos
        {
            get { return iNroPartidos; }
            set { iNroPartidos = value; }
        }

        public Int32 TotalInscripcion
        {
            get { return iTotalInscripcion; }

        }


        public string Error
        {
            get { return sError; }
        }
        #endregion

        #region METODOS

        private bool Calcularcategoria()
        {
            if (sCategoria.ToUpper() == "RECREATIVA")
            {
                iValorCategoria = 100000;
                return true;
            }
            else
            {
                if (sCategoria.ToUpper() == "COMPETITIVA")
                {
                    if (iNroPartidos < 10)
                    {
                        iValorCategoria = 25000 * 10;
                        return true;
                    }
                    else
                    {
                        iValorCategoria = 25000 * NroPartidos;
                        return true;
                    }

                }
                else
                {
                    sError = "Debe digitar Recreativa o Competitiva";
                    return false;
                }
            }

        }

        private bool CalcularEntrenador()
        {
            if (iNroEntrenadores <= 2)
            {
                iValorEntrenadores = 100000;

                return true;
            }
            else
            {
                iValorEntrenadores = 125000;
                return true;
            }
        }

        public bool CalcularInscripcion()
        {
            if (CalcularEntrenador())
            {
                if (Calcularcategoria())
                {
                    iTotalInscripcion = iValorEntrenadores + iValorCategoria + iValorEquipo;
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


