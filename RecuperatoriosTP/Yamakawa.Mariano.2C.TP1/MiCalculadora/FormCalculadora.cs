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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        string operador;
        double resultado;

        /// <summary>
        /// Constructor de la clase FormCalculadora.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent(); // Inicializador.
            string[] operadores = { "+", "-", "*", "/" }; // Operadores.
            foreach (string operador in operadores) // Recorro los operadores.
            {
                this.cmbOperadores.Items.Add(operador); // Los añado.
            }
            this.cmbOperadores.SelectedIndex = 0;
            this.lblResultado.Text = "0"; // Texto de resultado a 0
            resultado = 0; // Resultado a 0
            btnLimpiar.Enabled = false; // Inhabilito el boton de limpiar.
            btnConvertirABinario.Enabled = false; // Inhabilito el boton de convertir a binario.
            btnConvertirADecimal.Enabled = false; // Inhabilito el boton de convertir a decimal.
        }


        /// <summary>
        /// Realiza las operaciones segun los parametros ingresados.
        /// </summary>
        /// <param name="numero1"> Segundo numero como parametro  </param>
        /// <param name="numero2"> Segundo numero como parametro </param>
        /// <param name="operador"> Tipo de operador artimetico </param>
        /// <returns> Retorna el resultado de la operacion </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1); // Nuevo objeto numeroUno
            Numero numeroDos = new Numero(numero2); // Nuevo objeto numeroDos
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }


        /// <summary>
        /// Borra los datos de la calculadora, y pone valores en " " y " 0 " para su reutilizacion.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear(); // Limpia numero 1
            this.txtNumero2.Clear(); // Limpia numero 2
            this.cmbOperadores.Text = ""; // Limpia operadores
            this.lblResultado.Text = "0"; // Limpia resultado
            btnConvertirABinario.Enabled = false; // Inhabilita botones.
            btnConvertirADecimal.Enabled = false; // Inhabilita botones.
        }


        /// <summary>
        /// Realiza la operacion asignada al apretar el boton "Operar".
        /// </summary>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            operador = this.cmbOperadores.Text; // Asigna al atributo operador.
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, operador); // Asigna al atributo resultado.
            this.lblResultado.Text = resultado.ToString(); // Llama a la funcion de resultado.
            btnConvertirABinario.Enabled = true; // Habilita boton.
            btnConvertirADecimal.Enabled = true; // Habilita boton.
            btnLimpiar.Enabled = true; // Habilita boton.
        }


        /// <summary>
        /// Realiza la limpieza de la calculadora al apretar el boton "Limpiar".
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
                 this.Limpiar(); // Llama al metodo limpiar.     
        }


        /// <summary>
        /// Cierra la calculadora al apretar el boton "Cerrar".
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
                this.Close(); // Llama al metodo cerrar.
        }


        /// <summary>
        /// Llama a la funcion para convertir decimal - binario.
        /// </summary>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text); // Convierte decimal-binario.
            if (lblResultado.Text != "Valor invalido")
            {
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Llama a la funcion para convertir binario - decimal.
        /// </summary>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text); // Convierte binario-decimal.
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Inicializacion de titulo en la calculadora con el nombre del alumno.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Calculadora de Luciano Moreno del curso 2A"; // Asigna el titulo desde tiempo compilacion.
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}
