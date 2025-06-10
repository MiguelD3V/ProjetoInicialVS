using Dapper;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;


namespace ProjetoIniciaVs.API.Repositories
{
    public class PacienteRepository
    {
        private readonly string _connectionString;
        public PacienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


    }
}
