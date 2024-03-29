using MediatR;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;

namespace Questao5.Application.Commands.AddIdempotencia
{
    public class AddIdempotenciaCommandHandler : IRequestHandler<AddIdempotenciaCommand, string>
    {
        private readonly IIdempotenciaRepository _idempotenciaRepository;

        public AddIdempotenciaCommandHandler(IIdempotenciaRepository idempotenciaRepository)
        {
            _idempotenciaRepository = idempotenciaRepository;
        }
        public async Task<string> Handle(AddIdempotenciaCommand request, CancellationToken cancellationToken)
        {
            var idempotencia = new Idempotencia(request.ChaveIdempotencia, request.Requisicao);

            var obj = await _idempotenciaRepository.AddIdempotenciaAsync(idempotencia);

            return obj;
        }
    }
}
