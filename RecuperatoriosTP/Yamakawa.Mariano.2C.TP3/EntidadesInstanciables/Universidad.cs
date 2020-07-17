using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
namespace EntidadesInstanciables
{
   public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades

      
        public Jornada this[int indice]
        {
            get
            {
                if (indice >= 0 && indice < this.jornada.Count)
                {
                    return this.jornada[indice];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.jornada[indice] = value;
            }
        }

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// constructor por defecto que inicializa los atributos de la clase
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo estatico
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Retorna los datos de Universiidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
         
            foreach(Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<------------------------------------------------>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo estatico que  serializa los datos del Universidad en un XML, incluyendo todos los datos de sus
        ///Profesores, Alumnos y Jornadas
        /// </summary>
        /// <param name="u">universidad a serializar</param>
        /// <returns>true si pudo serializar , false si no</returns>
        public static bool Guardar(Universidad u)
        {
            Xml<Universidad> x = new Xml<Universidad>();

            return x.Guardar((AppDomain.CurrentDomain.BaseDirectory) + @"\Universidad.Xml", u);


        }
        /// <summary>
        /// Metodo estatico
        /// </summary>
        /// <returns> retorna un Universidad con todos los datos previamente serializado</returns>
        public static Universidad Leer()
        {
            Universidad u= new Universidad();
            
            Xml<Universidad> x = new Xml<Universidad>();
            x.Leer((AppDomain.CurrentDomain.BaseDirectory) + @"\Universidad.Xml", out u);

            return u;
        }

        #endregion

        #region SobrecargaMetodos
        /// <summary>
        /// Sobercarga Metodo
        /// </summary>
        /// <returns>Retorna los datos de universidad de manera publica</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region SobrecargasOperadores

        /// <summary>
        /// Sobrecarga == compara si una universidad es igual a un alumno si el mismo esta inscripto en el
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno esta inscripto , false si no </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.alumnos)
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
        /// Sobrecarga != compara si una universidad es distinta a un alumno si el mismo no esta inscripto en el
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a compara</param>
        /// <returns>true si el alumno no esta inscripto , false si esta inscripto</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga == Comapara si una universidad es igual a un profesor si el mismo esta dando clase en el
        /// </summary>
        /// <param name="g">Unviersidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>true si el profesor da clases en la universidad , false si no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.profesores)
            {
                if (i == item)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// obrecarga != Comapara si una universidad es distinta a un profesor si el mismo no esta dando clase en el
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>true si el profesor no da clases en la universidad , false si el miso da clases </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga == entre universidad y clase dentro se utiliza la sobrecarga  == de profesor
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>retorna el primer profesor capas de dar la clase, sino lanza una excepcion</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {

            Profesor retorno = new Profesor();
            bool flag = false;
            int i;


            for (i = 0; i < g.profesores.Count; i++)
            {
                if (g.profesores[i] == clase)
                {
                    retorno = g.profesores[i];
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {

                throw new SinProfesorException();
            }
            return retorno;
        }


        /// <summary>
        /// Sobrecarga != entre universidad y clase dentro se utiliza la sobrecarga  == de profesor
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>retorna el primer profesor capas de no dar la clase, sino lanza una excepcion</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor retorno = new Profesor();
            bool flag = false;
            int i;
            for (i = 0; i < g.profesores.Count; i++)
            {
                if (g.profesores[i] != clase)
                {
                    retorno = g.profesores[i];

                    break;
                }
            }
            if (flag == false)
            {
                //nose si tirar la excepcion o retornar null o algo en el caso de que todos los profesores  puedan dar la clase
                throw new SinProfesorException();
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga + en el cual se agrega una clase a una universidad 
        /// </summary>
        /// <param name="g">Universidad </param>
        /// <param name="clase">clase a agregar en la universidad</param>
        /// <returns>Universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = (g == clase);
            Jornada j = new Jornada(clase, p);

            foreach(Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    j += item;
                }
                
            }

            g.Jornadas.Add(j);
            return g;
        }

        /// <summary>
        /// Sobrecarga + Agrega un alumno a la universidad si no estan previamente cargados
        /// </summary>
        /// <param name="g">Universidad </param>
        /// <param name="a">alumno a agregar en la universidad</param>
        /// <returns>retorna universidad con el alumno agregado , caso contrario lanza excepcion</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return g;
        }

        /// <summary>
        /// Sobrecarga + Agrega un profesor a la universidad si no estan previamente cargados
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">profesor a agregar en la universidad</param>
        /// <returns>retorna universidad con el profesor agregado </returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }

          //en el else no sabia si agregar una excepcion o algo ya que no lo dice en el enunciado

            return g;
        }
        
        #endregion

        #region Enumerados

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        # endregion
    }
}
