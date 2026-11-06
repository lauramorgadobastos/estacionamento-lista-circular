using System.Runtime.CompilerServices;
using System.Timers;
using Estacionamento.Models;    


namespace Estacionamento.Services
{
    class Estacionamento // Estreito com apenas 8 vagas 
    {
        private Elemento Inicio;
        private Elemento Fim;

        private int qtdeCarros;

        public Estacionamento()
        {
            Inicio = null;
            Fim = null;
            qtdeCarros = 0;
        }

        public void EntradaNovoVeiculo(string placa, string nome, string marca)
        {

            if (qtdeCarros == 8)
            {
                Console.WriteLine("O estacionamento de veículos atingiu a capacidade máxima!!");
                Console.ReadKey();
                return;
            }

            Elemento Novo = new Elemento();
            Novo.Veic = new Veiculo(placa, nome, marca);
            int[] Entrada = new int[3];

            if (Inicio == null)
            {
                Inicio = Novo;
                Fim = Novo;
                Fim.Prox = Inicio;
                Entrada = Novo.Veic.HoraEntradaVeiculo();
                qtdeCarros++;

                Console.WriteLine($"O veículo entrou no estacionamento em {Entrada[0]:D2}:{Entrada[1]:D2}:{Entrada[2]:D2}");
            }
            else // Entra apenas no Inicio (Entrada)
            {
                Novo.Prox = Inicio;
                Inicio = Novo;
                Fim.Prox = Inicio;
                Entrada = Novo.Veic.HoraEntradaVeiculo();
                qtdeCarros++;
                Console.WriteLine($"O veículo entrou no estacionamento em {Entrada[0]:D2}:{Entrada[1]:D2}:{Entrada[2]:D2}");
            }
        }

        public void SaidaNovoVeiculoPorPlaca(string placaProcurada)
        {
            if (qtdeCarros == 0)
            {
                Console.WriteLine("Não há carros no estacionamento!");
                return;
            }

            int tentativas = 0;
            bool encontrado = false;

            // Simula a manobra: roda os carros até o veículo procurado chegar na saída (Fim)
            while (tentativas < qtdeCarros)
            {
                if (Fim.Veic.Placa == placaProcurada)
                {
                    encontrado = true;
                    break;
                }

                Console.WriteLine($"-> Carro de placa {Fim.Veic.Placa} ({Fim.Veic.Nome}) saiu para dar espaço e entrou no final da fila.");
                // Gira a lista (o carro que sai do fim é reinserido na entrada)
                Inicio = Inicio.Prox;
                Fim = Fim.Prox;
                tentativas++;
            }

            if (!encontrado)
            {
                Console.WriteLine("Veículo com a placa informada não foi encontrado no estacionamento!");
                return;
            }

            // AGORA O VEÍCULO ESTÁ NA SAÍDA (FIM).
            int[] Entrada = Fim.Veic.horaEnt;
            int[] Saida = Fim.Veic.HoraSaidaVeiculo(); // Grava a saída no veículo CORRETO

            // Remove o veículo efetivamente da estrutura circular
            if (qtdeCarros == 1)
            {
                Inicio = null;
                Fim = null;
            }
            else
            {
                Elemento Aux = Inicio;
                while (Aux.Prox != Fim)
                {
                    Aux = Aux.Prox;
                }
                Fim = Aux;
                Fim.Prox = Inicio;
            }

            qtdeCarros--;

            Console.WriteLine($"\nO horário de saída do veículo foi {Saida[0]:D2}:{Saida[1]:D2}:{Saida[2]:D2}.");
            Console.WriteLine($"Veículo de placa {placaProcurada} saiu com sucesso!");

            // Calcula o valor do estacionamento
            ValorEstacionamento(Entrada, Saida);

            if (tentativas > 0)
            {
                Console.WriteLine($"\n{tentativas} veículo(s) que estavam na frente foram manobrados para a rua e retornaram para suas vagas.");
            }

        }
        public void ValorEstacionamento(int[] entrada, int[] saida)
        {
            // Converte os arrays de inteiros em TimeSpan 
            TimeSpan horaEntrada = new TimeSpan(entrada[0], entrada[1], entrada[2]);
            TimeSpan horaSaida = new TimeSpan(saida[0], saida[1], saida[2]);

            TimeSpan diferenca = horaSaida - horaEntrada;

            if (diferenca.TotalHours < 0) // Se passar da meia-noite 
            {
                diferenca = diferenca.Add(new TimeSpan(24, 0, 0));
            }

            double totalHoras = diferenca.TotalHours;

            int horasCobradas = (int)Math.Ceiling(totalHoras); // Math.Ceiling arredonda SEMPRE para cima (ex: 2.1 horas vira 3 horas)

            if (horasCobradas == 0)
            {
                horasCobradas = 1; // Garante o mínimo de 1 hora caso tenha ficado poucos segundos
            }

            decimal valorTotal = horasCobradas * 12.00m;

            Console.WriteLine($"Tempo total permanecido: {diferenca.Hours}h {diferenca.Minutes}m {diferenca.Seconds}s");
            Console.WriteLine($"Total de horas cobradas (fração conta como inteira): {horasCobradas}h");
            Console.WriteLine($"Valor a pagar: R$ {valorTotal:F2}");
            Console.ReadKey();
        }


