namespace Questao5.Domain.Entities
{
    public class Idempotencia
    {
        public Idempotencia()
        {
            
        }
        public Idempotencia(string chaveIdempotencia, string requisicao)
        {
            ChaveIdempotencia = chaveIdempotencia;
            Requisicao = requisicao;
        }

        public string ChaveIdempotencia { get; set; }
        public string Requisicao { get; set; }
        public string Resultado { get; set; }
    }
}
