using System;
using System.Collections.Generic;

namespace Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pedido> pedidos = new List<Pedido>();
            bool controle = true;
            while (controle)
            {
                Console.WriteLine("Bem vindo ao sistema de Pedidos!\n\nSelecione o dígito da operação a ser realizada:\n\n1 - Cadastrar pedido;" +
                    "\n2 - Remover pedido;\n3 - Listar todos os pedidos;\n4 - Sair.");
                Opcao menu = (Opcao)Enum.Parse(typeof(Opcao), Console.ReadLine());
                switch (menu)
                {
                    case Opcao.Adicionar:
                        Adicionar(pedidos);
                        break;
                    case Opcao.Remover:
                        Remover(pedidos);
                        break;
                    case Opcao.Listar:
                        Listar(pedidos);
                        break;
                    case Opcao.Sair:
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nosso sistema de Biblioteca!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Resposta inválida. |");
                        Console.WriteLine(new string('-', 20));
                        Console.WriteLine("");
                        break;
                }
            }
        }
        public static void Adicionar(List<Pedido> pedidos)
        {
            Console.Clear();
            bool loopAdd = true;
            while (loopAdd)
            {
                Console.WriteLine("Digite, linha a linha, o nome do produto, o preço pago pelo pedido e sua data (ddmmyyyy):");
                string nome = Console.ReadLine();
                int preco = int.Parse(Console.ReadLine());
                string dataInput = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(nome) && DateTime.TryParseExact(dataInput, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
                {
                    Console.WriteLine($"O pedido do produto '{nome}' é nacional ou internacional?\n\n" +
                        $"digite 1 para Nacional e 2 para Internacional:");
                    TipoPedido tipo = (TipoPedido)Enum.Parse(typeof(TipoPedido), Console.ReadLine());
                    Pedido p = tipo switch
                    {
                        TipoPedido.Nacional => new PedidoNacional(nome, data, tipo, preco),
                        TipoPedido.Internacional => new PedidoInternacional(nome, data, tipo, preco),
                        _ => null
                    };
                    if (p != null)
                    {
                        pedidos.Add(p);
                        Console.Clear();
                        Console.WriteLine("Pedido adicionado com sucesso! |");
                        Console.WriteLine(new string('-', 32));
                        Console.WriteLine("");
                        loopAdd = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ocorreu um erro. |");
                        Console.WriteLine(new string('-', 18));
                        Console.WriteLine("");
                        loopAdd = false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu um erro. |");
                    Console.WriteLine(new string('-', 18));
                    Console.WriteLine("");
                }
            }
        }
        public static void Remover(List<Pedido> pedidos)
        {
            if (pedidos.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há pedidos a serem removidos! |");
                Console.WriteLine(new string('-', 35));
                Console.WriteLine("");
                return;
            }
            bool loopRem = true;
            while (loopRem)
            {
                Console.WriteLine("Pedidos:\n\n");
                for (int i = 0; i < pedidos.Count; i++)
                {
                    Console.WriteLine($"{pedidos[i].IDPedido} - {pedidos[i].Nome} do dia {pedidos[i].DataPedido} que custou R${pedidos[i].Preco};");
                }
                Console.WriteLine("Informe o ID do produto a ser removido:");
                int inputID = int.Parse(Console.ReadLine());
                Pedido pedido = pedidos.Find(p => p.IDPedido == inputID);
                if (pedido != null)
                {
                    pedidos.Remove(pedido);
                    Console.WriteLine("Pedido removido com sucesso! |");
                    Console.WriteLine(new string('-', 35));
                    Console.WriteLine("");
                    loopRem = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu um erro. |");
                    Console.WriteLine(new string('-', 18));
                    Console.WriteLine("");
                }
            }
        }
        public static void Listar(List<Pedido> pedidos)
        {
            if (pedidos.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhum pedido foi registrado! |");
                Console.WriteLine(new string('-', 31));
                Console.WriteLine("");
                return;
            }
            Console.Clear();
            Console.WriteLine("Pedidos:\n");
            double precoTotal = 0;
            Console.WriteLine(new string('-', 50));
            for (int i = 0; i < pedidos.Count; i++)
            {
                Pedido p = pedidos[i];
                if (p != null)
                {
                    double preco = pedidos[i].CalcularTotal(pedidos[i].Preco);
                    precoTotal += preco;
                    Console.WriteLine($"\n{p.IDPedido} - {p.Nome} do dia {p.DataPedido} com preço R${p.Preco};\n");
                    Console.WriteLine(new string('-', 50));
                }
            }
            Console.WriteLine($"Valor total dos pedidos - R${precoTotal}.");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("");
        }
    }
}