using MediatR;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;

namespace Questao5.Application.Commands.CreateMovimento
{
    public class CreateMovimentoCommandHandler : IRequestHandler<CreateMovimentoCommand, string>
    {
        private readonly IMovimentoRepository _movimentoRepository;

        public CreateMovimentoCommandHandler(IMovimentoRepository movimentoRepository)
        {
            _movimentoRepository = movimentoRepository;
        }
        public async Task<string> Handle(CreateMovimentoCommand request, CancellationToken cancellationToken)
        {
            var movimento = new Movimento(request.IdMovimento, request.IdContaCorrente, request.TipoMovimento, request.Valor);

            await _movimentoRepository.AddMovimentoAsync(movimento);

            return movimento.IdMovimento;
        }
    }
}
