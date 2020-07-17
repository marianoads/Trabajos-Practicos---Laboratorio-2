using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        #region Methods

        /// <summary>
        /// Valida los operadores ingresados
        /// </summary>
        /// <param name="operador">Operador que se va a validar</param>
        /// <returns> Retornar - Si la validacion es correcta, retorna el valor ingresado. Caso contrario retorna "+" </returns>
        private static string ValidarOperador(string operador)
        {
            string retornar = "+";
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retornar = operador;
            }

            return retornar;
        }


        /// <summary>
        /// Opera 2 valores de tipo numero dependiendo de la operacion aritmetica elegida.
        /// </summary>
        /// <param name="num1"> Numero uno </param>
        /// <param name="num2"> Numero dos </param>
        /// <param name="operador"> Operacion aricmetica que se va a realizar </param>
        /// <returns> Retornar - Retorna un valor de tipo Double con el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retornar = 0;
            string operadorValidado;

            operadorValidado = ValidarOperador(operador);
            switch (operadorValidado)
            {

                case "+":
                    retornar = num1 + num2;
                    break;

                case "-":
                    retornar = num1 - num2;
                    break;

                case "/":
                    retornar = num1 / num2;
                    if (double.IsInfinity(retornar))
                    {
                        retornar = double.MinValue;
                    }
                    break;

                case "*":
                    retornar = num1 * num2;
                    break;
            }

            return retornar;
        }
        #endregion

    }
}
