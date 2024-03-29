using MediatR;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;

namespace Questao5.Application.Queries.GetSaldo
{
    public class GetSaldoQueryHandler : IRequestHandler<GetSaldoQuery, Saldo>
    {
        private readonly ISaldoRepository _repository;

        public GetSaldoQueryHandler(ISaldoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Saldo> Handle(GetSaldoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSaldoAsync(request.IdContaCorrente);
        }
    }
}
