using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
namespace EntidadesInstanciables
{
   public class Jornada
    {

        #region Atributos

        private List<Alumno> alumnos; //se inicializa constructor defecto
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa el atributo alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// constructor parametrizado que llama al base e inicializa los demas atributos propios
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">instructor que da clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que guarda los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si pudo guarda , false si no pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
    
            Texto t = new Texto();
   
            return  t.Guardar((AppDomain.CurrentDomain.BaseDirectory) + @"\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Metodo
        /// </summary>
        /// <returns> retornará los datos de la Jornada como texto</returns>
        public static string Leer()
        {
            string retorno ;
            Texto t = new Texto();
            t.Leer((AppDomain.CurrentDomain.BaseDirectory) + @"\Jornada.txt", out retorno);
              
            return retorno;
        }


        #endregion

        #region SobrecargaMetodos

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>Retorna los datos de la jornada de manera publica</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this.clase + " POR " + this.instructor);
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region SobrecargaOperadores

        /// <summary>
        /// Sobrecarga operador == 
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno participa de la clase , flase si no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }

            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga operador !=
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno no participa de la clase , flase si participa</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada validando que no este previamente cargado
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>jornada con el alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }
      
        #endregion

    }
}