        public void ExibirListagemVeiculos()
        {
            if (qtdeCarros == 0) // Estacionamento Vazio
            {
                Console.WriteLine("Não há carros no estacionamento!");
                return;
            }

            Elemento Aux = new Elemento();

            Aux = Inicio;

            Console.WriteLine($"Estacionamento Vagas {qtdeCarros}/8");
            Console.WriteLine("Os veiculos que estão no Estacionamento são: ");
            for (int i = 0; i < qtdeCarros; i++)
            {
                Console.WriteLine($"Vaga {i + 1}: | Nome: {Aux.Veic.Nome} | Placa: {Aux.Veic.Placa} | Marca: {Aux.Veic.Marca} | Horário Entrada: {Aux.Veic.horaEnt[0]:D2}:{Aux.Veic.horaEnt[1]:D2}:{Aux.Veic.horaEnt[2]:D2} | ");
                Aux = Aux.Prox;
            }

        }

        public void EsvaziarEstacionamento()
        {
            if (qtdeCarros == 0)
            {
                Console.WriteLine("O estacionamento já está vazio!");
                return;
            }

            while (qtdeCarros > 0)
            {
                // Sempre remove o carro que está na saída (Fim) do corredor estreito
                Console.WriteLine($"\nRetirando próximo veículo da fila (Placa: {Fim.Veic.Placa})...");
                SaidaNovoVeiculoPorPlaca(Fim.Veic.Placa);
                Console.WriteLine(new string('-', 30));
            }

            Console.WriteLine("Todos os veículos foram retirados com sucesso!");
        }

        public void AdicionarCarroAleatorio()
        {
            string[] marcas = { "Fiat", "Chevrolet", "Ford", "Toyota", "Honda", "Hyundai", "Volkswagen" };
            string[] modelos = { "Uno", "Onix", "Fiesta", "Corolla", "Civic", "HB20", "Gol" };
            string[] letras = { "ABC", "XYZ", "BRA", "JKL", "MNO" };

            Random rand = new Random();
            string marcaAleatoria = marcas[rand.Next(marcas.Length)];
            string nomeAleatorio = modelos[rand.Next(modelos.Length)];
            string placaAleatoria = $"{letras[rand.Next(letras.Length)]}{rand.Next(1000, 9999)}";

            Console.WriteLine("Gerando veículo aleatório...");
            EntradaNovoVeiculo(placaAleatoria, nomeAleatorio, marcaAleatoria); // Chama o método para registrar a entrada
        }

        public void LotarEstacionamento()
        {
            if (qtdeCarros == 8)
            {
                Console.WriteLine("O estacionamento já está lotado!");
                return;
            }

            Console.WriteLine("Preenchendo vagas restantes com veículos aleatórios...");
            while (qtdeCarros < 8)
            {
                AdicionarCarroAleatorio();
            }
            Console.WriteLine("\nEstacionamento lotado com sucesso para testes!");
        }

        public void SimularHorarioEntrada(string placaProcurada, int horasAtras)
        {
            if (qtdeCarros == 0)
            {
                Console.WriteLine("Não há carros no estacionamento!");
                return;
            }

            Elemento Aux = Inicio;
            bool encontrado = false;

            for (int i = 0; i < qtdeCarros; i++)
            {
                if (Aux.Veic.Placa == placaProcurada)
                {
                    DateTime horaSimulada = DateTime.Now.AddHours(-horasAtras);
                    Aux.Veic.horaEnt[0] = horaSimulada.Hour;
                    Aux.Veic.horaEnt[1] = horaSimulada.Minute;
                    Aux.Veic.horaEnt[2] = horaSimulada.Second;
                    encontrado = true;
                    Console.WriteLine($"Horário de entrada da placa {placaProcurada} alterado com sucesso!");
                    Console.WriteLine($"Novo horário registrado: {Aux.Veic.horaEnt[0]:D2}:{Aux.Veic.horaEnt[1]:D2}:{Aux.Veic.horaEnt[2]:D2} ({horasAtras}h atrás)");
                    break;
                }
                Aux = Aux.Prox;
            }

            if (!encontrado)
            {
                Console.WriteLine("Veículo não encontrado!");
            }
        }
        public void ExibirEstadoPonteiros()
        {
            if (qtdeCarros == 0)
            {
                Console.WriteLine("O estacionamento está totalmente vazio!");
                return;
            }

            Console.WriteLine($"--- VISUALIZAÇÃO DE PONTEIROS (Total: {qtdeCarros}/8) ---");
            Elemento Aux = Inicio;

            for (int i = 0; i < qtdeCarros; i++)
            {
                string papelPonteiro = "";
                if (Aux == Inicio && Aux == Fim) papelPonteiro = " <--- [INÍCIO e FIM]";
                else if (Aux == Inicio) papelPonteiro = " <--- [INÍCIO / ENTRADA]";
                else if (Aux == Fim) papelPonteiro = " <--- [FIM / SAÍDA]";

                Console.WriteLine($"Vaga {i + 1}: [Placa: {Aux.Veic.Placa} | Modelo: {Aux.Veic.Nome}]{papelPonteiro}");
                Aux = Aux.Prox;
            }

            Console.WriteLine($"\nValidação da estrutura circular: Fim.Prox aponta para a placa {Fim.Prox.Veic.Placa} (Início)");
        }
    }
}