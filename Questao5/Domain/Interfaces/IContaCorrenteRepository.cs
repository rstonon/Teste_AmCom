using Questao5.Application.ViewModels;
using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> GetContaCorrenteAsync(string idContaCorrente);
    }
}
