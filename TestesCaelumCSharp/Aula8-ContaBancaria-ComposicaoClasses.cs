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
    public partial class Aula8_ContaBancaria_ComposicaoClasses: Form
    {
        public Aula8_ContaBancaria_ComposicaoClasses()
        {
            InitializeComponent();
        }

        class Cliente
        {
            public string nome;
            public string rg;
            public string cpf;
            public string endereco;
            public int idade;

            /// <summary>
            /// Compara a idade atual do Cliente já armazenada no atributo idade
            /// </summary>
            /// <returns>Verdadeiro ou falso, dependendo da idade maior ou menor que 18</returns>
            public bool MaiorDeIdade()
            {
                return this.idade >= 18;
            }
        }

        class Conta
        {
            public int numero;
            public Cliente titular;
            public double saldo;

            /// <summary>
            /// Retira valorASerSacado do atributo saldo
            /// </summary>
            /// <param name="valorASerSacado">valor tipo double a ser sacado do atributo saldo da conta</param>
            public void Saque(double valorASerSacado)
            {
                if ((valorASerSacado > 0) && (valorASerSacado <= this.saldo))
                {
                    //se você tem menos de 18 , só pode sacar até 200 mangos
                    if ((this.titular.idade < 18) && (valorASerSacado > 200))
                    {
                        saldo -= 200;
                    }
                    else
                    {
                        saldo -= valorASerSacado;
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

                for (int i = 1; i <= 12; i++)
                {
                    saldoNaqueleMes = saldoNaqueleMes * 1.007;
                }

                return saldoNaqueleMes - this.saldo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta cnt = new Conta();
            Cliente cli = new Cliente();

            cli.nome = "Lucas";
            cli.rg = "1234";
            cli.cpf = "4321";
            cli.endereco = "Guadalajara";

            cnt.titular = cli;
            cnt.titular.nome = "Lucas Guedes Vieira";

            txtResult.Clear();
            txtResult.AppendText(cnt.titular.nome + " - " +
                cnt.titular.endereco + " - " +
                cnt.titular.rg + " - " +
                cnt.titular.cpf);
        }
    }
}
