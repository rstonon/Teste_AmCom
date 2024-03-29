using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.ViewModels;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Persistence
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public IdempotenciaRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<string> AddIdempotenciaAsync(Idempotencia idempotencia)
        {
            var query = $@"INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) " +
                                         "VALUES (@chave_idempotencia, @requisicao, @resultado) returning resultado;";

            var param = new
            {
                @chave_idempotencia = idempotencia.ChaveIdempotencia,
                @requisicao = idempotencia.Requisicao,
                @resultado = DateTime.Now,
            };

            using (var sqliteConnection = new SqliteConnection(_databaseConfig.Name))
            {
                sqliteConnection.Open();
                //await sqliteConnection.ExecuteAsync(query, parametros);
                var resultado = await sqliteConnection.QuerySingleOrDefaultAsync<string>(query, param);

                return resultado;

            }
        }

        public async Task<Idempotencia> GetIdempotenciaAsync(string idMovimento)
        {
            using (var sqliteConnection = new SqliteConnection(_databaseConfig.Name))
            {
                sqliteConnection.Open();

                var query = "SELECT * FROM idempotencia WHERE chave_idempotencia = @idMovimento";

                var parametros = new
                {
                    idMovimento
                };

                var obj = await sqliteConnection.QueryFirstOrDefaultAsync<Idempotencia>(query, parametros);

                return obj;
            }
        }
    }
}
