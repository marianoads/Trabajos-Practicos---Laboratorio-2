using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
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
                using (StreamWriter sm = new StreamWriter(archivo, false))
                {
                    sm.WriteLine(datos);
                    retorno = true;
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e); 
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
            datos = "";
            try
            {
               using (StreamReader sr = new StreamReader(archivo))
               {
               datos = sr.ReadToEnd();
               }
               retorno = true;
            }

            catch(Exception e)
            {
               throw new ArchivosException(e);
            }
        return retorno;
        }
    }
}
