using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> ListaContas = new List<Conta>();
        static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, "Leandro Castro", 0, 0);

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario){
                    case "1":
                    ListarContas();
                    break;
                    case "2":
                    InserirConta();
                    break;
                    case "3":
                    Transferir();
                    break;
                    case "4":
                    Sacar();
                    break;
                    case "5":
                    Depositar();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por usar nossos serviços");
            Console.ReadKey();
        }

   
        private static void ListarContas()
        {
           System.Console.WriteLine("Listar Contas");

           if (ListaContas.Count == 0){
               System.Console.WriteLine("Nenhuma conta cadastrada");
           } else {
               for (int i =0; i < ListaContas.Count; i++){
                   Conta conta = ListaContas[i];
                   Console.WriteLine($"#{i}:\n{conta}");
               }
           }
        }

         private static void InserirConta()
        {
           System.Console.WriteLine("Inserir nova conta\n");
           
           System.Console.Write("Digite 1 para Pessoa física e 2 para pessoa Jurídica: ");
           int entradaTipoConta = int.Parse(Console.ReadLine());
           
           System.Console.Write("Digite o nome do cliente: ");
           string entradaNome = Console.ReadLine();

           System.Console.Write("Digite o saldo inicial: ");
           double entradaSaldo = double.Parse(Console.ReadLine());

           System.Console.Write("Digite o crédito: ");
           double entradaCredito = double.Parse(Console.ReadLine());

           Conta novaConta = new Conta((TipoConta)entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
           ListaContas.Add(novaConta);
        }

        private static void Transferir()
        {
            System.Console.WriteLine("Transferência");

            System.Console.Write("Digite o número da conta Origem: ");
            int indiceConta = int.Parse(Console.ReadLine()); 

            System.Console.Write("Digite o número da conta Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o valor a ser transferido: ");
            double valorTranferencia = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Tranferir(valorTranferencia, ListaContas[indiceContaDestino]);
            
        }

        
        private static void Sacar()
        {
           
           System.Console.Write("Digite o número da conta: ");
           int indiceConta = int.Parse(Console.ReadLine());

           System.Console.Write("Digite o valor a ser sacado: ");
           double valorSaque = double.Parse(Console.ReadLine());

           ListaContas[indiceConta].Sacar(valorSaque);

        }
          private static void Depositar()
        {
            System.Console.Write("Digite o número da conta: ");
           int indiceConta = int.Parse(Console.ReadLine());

           System.Console.Write("Digite o valor a ser depositado: ");
           double valorDeposito = double.Parse(Console.ReadLine());

           ListaContas[indiceConta].Depositar(valorDeposito);
        }




        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a opção desejada:\n");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair\n\n");

            string opcao = Console.ReadLine().ToUpper();
            System.Console.WriteLine("");
            return opcao;
        }
    }
}
