using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrabajoPracticoN4;


namespace Entidades
{
    public enum EEstado { Ingresado, EnViaje, Entregado }
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        
        public delegate void DelegateEstado(object sender, EventArgs e);
        public event DelegateEstado InformaEstado;


        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }

        /// <summary>
        /// Hace que el paquete cambie de forma
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);


                if (this.estado == EEstado.Ingresado)
                {
                    this.estado = EEstado.EnViaje;
                }
                else if (this.estado == EEstado.EnViaje)
                {
                    this.estado = EEstado.Entregado;
                }

                this.InformaEstado(this.estado, EventArgs.Empty);
            } while (this.estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




        /// <summary>
        /// sobrecarga ToString para la clase paquete
        /// </summary>
        /// <returns>retorna string con datos del paquete</returns>

        public string ToString(Paquete paquete)
        {
            IMostrar<Paquete> m = paquete;
            return m.MostrarDatos(paquete);        
            
        }
        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento">paquete a mostrar datos</param>
        /// <returns>cadena con los datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Sobrecarga del operador == , si dos paquetes tiene el mismo Tracking ID estos son iguales
        /// </summary>
        /// <param name="p1">paquete 1</param>
        /// <param name="p2">paquete 2</param>
        /// <returns>true si son iguales , false si no</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.trackingID == p2.trackingID)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2) { 
        return !(p1==p2);
        }


    }

}
