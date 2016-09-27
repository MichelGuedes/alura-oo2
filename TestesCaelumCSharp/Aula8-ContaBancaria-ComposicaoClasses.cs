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
    public partial class Aula8_ContaBancaria_ComposicaoClasses : Form
    {
        public Aula8_ContaBancaria_ComposicaoClasses()
        {
            InitializeComponent();
        }

        class Cliente
        {
            public string Nome { get; set; }
            public string Rg { get; set; }
            public string Cpf { get; set; }
            public string Endereco { get; set; }
            public int Idade { get; set; }

            public Cliente (string nomeCliente)
            {
                Nome = nomeCliente;
            }

            /// <summary>
            /// Compara a idade atual do Cliente já armazenada no atributo idade
            /// </summary>
            /// <returns>Verdadeiro ou falso, dependendo da idade maior ou menor que 18</returns>
            public bool MaiorDeIdade()
            {
                return this.Idade >= 18;
            }

            public Cliente()
            {

            }
        }

        class Conta
        {
            public int Numero { get; set; }
            public Cliente titular;
            public double Saldo { get; private set; }

            /// <summary>
            /// Retira valorASerSacado do atributo saldo
            /// </summary>
            /// <param name="valorASerSacado">valor tipo double a ser sacado do atributo saldo da conta</param>
            public void Saque(double valorASerSacado)
            {
                if ((valorASerSacado > 0) && (valorASerSacado <= this.Saldo))
                {
                    //se você tem menos de 18 , só pode sacar até 200 mangos
                    if ((this.titular.Idade < 18) && (valorASerSacado > 200))
                    {
                        Saldo -= 200;
                    }
                    else
                    {
                        Saldo -= valorASerSacado;
                    }
                }
                else
                {
                    //não retorna nada, valor sacado é inválido
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
                    Saldo += valorASerDepositado;
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
                double saldoNaqueleMes = this.Saldo;

                for (int i = 1; i <= 12; i++)
                {
                    saldoNaqueleMes = saldoNaqueleMes * 1.007;
                }

                return saldoNaqueleMes - this.Saldo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta cnt = new Conta();
            Cliente cli = new Cliente("Lucas Guedes");

            cli.Nome = "Lucas";
            cli.Rg = "1234";
            cli.Cpf = "4321";
            cli.Endereco = "Guadalajara";

            cnt.titular = cli;
            cnt.titular.Nome = "Lucas Guedes Vieira";

            txtResult.Clear();
            txtResult.AppendText(cnt.titular.Nome + " - " +
                cnt.titular.Endereco + " - " +
                cnt.titular.Rg + " - " +
                cnt.titular.Cpf);
        }
    }
}
