using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Questao5.Infrastructure.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace Questao5.Infrastructure.Persistence
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public MovimentoRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public async Task<string> AddMovimentoAsync(Movimento movimento)
        {
            var query = $@"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) " +
                                         "VALUES (@idmovimento, @idcontacorrente, @datamovimento, @tipomovimento, @valor) returning idmovimento;";

            var param = new
            {
                @idmovimento = movimento.IdMovimento,
                @idcontacorrente = movimento.IdContaCorrente,
                @datamovimento = DateTime.Now.ToString("yyyy-MM-dd"),
                @tipomovimento = movimento.TipoMovimento,
                @valor = movimento.Valor,
            };

            using (var sqliteConnection = new SqliteConnection(_databaseConfig.Name))
            {
                sqliteConnection.Open();
                //await sqliteConnection.ExecuteAsync(query, parametros);
                var id =  await sqliteConnection.QuerySingleOrDefaultAsync<string>(query, param);

                return id;

            }
        }
    }
}
