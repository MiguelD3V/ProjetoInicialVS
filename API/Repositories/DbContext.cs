using System.Data.SqlClient;
using Dapper;

namespace ProjetoIniciaVs.API.Repositories
{
    public class DbContext
    {
        string connetionString = "Server=localhost; Database=HospitalDb;Integrated Security = true;Connect Timeout = 30;TrustServerCertificate=true;";
    }
}
