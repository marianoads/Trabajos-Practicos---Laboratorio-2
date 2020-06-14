using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.Win32;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
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
            this.instructor = instructor;
            this.clase = clase;
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

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga operador == 
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno participa de la clase , flase si no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in j.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
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
            bool retorno = false;
            foreach (Alumno item in j.Alumnos)
            {
                if (item != a)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Agrega un alumno a la jornada validando que no este previamente cargado
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>jornada con el alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {

            }
            else
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>Retorna los datos de la jornada de manera publica</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------\n\nJORNADA:");
            sb.Append("Clase de: " + this.Clase);
            sb.AppendLine(" POR NOMBRE COMPLETO: " + this.Instructor.Apellido + ", " + this.Instructor.Nombre);
            sb.AppendLine("Nacionalidad :" + this.Instructor.Nacionalidad);
            sb.AppendLine("Legajo Numero: " + this.Instructor.getLegajo());
            sb.Append("Clases del dia: \n" + this.Instructor.ToString());

            sb.AppendLine("\n\nALUMNOS: ");
            foreach (Alumno item in alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Metodo que guarda los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si pudo guarda , false si no pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            try
            {
                StreamWriter text = new StreamWriter(@"C:\Users\Mariano\Downloads\jornada.txt");
                text.Write(jornada.ToString());
                text.Close();
                retorno = true;
            }
            catch (Exception)
            {

                throw new ArchivosException("Error al guardar el archivo");
            }
            return retorno;

        }
        /// <summary>
        /// Metodo
        /// </summary>
        /// <returns> retornará los datos de la Jornada como texto</returns>
        public static string Leer()
        {
            string retorno = "";
            try
            {
                StreamReader text = new StreamReader(@"C:\Users\Mariano\Downloads\jornada.txt");
                retorno = text.ReadToEnd();
                text.Close();
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al leer el archivo");
            }

            return retorno;
        }
        #endregion






    }
}
