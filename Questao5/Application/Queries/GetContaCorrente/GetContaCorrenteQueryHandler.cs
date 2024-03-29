using MediatR;
using Questao5.Application.ViewModels;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;

namespace Questao5.Application.Queries.GetContaCorrente
{
    public class GetContaCorrenteQueryHandler : IRequestHandler<GetContaCorrenteQuery, ContaCorrente>
    {
        private readonly IContaCorrenteRepository _repository;

        public GetContaCorrenteQueryHandler(IContaCorrenteRepository repository)
        {
            _repository = repository;
        }
        public async Task<ContaCorrente> Handle(GetContaCorrenteQuery request, CancellationToken cancellationToken)
        {
            var contaCorrente = await _repository.GetContaCorrenteAsync(request.IdContaCorrente);

            if (contaCorrente == null)
            {
                return null;
            }

            return contaCorrente;
        }
    }
}
