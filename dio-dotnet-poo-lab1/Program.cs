using dio_dotnet_poo_lab1.Classes;
using dio_dotnet_poo_lab1.Enum;
using System;
using System.Collections.Generic;

namespace dio_dotnet_poo_lab1
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {            
            
            int opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != 6)
            {                

                switch (opcaoUsuario)
                {
                    case 1:
                        InserirConta();                        
                        break;

                    case 2:
                        ListarContas();
                        break;

                    case 3:
                        Transferir();
                        break;

                    case 4:
                        Sacar();
                        break;

                    case 5:
                        Depositar();
                        break;                    

                    default:
                        throw new ArgumentOutOfRangeException();                        
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("\nObrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("═══════════════  5 DEPOSITAR  ════════════════  \n\n\n");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
            Console.WriteLine("\n\nOperação realizada com sucesso!!!\n\nPressione enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Sacar()
        {
            Console.Write("═══════════════  4 SACAR  ════════════════  \n\n\n");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
            Console.WriteLine("\n\nPressione enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Transferir()
        {
            Console.Write("═══════════════  3 TRANSFERIR  ════════════════  \n\n\n");

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            Console.WriteLine("\n\nOperação realizada com sucesso!!!\n\nPressione enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void InserirConta()
        {
            int Opcao;

            do
            {
                Console.Write("═══════════════  1 CADASTRAR CONTA  ════════════════  \n\n\n");
                Console.WriteLine("Inserir nova conta");

                Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
                int entradaTipoConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o Nome do Cliente: ");
                string entradaNome = Console.ReadLine();

                Console.Write("Digite o saldo inicial: ");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.Write("Digite o crédito: ");
                double entradaCredito = double.Parse(Console.ReadLine());

                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                            saldo: entradaSaldo,
                                            credito: entradaCredito,
                                            nome: entradaNome);

                listContas.Add(novaConta);
                Console.WriteLine("\n\nOperação realizada com sucesso!!!\n\nDigite 1 para novo cadastro ou 2 para retornar ao menu");
                Opcao = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (Opcao != 2);            
            Console.Clear();
        }

        private static void ListarContas()
        {
            Console.Write("═══════════════  2 CONSULTAR CONTAS  ════════════════  \n\n\n");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
            Console.WriteLine("\n\nPressione enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static int ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("═════════════DIO Bank a seu dispor!!!════════════");
            Console.WriteLine("");
            Console.WriteLine("╔═══════════════ MENU DE OPÇÕES ════════════════╗    ");
            Console.WriteLine("║            1 CADASTRAR NOVA CONTA             ║    ");
            Console.WriteLine("║                                               ║    ");
            Console.WriteLine("║            2 CONSULTAR CONTAS                 ║    ");
            Console.WriteLine("║                                               ║    ");
            Console.WriteLine("║            3 TRANSFERIR                       ║    ");
            Console.WriteLine("║                                               ║    ");
            Console.WriteLine("║            4 SACAR                            ║    ");
            Console.WriteLine("║                                               ║    ");
            Console.WriteLine("║            5 DEPOSITAR                        ║    ");
            Console.WriteLine("║                                               ║    ");
            Console.WriteLine("║            6 SAIR                             ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");
            Console.WriteLine(" ");

            Console.Write("DIGITE UMA OPÇÃO : ");
            int Option = int.Parse(Console.ReadLine());
            Console.WriteLine();            
            Console.Clear();
            return Option;
        }
    }
}
