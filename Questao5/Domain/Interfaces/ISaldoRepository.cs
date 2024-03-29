using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories
{
    public interface ISaldoRepository
    {
        Task<Saldo> GetSaldoAsync(string idContaCorrente);
    }
}
