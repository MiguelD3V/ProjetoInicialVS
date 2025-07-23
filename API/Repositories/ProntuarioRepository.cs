using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ProjetoIniciaVs.API.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {

        private readonly string _connectionString;
        private readonly ILogger<ProntuarioRepository> _logger;

        public ProntuarioRepository(string connectionString, ILogger<ProntuarioRepository> logger, IMapper mapper)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<ProntuarioResponseDto> CreateAsync(Prontuario prontuario)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                  
                    string query = @"INSERT INTO Prontuario (Descricao, PacienteId) VALUES (@Descricao, @PacienteId)
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int novoId = await connection.ExecuteScalarAsync<int>(query, prontuario);

                    string selectQuery = "SELECT * FROM Prontuario WHERE Id = @Id";

                    var prontuarioCriado = await connection.QueryFirstOrDefaultAsync<ProntuarioResponseDto>(selectQuery, new { Id = novoId });
                    _logger.LogInformation("Prontuario criado com sucesso: Id: {@Id},nome: {@Nome}, Paciente(ID):{PacinteId}", prontuarioCriado.Id, prontuarioCriado.Descricao,prontuarioCriado.PacienteId);

                    connection.Close();

                    return prontuarioCriado;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar prontuário");
                throw new Exception($"Ocorreu um erro ao criar os pacientes: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Prontuario WHERE Id = @Id";
                    await connection.ExecuteAsync(query, new { Id = id });
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao deletar o prontuario: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<ProntuarioResponseDto>> GetAllAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                string query = @" SELECT 
                p.Id,
                p.Descricao,
                p.PacienteId,
                pa.Nome AS NomePaciente
                FROM
                Prontuario AS p
                INNER JOIN
                Pacientes AS pa
                ON p.PacienteId = pa.Id
                ";

                var prontuarios = await connection.QueryAsync<ProntuarioResponseDto>(query);
                return prontuarios;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar os prontuários: {ex.Message}", ex);
            }
        }
        public async Task<ProntuarioResponseDto> GetByIdAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);

                string query = @"
                SELECT
                p.Id,
                p.Descricao,
                p.PacienteId,
                pa.Nome AS NomePaciente
                FROM
                Prontuario AS p
                INNER JOIN
                Pacientes AS pa
                ON p.PacienteId = pa.Id
                WHERE
                p.Id = @Id;
                ";

                var result = await connection.QueryFirstOrDefaultAsync<ProntuarioResponseDto>(query, new { Id = id });

                if (result == null)
                {
                    throw new Exception($"Prontuário com ID {id} não encontrado.");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar o prontuário: {ex.Message}", ex);
            }
        }
        public async Task<ProntuarioResponseDto> UpdateAsync(int id, Prontuario prontuario)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                string query = @"UPDATE Prontuario SET Descricao = @Descricao, PacienteId = @PacienteId WHERE Id = @id";

                await connection.ExecuteAsync(query, new
                {
                    prontuario.Descricao,
                    prontuario.PacienteId,
                    Id = id
                });

                string selectQuery = "SELECT * FROM Prontuario WHERE Id = @id";

                var prontuarioAtualizado = await connection.QueryFirstOrDefaultAsync<ProntuarioResponseDto>(selectQuery, new { Id = id });

                _logger.LogInformation("Paciente atualizado com sucesso: Id: {@id}, Descrição: {@Nome}, Paciente(ID): {@PacienteId}", prontuarioAtualizado.Id, prontuarioAtualizado.Descricao, prontuarioAtualizado.PacienteId);

                return prontuarioAtualizado;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar prontuário");
                throw new Exception("Erro ao atualizar prontuário", ex);

            }
        }
    }
}
