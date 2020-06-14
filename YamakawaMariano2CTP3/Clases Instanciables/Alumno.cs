using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{   

    public class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="id">id de alumno</param>
        /// <param name="nombre">nombre de alumno</param>
        /// <param name="apellido">apellido de alumno</param>
        /// <param name="dni">dni de alumno</param>
        /// <param name="nacionalidad">nacionalidad de alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado que setea el atribuo estaodCuenta y llama al this para setear los atributos indicados
        /// </summary>
        /// <param name="id">id de alumno</param>
        /// <param name="nombre">nombre de alumno</param>
        /// <param name="apellido">apellido de alumno</param>
        /// <param name="dni">dni de alumno</param>
        /// <param name="nacionalidad">nacionalidad de alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        /// <param name="estadoCuenta">estado de cuenta de alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Sobrecarga de metodo 
        /// </summary>
        /// <returns>retorna los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Legajo: "+base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine("Estado de cuenta: " + estadoCuenta);

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de metodo 
        /// </summary>
        /// <returns>retorna los datos del alumno de manera publica</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Sobrecarga de metodo  
        /// </summary>
        /// <returns>retorna  la cadena "TOMA CLASE DE " junto al nombre de la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASE DE " + this.claseQueToma);
        }
        #endregion

        #region     Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga == en la cual un alumno es igual a una clase si este toma esa clase y su cuenta no es Deudor
        /// </summary>
        /// <param name="a">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>true si son iguales , false si no lo son</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga != en la cual un alumno es distinto a una clase si este no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si son distintos , false si son iguales</returns>

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }
        #endregion




    }
}
