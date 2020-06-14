using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    public class Texto:IAchivos<string>
    {
        /// <summary>
        /// Metodo el cual implementa el metodo Guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>true si guarda los datos , false si no</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter text = new StreamWriter(archivo))
                {
                        text.Write(datos);
                    retorno = true;
                }            
                
            }
            catch (Exception)
            {

                throw new ArchivosException("Error al guardar el archivo");
            }

            return retorno;
        }

        /// <summary>
        /// Metodo que implementa el metodo Leer de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">cadena en donde se guardan los datos que se leen</param>
        /// <returns>true si pudo leer , false si no</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamReader text = new StreamReader(archivo))
                {
                    datos = text.ReadToEnd();
                    retorno = true;
                }
                
                
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al leer el archivo");
            }
            return retorno;

        }

    }
}
