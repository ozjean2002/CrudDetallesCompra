using CrudDetallesCompra.Data.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDetallesCompra.Data.Servie
{
    public class GetReceipService : IGetReceipService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public GetReceipService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<GetReceip>> Get()
        {
            using (SqlConnection conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"SELECT * FROM dbo.Compras ";
                var resultCom = await conn.QueryAsync<GetReceip>(query);
                return resultCom.ToList();
            }
        }
        public async Task<GetReceip> GetId(int numeroCompra)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"SELECT * FROM dbo.Compras WHERE NumeroCompra = @NumeroCompra ";
                return await conn.QuerySingleAsync<GetReceip>(query, new { numeroCompra = numeroCompra });
            }
        }
    }
}
