using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Guarda un archivo de texto en el escritorio de la maquina
        /// </summary>
        /// <param name="texto">texto a guardar</param>
        /// <param name="archivo">path</param>
        /// <returns>true si pudo guardar ,false si no</returns>
        
        public static bool Guardar(this string texto , string archivo)
        {
            bool retorno = true;
            string path =  @"\" + archivo;
            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path;
 
            try
            {
                if(File.Exists(path2))
                {
                    using (StreamWriter sw = new StreamWriter(path2, true))
                    {
                        sw.WriteLine(texto);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(path2, false))
                    {
                        sw.WriteLine(texto);
                    }
                }

            }
            catch(Exception e)
            { 
                retorno = false;
              
            }
            return retorno;
        }

    }
}
