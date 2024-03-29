using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.ViewModels;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Persistence
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public ContaCorrenteRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public async Task<ContaCorrente> GetContaCorrenteAsync(string idContaCorrente)
        {
            using (var sqliteConnection = new SqliteConnection(_databaseConfig.Name))
            {
                sqliteConnection.Open();

                var query = "SELECT * FROM contacorrente c WHERE c.idContaCorrente = @idContaCorrente";

                var parametros = new
                {
                    idContaCorrente
                };

                var obj = await sqliteConnection.QueryFirstOrDefaultAsync<ContaCorrente>(query, parametros);

                return obj;
            }
        }
    }
}
