using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoN4
{
    public static class GuardarString
    {
        /// <summary>
        /// Guarda un archivo de texto en el escritorio de la maquina
        /// </summary>
        /// <param name="texto">texto a guardar</param>
        /// <param name="archivo">path</param>
        /// <returns>true si pudo guardar ,false si no</returns>
        public static bool Guardar(this String texto, String archivo) {
            bool retorno = false;
            if (File.Exists(archivo))
            {
                using (StreamWriter nuevaTarea = new StreamWriter(archivo, true))
                {
                    nuevaTarea.WriteLine(texto);
                }                   
                         
            }
            else{

                using (StreamWriter nuevaTarea = new StreamWriter(archivo, true))
                {
                    nuevaTarea.WriteLine(texto);
                }
            }

            return retorno;
        }
    }
}
