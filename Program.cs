using System;
using sistema_tranferencia_bancaria.Models;


namespace sistema_tranferencia_bancaria.Models
{
    class Program
    {
        static List<Conta> listaDeContas = new List<Conta>(); 
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;

            string opcaoEscolhida = ObterOpcaoEscolhida();

            while (opcaoEscolhida.ToUpper() != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        criarConta();
                        break; 
                    case "3":
                        Tranferir();
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

            opcaoEscolhida = ObterOpcaoEscolhida();
        }

        Console.WriteLine("Obrigado por utilizar nossos serviços");
        Console.WriteLine();
    }
    private static void Depositar()
    {
        Console.WriteLine("Digite o número da conta ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor a ser depoistado: ");
        double valorDeposito = double.Parse(Console.ReadLine());
        
        listaDeContas[indiceConta].Depositar(valorDeposito);
    }

    private static void Sacar()
    {
        Console.WriteLine("Digite o numero da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor do saque: ");
        double valorDoSaque = double.Parse(Console.ReadLine());

        listaDeContas[indiceConta].Sacar(valorDoSaque);
    }

    private static void Tranferir()
    {
        Console.WriteLine("Digite o numero da conta de origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o numero da conta de destino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor a ser tranferido: ");
        double valorDaTranferencia = double.Parse(Console.ReadLine());

        listaDeContas[indiceContaOrigem].Tranferir(valorDaTranferencia, listaDeContas[indiceContaDestino]);
    }

    private static void criarConta()
    {
        Console.WriteLine("Entre com os dados da nova conta ");
        
        Console.WriteLine("Digite o nome do novo cliente: ");
        string NomeRecebido = Console.ReadLine();

        Console.WriteLine("Entre com o valor do primeiro depoosito: ");
        double DepositoRecebido = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta(nome: NomeRecebido, saldo: DepositoRecebido);

        listaDeContas.Add(novaConta);
    }

    private static void ListarContas()
    {
        Console.WriteLine("Listar contas");
            if(listaDeContas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada ");
            return;
        }

        for (int i = 0; i < listaDeContas.Count; i++)
        {
            Conta conta = listaDeContas[i];
            Console.Write("#{0} - ", i);
            Console.WriteLine(conta);
        }
    }  

    private static string ObterOpcaoEscolhida()
        {
        Console.WriteLine("\nANDERBank Internacional\n");
        Console.WriteLine("Selecione a Opcao Desejada \n");   

        Console.WriteLine("Digite -> 1 listar contas ");
        Console.WriteLine("Digite -> 2 Criar uma nova conta ");
        Console.WriteLine("Digite -> 3 Transferência ");
        Console.WriteLine("Digite -> 4 Saque ");
        Console.WriteLine("Digite -> 5 Deposito ");
        Console.WriteLine("Digite -> C Limpar tela ");
        Console.WriteLine("Digite X para Sair do Menu \n");

        string opcaoEscolhida = Console.ReadLine().ToUpper();

        return opcaoEscolhida;
        }        
    }    
}