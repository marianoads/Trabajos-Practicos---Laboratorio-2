using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Universitario()
        {
            this.legajo = 0;
        }

        /// <summary>
        /// Constructor que setea los parametros propios y llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="legajo">legajo de universitario</param>
        /// <param name="nombre">nombre de universitario</param>
        /// <param name="apellido">apellido de unviersitario</param>
        /// <param name="dni">deni de universitario</param>
        /// <param name="nacionalidad">nacionalidad de universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo virtual y protegido 
        /// </summary>
        /// <returns> retorna todos los datos de universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.legajo.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// metodo abstracto 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// metodo que compara si dos objetos son iguales
        /// </summary>
        /// <returns> retorna true si son del mismo tipo </returns>
        public override bool Equals(Object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Sobrecarga == que se encarga de saber si dos universitarios son iguales dependiendo su legajo o dni
        /// </summary>
        /// <param name="pg1">universitario 1</param>
        /// <param name="pg2">universitario 2</param>
        /// <returns>true si son iguales , false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI && pg1.Equals(pg2)) 
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga != que se encarga de saber si dos universitarios son distintos dependiendo su legajo o dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>true si son distintos , false si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion



        

    }
}
