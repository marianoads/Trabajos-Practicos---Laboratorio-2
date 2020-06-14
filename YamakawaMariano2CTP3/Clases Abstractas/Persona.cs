using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{

    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #region Atributos
        private string nombre;
        private string apellido;
        ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Propiedades
        /// <summary>
        /// gey y set del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// set y get para el atributo dni en con la validacion de que ingrese un dni correcto
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (this.nacionalidad == ENacionalidad.Argentino)
                {
                    this.dni = ValidarDni(ENacionalidad.Argentino, value);
                }
                else
                {
                    this.dni = ValidarDni(ENacionalidad.Extranjero, value);
                }
            }
        }

        /// <summary>
        /// get y set del atributo apellido con la validacion de apellido correcto en el set
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        /// <summary>
        /// get y set del atributo nombre con la validacion de nombre correcto en el set
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        /// <summary>
        /// set para el atributo dni en  con la validacion de que ingrese un dni correcto
        /// </summary>
        public string StringToDNI
        {
            set
            {
                if (this.nacionalidad == ENacionalidad.Argentino)
                {
                    this.dni = ValidarDni(ENacionalidad.Argentino, value);
                }
                else
                {
                    this.dni = ValidarDni(ENacionalidad.Extranjero, value);
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Persona()
        {
            this.nombre = "";
            this.apellido = "";
            this.dni = 0;
        }
        /// <summary>
        /// constructor con 3 parametros
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nacionalidad = nacionalidad;
            this.nombre = nombre;
            this.apellido = apellido;
        }
        /// <summary>
        /// constructor parametrizado el cual llama al constructor de 3 parametros
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="dni">dni de persona</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {            
            DNI = dni;
        }
        /// <summary>
        /// constructor parametrizado el cual llama al constrcutor de 3 parametros
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="dni">dni de persona</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {            
            StringToDNI = dni;
        }
        #endregion

        #region Metodos


        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }

        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {          
            int num;
           
            if (!int.TryParse(dato, out num))
            {

                throw new DniInvalidoException("Dni formato incorrecto");
            }
            else
            {
                num = Int32.Parse(dato);
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    if (num < 1 || num > 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    }
                }
                else
                {
                    if (num < 90000000 || num > 99999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    }
                }
            }

            return num ;
        }
        /// <summary>
        /// Metodo que valida que el dato sean solo letras
        /// </summary>
        /// <returns>Retorna true si contiene solo letras</returns>
        public string ValidadNombreApellido(string dato)
        {
            bool esSoloLetra = dato.All(char.IsLetter);
            if (esSoloLetra == false)
            {
                return "false";
            }
            return dato;
        }
        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>Retorna todos los datos de persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO:" + this.apellido + ", " + this.nombre);
            sb.AppendLine("Nacionalidad :" + this.nacionalidad);


            return sb.ToString();
        }
        #endregion






    }
}
