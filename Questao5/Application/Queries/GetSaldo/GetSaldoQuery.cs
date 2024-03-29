using MediatR;
using Questao5.Domain.Entities;

namespace Questao5.Application.Queries.GetSaldo
{
    public class GetSaldoQuery : IRequest<Saldo>
    {

        public GetSaldoQuery(string idContaCorrente)
        {
            IdContaCorrente = idContaCorrente;
        }
        public string IdContaCorrente { get; private set; }
    }
}
