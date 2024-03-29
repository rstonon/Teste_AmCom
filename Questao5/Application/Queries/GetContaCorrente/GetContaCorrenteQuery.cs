using MediatR;
using Questao5.Domain.Entities;

namespace Questao5.Application.Queries.GetContaCorrente
{
    public class GetContaCorrenteQuery : IRequest<ContaCorrente>
    {

        public GetContaCorrenteQuery(string idContaCorrente)
        {
            IdContaCorrente = idContaCorrente;
        }
        public string IdContaCorrente { get; private set; }
    }
}
