using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestesCaelum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = 2;
            int c = 3;

            double a1, a2, delta;

            delta = b*b - (4*a*c);
            a1 = (-b + Math.Sqrt(delta)) / (2 * a);
            a2 = (-b - Math.Sqrt(delta)) / (2 * a);

            MessageBox.Show("Valores: a1 = " + a1 + ", a2 = " + a2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idade = 18;
            bool brasileiro = false;

            if (idade >= 16 && brasileiro)
            {
                MessageBox.Show("Você pode votar");
            }
            else
            {
                MessageBox.Show("Você não pode votar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double valorNotaFiscal = 3500;

            if (valorNotaFiscal < 1000.0)
            {
                MessageBox.Show("Imposto é de 2%");
            }
            else if ((valorNotaFiscal >= 1000) && (valorNotaFiscal < 3000))
            {
                MessageBox.Show("Imposto é de 2.5%");
            }
            else if ((valorNotaFiscal>=3000.00) && (valorNotaFiscal < 7000.00))
            {
                MessageBox.Show("Imposto é de 2.8%");
            }
            else if(valorNotaFiscal >= 7000.00)
            {
                MessageBox.Show("Imposto é de 3%");
            }
            else
            {
                MessageBox.Show("Valor fora da faixa de imposto");
            }
        }
    }
}
