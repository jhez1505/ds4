using System;
using System.Web.UI;
using System.Globalization; 

namespace Laboratorio_15_4
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSumar_Click(object sender, EventArgs e)
        {
            try
            {
               
                int num1 = int.Parse(TextBoxNum1.Text);
                int num2 = int.Parse(TextBoxNum2.Text);

              
                int suma = num1 + num2;

                
                LabelResultado.Text = "La suma es: **" + suma.ToString() + "**";
            }
            catch (FormatException)
            {
                
                LabelResultado.Text = "Error: Por favor, introduce solo números válidos.";
            }
            catch (OverflowException)
            {
                
                LabelResultado.Text = "Error: Los números son demasiado grandes.";
            }
        }
    }
}