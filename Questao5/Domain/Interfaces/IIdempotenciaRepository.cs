using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories
{
    public interface IIdempotenciaRepository
    {
        Task<Idempotencia> GetIdempotenciaAsync(string idMovimento);
        Task<string> AddIdempotenciaAsync(Idempotencia idempotencia);
    }
}
