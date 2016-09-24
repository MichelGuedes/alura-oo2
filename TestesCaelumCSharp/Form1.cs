using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestesCaelumCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSaida.Clear();
            txtSaida.AppendText("Mostrando múltiplos de 3... \n");

            for (int i=0; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    txtSaida.AppendText("Multiplo de 3 encontrado: " + i + "\n");
                }
            }

            txtSaida.AppendText("Fim de processamento");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSaida.Clear();
            int numeroDivisivel = 15;
            txtSaida.AppendText("Verificando se o número " + numeroDivisivel + " é divisível por 3 \n");

            if((numeroDivisivel % 3) == 0)
            {
                txtSaida.AppendText("Número " + numeroDivisivel + " é divisível por 3\n");
            }
            else
            {
                txtSaida.AppendText("Número " + numeroDivisivel + " NÃO é divisível por 3\n");
            }

            txtSaida.AppendText("Verificando se o número " + numeroDivisivel + " é divisível por 4\n");

            if ((numeroDivisivel % 4) == 0)
            {
                txtSaida.AppendText("Número " + numeroDivisivel + " é divisível por 4\n");
            }
            else
            {
                txtSaida.AppendText("Número " + numeroDivisivel + " NÃO é divisível por 4\n");
            }

            txtSaida.AppendText("Fim do processamento\n");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //verifica quais numeros entre 0 e 30 sao divisiveis por 3 e 4
            txtSaida.Clear();
            txtSaida.AppendText("Verificando quais números entre 0 e 30 são divisíveis por 3 e 4 \n");

            for (int i = 0; i<=30; i++)
            {
                if ((i % 3) == 0)
                {
                    txtSaida.AppendText("O número " + i + " é divisível por 3\n");
                }
                else
                {
                    txtSaida.AppendText("O número " + i + " NÃO é divisível por 3\n");
                }

                if ((i % 4) == 0)
                {
                    txtSaida.AppendText("O número " + i + " é divisível por 4\n");
                }
                else
                {
                    txtSaida.AppendText("O número " + i + " NÃO é divisível por 4\n");
                }
            }

            txtSaida.AppendText("Fim de processamento \n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //soma os valores de 1 a 100 e pula os multiplos de 3
            int total = 0;
            txtSaida.Clear();
            txtSaida.AppendText("Somando os números de 1 a 100 e ignorando os múltiplos de 3... \n");

            for (int i=1; i<=100; i++)
            {
                if ((i % 3) != 0)
                {
                    total += i;
                }
            }

            txtSaida.AppendText("Total da soma: " + total + ", fim do processamento.");
        }

        /// <summary>
        /// Aula 7 de CSharp, operacoes de conta corrente.
        /// </summary>
        class Conta
        {
            public int numero;
            public string titular;
            public double saldo;

            /// <summary>
            /// Retira valorASerSacado do atributo saldo
            /// </summary>
            /// <param name="valorASerSacado">valor tipo double a ser sacado do atributo saldo da conta</param>
            public void Saque(double valorASerSacado)
            {
                if ((valorASerSacado > 0) && (valorASerSacado <= this.saldo))
                {
                    saldo -= valorASerSacado;
                }
            }

            /// <summary>
            /// Adiciona valorASerDepositado ao atributo saldo
            /// </summary>
            /// <param name="valorASerDepositado">valor tipo double a ser depositado do atributo saldo da conta</param>
            public void Deposito(double valorASerDepositado)
            {
                if (valorASerDepositado > 0)
                {
                    saldo += valorASerDepositado;
                }
            }

            /// <summary>
            /// Usa metodo interno de saque para remover o valor da conta que chama este metodo, 
            /// e usa metodo interno de deposito para adicionar o valor para a conta origem de parametro
            /// </summary>
            /// <param name="valor">valor tipo double que sera extraido de conta que usa o metodo, e adicionado na conta origem</param>
            /// <param name="destino">conta para qual o valor esta indo</param>
            public void Transfere(double valor, Conta destino)
            {
                this.Saque(valor);
                destino.Deposito(valor);
            }

            /// <summary>
            /// Calcula rendimento anual para aquela conta
            /// </summary>
            /// <returns>valor tipo double com o calculo do rendimento</returns>
            public double CalculaRendimentoAnual()
            {
                double saldoNaqueleMes = this.saldo;

                for (int i = 1; i<=12; i++)
                {
                    saldoNaqueleMes = saldoNaqueleMes * 1.007;
                }

                return saldoNaqueleMes - this.saldo;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtSaida.Clear();
            txtSaida.AppendText("Iniciando a transferência bancária...\n");

            Conta lucas = new Conta();
            lucas.numero = 1;
            lucas.titular = "Lucas Guedes Vieira";
            lucas.saldo = 2000;

            Conta mari = new Conta();
            mari.numero = 2;
            mari.titular = "Mariana Guedes Vieira";
            mari.saldo = 1500;

            txtSaida.AppendText("O saldo do Lucas é: " + lucas.saldo + "\n");
            txtSaida.AppendText("O saldo da Mari é: " + mari.saldo + "\n");
            txtSaida.AppendText("Fazendo a transferência...\n");

            lucas.Transfere(200, mari);

            txtSaida.AppendText("O saldo do Lucas agora é: " + lucas.saldo + "\n");
            txtSaida.AppendText("O saldo da Mari agora é: " + mari.saldo + "\n");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtSaida.Clear();
            Conta contaDoLucas = new Conta();
            contaDoLucas.numero = 1;
            contaDoLucas.titular = "Lucas Guedes Vieira";
            contaDoLucas.saldo = 2000;

            txtSaida.AppendText("Rendimento anual da conta de " + contaDoLucas.titular +
                " é de " + contaDoLucas.CalculaRendimentoAnual());

        }
    }
}
