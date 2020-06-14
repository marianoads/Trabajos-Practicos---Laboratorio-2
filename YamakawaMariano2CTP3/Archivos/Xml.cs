using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using System.Xml.Serialization;
using System.Globalization;
using System.ComponentModel;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IAchivos<T>
    {

        /// <summary>
        /// Metodo que implementa el metodo Guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del achivo(path)</param>
        /// <param name="datos">datos a serializar</param>
        /// <returns>true si pudo guardar , false si no pudo</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
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
        /// Metodo que implementa el metodo de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo(path)</param>
        /// <param name="datos">datos a leer</param>
        /// <returns>true si pudo leer , false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;           
            using (XmlTextReader reader = new XmlTextReader(archivo))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos =(T)serializer.Deserialize(reader);                                       
                    retorno = true;
                }
                catch (Exception)
                {
                    throw new ArchivosException("Error al leer el archivo");
                }
            }
            
            
            return retorno;

        }
    }
}
