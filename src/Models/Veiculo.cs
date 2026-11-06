namespace Estacionamento.Models
{
    class Veiculo
    {
        // Dados do veículo
        public string Placa;
        public string Nome { get; set; }
        public string Marca;
        private int[] _horaEnt = new int[3]; // Armazena hora, minuto e segundo
        public int[] horaEnt
        {
            get => _horaEnt;
        }

        private int[] _horaSai = new int[3]; // Armazena hora, minuto e segundo
        public int[] horaSai
        {
            get => _horaSai;
        }


        public Veiculo(string placaUsuario, string nomeUsuario, string marcaUsuario)
        {
            Placa = placaUsuario;
            Nome = nomeUsuario;
            Marca = marcaUsuario;
        }

        public int[] HoraEntradaVeiculo() // Cáculo o horário de entrada do veículo 
        {
            DateTime agora = DateTime.Now;
            _horaEnt[0] = agora.Hour;
            _horaEnt[1] = agora.Minute;
            _horaEnt[2] = agora.Second;

            return (_horaEnt);
        }

        public int[] HoraSaidaVeiculo() // Cáculo o horário de saída do veículo 
        {
            DateTime agora = DateTime.Now;
            _horaSai[0] = agora.Hour;
            _horaSai[1] = agora.Minute;
            _horaSai[2] = agora.Second;

            return (_horaSai);
        }
    }
}