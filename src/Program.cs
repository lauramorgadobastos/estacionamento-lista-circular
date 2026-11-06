using System;
using Estacionamento.Models;    
using Estacionamento.Services;

namespace Estacionamento.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            Estacionamento est = new Estacionamento();

            bool sair = false;

            while (!sair) // Menu Principal 
            {
                Console.Clear();
                Console.WriteLine("=====================================================");
                Console.WriteLine("|============ SISTEMA DE ESTACIONAMENTO ============|");
                Console.WriteLine("| 1. Registrar Entrada de Veículo                   |");
                Console.WriteLine("| 2. Registrar Saída de Veículo (por Placa)         |");
                Console.WriteLine("| 3. Listar Veículos no Pátio                       |");
                Console.WriteLine("| 4. Adicionar Veículo Aleatório (Teste Rápido)     |");
                Console.WriteLine("| 5. Lotar Estacionamento Automaticamente (Teste)   |");
                Console.WriteLine("| 6. Retirar Todos os Carros do Estacionamento      |");
                Console.WriteLine("| 7. Simular Horário de Entrada (Testar Cobrança)   |");
                Console.WriteLine("| 8. Visualizar Estado dos Ponteiros (Início/Fim)   |");
                Console.WriteLine("| 0. Sair                                           |");
                Console.WriteLine("=====================================================");

                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- REGISTRAR ENTRADA ---");
                        Console.Write("Digite a Placa: ");
                        string placa = Console.ReadLine();
                        Console.Write("Digite o Nome do Modelo/Condutor: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a Marca: ");
                        string marca = Console.ReadLine();

                        est.EntradaNovoVeiculo(placa, nome, marca);

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("--- REGISTRAR SAÍDA ---");
                        Console.Write("Digite a Placa do veículo que deseja retirar: ");
                        string placaSaida = Console.ReadLine();

                        est.SaidaNovoVeiculoPorPlaca(placaSaida);

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        est.ExibirListagemVeiculos();
                        Console.ReadKey();
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        break;

                    case "4":
                        Console.Clear();
                        est.AdicionarCarroAleatorio();

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        est.LotarEstacionamento();

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.Clear();
                        est.EsvaziarEstacionamento();

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("--- SIMULAR HORÁRIO DE ENTRADA ---");
                        Console.Write("Digite a Placa do veículo: ");
                        string placaSimulada = Console.ReadLine();
                        Console.Write("Quantas horas no passado o veículo entrou? (ex: 3): ");
                        if (int.TryParse(Console.ReadLine(), out int horas))
                        {
                            est.SimularHorarioEntrada(placaSimulada, horas);
                        }
                        else
                        {
                            Console.WriteLine("Valor de horas inválido!");
                        }

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "8":
                        Console.Clear();
                        est.ExibirEstadoPonteiros();

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "0":
                        sair = true;
                        Console.WriteLine("\nSaindo do programa...");
                        break;

                    default:
                        Console.WriteLine("\nOpção desconhecida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}