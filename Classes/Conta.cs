using System;

namespace DIO.bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            TipoConta = tipoConta;
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            else
            {
                Saldo -= valorSaque;
                Console.WriteLine($"Saque realizado com sucesso na conta de {Nome}!\nSaldo atual: {Saldo}");
                return true;
            }
        }

        public void Depositar(double valorDeposito)
        {
         if (valorDeposito > 0){
         Saldo += valorDeposito; 
         } else {
            Console.WriteLine("Operação não realizada. O valor de depósito deve ser maior do que 0"); 
         }
        }

        public void Tranferir(double valorTransferencia, Conta contaDestino){
            if (Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            } else {
                System.Console.WriteLine("Transferência não realizada. Saldo insuficiente");
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno = $"Tipo de Conta: {TipoConta}\n" +
                      $"Nome: {Nome}\n" +
                      $"Saldo: {Saldo}\n" +
                      $"Crédito: {Credito}\n";
            return retorno;
        }


    }
}