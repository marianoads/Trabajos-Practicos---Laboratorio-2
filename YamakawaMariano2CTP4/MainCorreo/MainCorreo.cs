using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using TrabajoPracticoN4;

namespace MainCorreo
{
    public partial class formCorreo : Form
    {
        Correo correo;

        public formCorreo()
        {
            InitializeComponent();
            correo = new Correo();

        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(TBDireccion.Text, TBTrackingID.Text);
            p.InformaEstado += new Paquete.DelegateEstado(paq_InformaEstado);
            try
            {
                correo = correo + p;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ActualizarEstados();



        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegateEstado d = new Paquete.DelegateEstado(paq_InformaEstado);
                this.Invoke(d, sender, e);
            }
            else
            {
                this.ActualizarEstados();
            }

        }

        public void ActualizarEstados()
        {
            listBoxIngresado.Items.Clear();
            listBoxEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();


            foreach (Paquete item in correo.Paquetes)
            {
                if (item.Estado == EEstado.Ingresado)
                {
                    listBoxIngresado.Items.Add(item.ToString(item));
                }
                else if (item.Estado == EEstado.EnViaje)
                {
                    listBoxEnViaje.Items.Add(item.ToString(item));
                }
                else
                {
                    lstEstadoEntregado.Items.Add(item.ToString(item));
                }
            }

        }

        private void formCorreo_FormClosed(object sender, FormClosedEventArgs e)
        {
            correo.FinEntrega();
        }

        public void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string cadena = "";

            if (!(Object.Equals(elemento, null)))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                try
                {
                    cadena = elemento.MostrarDatos(elemento);
                    cadena.Guardar("salida.txt");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }

        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);

        }
    }
}
