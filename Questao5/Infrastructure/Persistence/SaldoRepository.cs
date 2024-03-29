using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Persistence
{
    public class SaldoRepository : ISaldoRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public SaldoRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public async Task<Saldo> GetSaldoAsync(string idContaCorrente)
        {
            using (var sqliteConnection = new SqliteConnection(_databaseConfig.Name))
            {
                sqliteConnection.Open();

                var query = "SELECT c.numero, c.nome, IFNULL((SELECT IFNULL(SUM(valor), 0) FROM movimento WHERE idcontacorrente = m.idcontacorrente AND tipomovimento = 'C') - (SELECT IFNULL(SUM(valor), 0) FROM movimento WHERE idcontacorrente = m.idcontacorrente AND tipomovimento = 'D'), 0) as valor FROM contacorrente c LEFT JOIN movimento m ON c.idcontacorrente = m.idcontacorrente WHERE c.idContaCorrente = @idContaCorrente GROUP BY c.idcontacorrente";

                var parametros = new DynamicParameters();
                parametros.Add("@idContaCorrente", idContaCorrente);

                var obj = await sqliteConnection.QueryFirstOrDefaultAsync<Saldo>(query, parametros);

                obj.Data = DateTime.Now;

                return obj;
            }
        }
    }
}
