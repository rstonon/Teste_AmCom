using MediatR;
using Questao5.Application.Queries.GetIdempotente;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;

namespace Questao5.Application.Queries.GetIdempotencia
{
    public class GetIdempotenciaQueryHandler : IRequestHandler<GetIdempotenciaQuery, Idempotencia>
    {
        private readonly IIdempotenciaRepository _repository;

        public GetIdempotenciaQueryHandler(IIdempotenciaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Idempotencia> Handle(GetIdempotenciaQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.GetIdempotenciaAsync(request.IdMovimento);

            return resultado;
        }
    }
}
