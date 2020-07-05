using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrabajoPracticoN4;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        

       
        /// <summary>
        /// Metodo que cierra todos los hilos activos
        /// </summary>
        public void FinEntrega()
        {
            foreach (Thread item in mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        /// <summary>
        /// Metodo que guarda en una cadena todos los paquetes de un correo
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>string con datos de los paquetes de correo</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Paquete item in ((Correo)elemento).Paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2}) \n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));
            }
            return sb.ToString();
        }
        /// <summary>
        /// Metodo que agrega paquetes en la lista de correo
        /// </summary>
        /// <param name="c">correo</param>
        /// <param name="p">pquete</param>
        /// <returns>correo con paquete agregado o no</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya existe");
                }
            }           
            c.paquetes.Add(p);
            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();
            return c;

        }
    }
}
