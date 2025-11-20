using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Laboratorio123.CalculoPA;

namespace Laboratorio123
{
    public partial class Form1 : Form

    {
        private double sPerimetro;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double ladoA = double.Parse(textBox1.Text);
                double ladoB = double.Parse(textBox2.Text);
                double ladoC = double.Parse(textBox3.Text);

                CalculadorPerimetroA calculoP = new CalculadorPerimetroA();
                
                this.sPerimetro = calculoP.CalculoSPerimetro(ladoA, ladoB, ladoC);
                textBox4.Text = this.sPerimetro.ToString("F2");

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para los lados.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.sPerimetro <= 0)
            {
                MessageBox.Show("Primero debe calcular el Semiperímetro (Botón 1) antes de calcular el Área.", "Cálculo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                double ladoA = double.Parse(textBox1.Text);
                double ladoB = double.Parse(textBox2.Text);
                double ladoC = double.Parse(textBox3.Text);

                CalculadorPerimetroA calculoA = new CalculadorPerimetroA();

                double area = calculoA.CalculoArea(this.sPerimetro, ladoA, ladoB, ladoC);
                textBox5.Text = area.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para los lados.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
