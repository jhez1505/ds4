using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Laboratorio121.Class1;

namespace Laboratorio121
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double velocidad = double.Parse(textBox1.Text);
                double tiempo = double.Parse(textBox2.Text);

                CalculadorMovil calculadorora = new CalculadorMovil();

                double resultadoDistancia = calculadorora.CalcularDistancia(velocidad, tiempo);
                textBox3.Text = resultadoDistancia.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para velocidad y tiempo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
