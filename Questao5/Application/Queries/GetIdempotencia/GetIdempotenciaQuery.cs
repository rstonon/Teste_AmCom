using MediatR;
using Questao5.Domain.Entities;

namespace Questao5.Application.Queries.GetIdempotente
{
    public class GetIdempotenciaQuery : IRequest<Idempotencia>
    {

        public GetIdempotenciaQuery(string idMovimento)
        {
            IdMovimento = idMovimento;
        }
        public string IdMovimento { get; private set; }
    }
}
