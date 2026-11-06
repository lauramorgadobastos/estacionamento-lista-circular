namespace Estacionamento.Models
{
    class Elemento
    {
        public Veiculo Veic;
        public Elemento Prox;

        public Elemento()
        {
            Veic = null;
            Prox = null;
        }
    }
}