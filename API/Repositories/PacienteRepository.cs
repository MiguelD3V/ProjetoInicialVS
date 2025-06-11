using Dapper;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;


namespace ProjetoIniciaVs.API.Repositories
{
    public class PacienteRepository
    {
        private readonly string _connectionString;

        public PacienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<PacienteResponseDto>> GetAllPacientesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Pacientes";
                return await connection.QueryAsync<PacienteResponseDto>(query);
                connection.Close();
            }
        }

        public async Task<PacienteResponseDto> GetPacienteByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Pacientes WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<PacienteResponseDto>(query, new { Id = id });
                connection.Close();
            }
        }
        public async Task AddPacienteAsync(Paciente paciente)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Pacientes (Nome, Idade, Logradouro, Numero, Email) VALUES (@Nome, @Idade, @Numero, @Email)";
                    await connection.ExecuteAsync(query, paciente);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o paciente: {ex.Message}", ex);
            }
        }
        public async Task UpdatePacienteAsync(Paciente paciente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Pacientes SET Nome = @Nome, Idade = @Idade, Logradouro = @Logradouro, Numero = @Numero, Email = @Email WHERE Id = @Id";
                await connection.ExecuteAsync(query, paciente);
                connection.Close();
            }
        }
        public async Task DeletePacienteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Pacientes WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
                connection.Close();
            }
        }

    }
}
