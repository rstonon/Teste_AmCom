using MediatR;
using Questao5.Domain.Entities;

namespace Questao5.Application.Commands.AddIdempotencia
{
    public class AddIdempotenciaCommand : IRequest<string>
    {
        public AddIdempotenciaCommand(string chaveIdempotencia, string requisicao)
        {
            ChaveIdempotencia = chaveIdempotencia;
            Requisicao = requisicao;
        }

        public string ChaveIdempotencia { get; set; }
        public string Requisicao { get; set; }
        public string Resultado { get; set; }
    }
}
