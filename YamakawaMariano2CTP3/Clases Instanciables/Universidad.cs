using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Xml;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Constructores
        /// <summary>
        /// constructor por defecto que inicializa los atributos de la clase
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
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

        public List<Profesor> Instructor
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

        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
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
            

            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
            }

            

            return sb.ToString();
        }
        /// <summary>
        /// Sobercarga Metodo
        /// </summary>
        /// <returns>Retorna los datos de universidad de manera publica</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Metodo estatico que  serializa los datos del Universidad en un XML, incluyendo todos los datos de sus
        ///Profesores, Alumnos y Jornadas
        /// </summary>
        /// <param name="u">universidad a serializar</param>
        /// <returns>true si pudo serializar , false si no</returns>
        public static bool Guardar(Universidad universidad)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\Mariano\Downloads\Universidad.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Universidad));
                    serializer.Serialize(writer, universidad);
                    retorno = true;
                }
            }
            catch (Exception)
            {

                throw new ArchivosException("Error al guardar archivos");
            }

            return retorno;
        }
        /// <summary>
        /// Metodo estatico
        /// </summary>
        /// <returns> retorna un Universidad con todos los datos previamente serializado</returns>
        public static string Leer()
        {
            Universidad u = new Universidad();
          
            using (XmlTextReader reader = new XmlTextReader(@"C:\Users\Mariano\Downloads\Universidad.xml"))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Universidad));
                    u =(Universidad)serializer.Deserialize(reader);
                    
                   
                }
                catch (Exception)
                {
                    throw new ArchivosException("Error al leer el archivo");
                }
                return u.ToString();
            }
        }
        #endregion

        #region Sobrecarga de operadores
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
            foreach (Profesor item in g.Instructor)
            {
                if (item == i)
                {
                    retorno = true;
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
            Profesor retorno = null;
            bool flag = false;

            foreach (Profesor item in g.Instructor)
            {
                if (item == clase)
                {
                    retorno = item;
                    flag = true;
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
            Profesor retorno = null;
            foreach (Profesor item in g.Instructor)
            {
                if (item != clase)
                {
                    retorno = item;
                }
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
            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
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
        public static Universidad operator +(Universidad u, Alumno a)
        {
            bool existe = false;
            foreach (Alumno item in u.Alumnos)
            {
                if (item == a)
                {
                    existe = true;
                    throw new AlumnoRepetidoException();
                }
            }
            if (existe == false)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// Sobrecarga + Agrega un profesor a la universidad si no estan previamente cargados
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">profesor a agregar en la universidad</param>
        /// <returns>retorna universidad con el profesor agregado </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            bool existe = false;
            foreach (Profesor item in u.Instructor)
            {
                if (item == i)
                {
                    existe = true;
                }
            }
            if (existe == false)
            {
                u.Instructor.Add(i);
            }
            return u;
        }
        #endregion

    }


}

