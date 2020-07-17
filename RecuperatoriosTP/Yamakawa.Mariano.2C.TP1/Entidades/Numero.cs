using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Fields

        /// <summary>
        /// Atributo privado con el cual se realizaran las operaciones.
        /// </summary>
        private double _numero;
        #endregion


        #region Properties

        /// <summary>
        /// Propiedad que le asigna un valor al campo _numero de la clase Numero.
        /// </summary>
        private string SetNumero
        {
            set
            {
                _numero = ValidarNumero(value);
            }
        }
        #endregion


        #region Constructores

        /// <summary>
        /// Constructor que inicializa con el valor 0 a un objeto de tipo Numero (Tipo 0)
        /// </summary>
        public Numero() : this(0)
        {   }


        /// <summary>
        /// Constructor que inicializa a un objeto de tipo Numero con el valor pasado por parametro (Tipo 1)
        /// </summary>
        /// <param name="numero"> Valor con el cual se va a inicializar dicho objeto </param>
        public Numero(double numero) : this(numero.ToString())
        {   }


        /// <summary>
        /// Constructor que inicializa a un objeto de tipo Numero con el valor de tipo string pasado por parametro (Tipo 2)
        /// </summary>
        /// <param name="strNumero"> Valor con el cual se va a inicializar dicho objeto </param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion


        #region Methods

        /// <summary>
        /// Convierte un numero de binario a decimal
        /// </summary>
        /// <param name="binario"> Numero binario de tipo string</param>
        /// <returns> Retornar - Retorna el numero convertido a decimal, en caso que sea invalido, devuelve "Valor invalido" </returns>
        public static string BinarioDecimal(string binario)
        {

            int[] cadenaAuxiliar = new int[binario.Length];
            string retornar = " ";
            double numero = 0;
            bool flag = true;
            int i;

            for (i = 0; i < binario.Length; i++)
            {
                cadenaAuxiliar[i] = (int)char.GetNumericValue(binario[i]);
                if (cadenaAuxiliar[i] != 0 && cadenaAuxiliar[i] != 1)
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                for (i = 0; i < binario.Length; i++)
                {
                    numero += (cadenaAuxiliar[i] * Math.Pow(2, binario.Length - i - 1));
                }
                retornar = numero.ToString();
            }

            else
            { retornar = "Valor invalido"; }

            return retornar;
        }


        /// <summary>
        /// Sobrecarga del metodo DecimalBinario que convierte un numero decimal de tipo double a un numero binario
        /// </summary>
        /// <param name="numero"> Numero de tipo double </param>
        /// <returns>Retornar - Retorna el numero convertido a binario </returns>
        static public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }


        /// <summary>
        /// Sobrecarga del metodo DecimalBinario utilizado como validacion de cadenas.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retornar - Retorna un numero decimal de tipo string si el valor es correcto. Caso contrario, retoran "Valor invalido" </returns>
        static public string DecimalBinario(string numero)
        {
            string retornar = "Valor invalido";

            if (double.TryParse(numero.ToString(), out double numAux) && Convert.ToDouble(numero) > 0)
            {
                double numeroDecimal = Convert.ToDouble(numero);
                string auxiliarDecimal = (Math.Truncate(numeroDecimal).ToString());
                int[] cadena = new int[auxiliarDecimal.Length];
                int entero;
                int flag = 1;
                int i;


                for (i = 0; i < auxiliarDecimal.Length; i++)
                {
                    cadena[i] = (int)char.GetNumericValue(auxiliarDecimal[i]);
                    if (cadena[i] < 0 || cadena[i] > 9)
                    {
                        flag = 0;
                        break;
                    }

                }
                if (flag == 1)
                {
                    auxiliarDecimal = "";
                    entero = (int)numeroDecimal;
                    while (entero > 0)
                    {
                        auxiliarDecimal = (entero % 2).ToString() + auxiliarDecimal;
                        entero = entero / 2;
                    }

                    if (numeroDecimal == 0)
                    {
                        auxiliarDecimal = "0";
                    }
                    retornar = auxiliarDecimal;
                }
            }
            return retornar;
        }

        /// <summary>
        /// Valida que el numero de tipo string ingresado se pueda convertir a Double
        /// </summary>
        /// <param name="strNumero"> Numero string </param>
        /// <returns> Retornar - Retorna el numero convertido a tipo double. Caso contrario retorna 0 </returns>
        private double ValidarNumero(string strNumero)
        {
            double retornar = 0;
            double auxiliarNumero;

            if (double.TryParse(strNumero, out auxiliarNumero))
            {
                retornar = auxiliarNumero;
            }
            return retornar;
        }
        #endregion


        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador +. Se encarga de sumar 2 datos de tipo "Numero"
        /// </summary>
        /// <param name="n1"> Primer parametro a sumar </param>
        /// <param name="n2"> Segundo parametro a sumar </param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        /// <summary>
        /// Sobrecarga del operador -. Se encarga de sumar 2 datos de tipo "Numero"
        /// </summary>
        /// <param name="n1"> Primer parametro a restar </param>
        /// <param name="n2"> Parametro por el cual se va a restar </param>
        /// <returns>Retorna el resto</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        /// <summary>
        /// Sobrecarga del operador *. Se encarga de sumar 2 datos de tipo "Numero"
        /// </summary>
        /// <param name="n1"> Primer parametro a multiplicar </param>
        /// <param name="n2"> Segundo parametro a multiplicar </param>
        /// <returns> Retorna el producto de la multiplicacion </returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        /// <summary>
        /// Sobrecarga del operador /. Se encarga de sumar 2 datos de tipo "Numero"
        /// </summary>
        /// <param name="n1"> Parametro dividendo </param>
        /// <param name="n2"> Parametro divisor </param>
        /// <returns>Retorna el cociente de la division</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }

        #endregion
    }
}
