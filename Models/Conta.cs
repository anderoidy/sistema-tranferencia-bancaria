using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_tranferencia_bancaria.Models
{
    public class Conta
    {
        public string Nome { get; set; }
        public double Saldo { get; set; }      

        public Conta( string nome, double saldo)
        {
            this.Nome = nome;
            this.Saldo = saldo;
        }

        public Conta()
        {
        }

        public bool Sacar(double valorDoSaque)
        {
            if(this.Saldo < valorDoSaque)
            {
                Console.WriteLine("Saldo insuficiente ");
                return false;
            }
            this.Saldo -= valorDoSaque;

            Console.WriteLine("Saldo atual de {0} = {1}", this.Nome, this.Saldo);
        
        return true;
        }

        public void Depositar(double valorDeposito) 
            {
                this.Saldo += valorDeposito;
                Console.WriteLine("Saldo da conta de {0} = {1}", this.Nome, this.Saldo);
            }

            public void Tranferir(double valorDaTranferencia, Conta contaDestino)
            {
                if(this.Sacar(valorDaTranferencia))
                {
                    contaDestino.Depositar(valorDaTranferencia);
                }
            }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            return retorno;
        }
    }
}