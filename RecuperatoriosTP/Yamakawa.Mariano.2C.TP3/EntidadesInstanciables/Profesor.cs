using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
  public sealed  class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor estatico que incializa el atributo random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Profesor() 
        {

        }

        /// <summary>
        /// Constructor que setea los atributos propios y llama al base para inicializar los atributos heredados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos    

        /// <summary>
        /// Metodo que asigna dos clases al atributo clasesDelDia
        /// </summary>
        private void _randomClases()
        {
            int i;

            for (i = 0; i < 2; i++)
            {          
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0,3));
            }

        }

        #endregion

        #region SobrecargaMetodos

        /// <summary>
        /// Sobrecarga de metodo 
        /// </summary>
        /// <returns>retorna la cadena "CLASES DEL DÍA" junto al nombre de la clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASES DEL DIA:\n");


            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de metodo 
        /// </summary>
        /// <returns>retorna los datos de profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecara de metodo 
        /// </summary>
        /// <returns> retorna los datos del profesor de manera publica</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

    

        #endregion

        #region SobrecargaOperadores

        /// <summary>
        /// Sobrecarga operador == en la cual un profesor es igual  a una clase si este da esa clase
        /// </summary>
        /// <param name="i">profesor a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>true si son iguales , false si no lo son</returns>
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (clase == item)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga operador != en la cual un profesor es distinto a una clase si este da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si son distintos , false si son iguales</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
