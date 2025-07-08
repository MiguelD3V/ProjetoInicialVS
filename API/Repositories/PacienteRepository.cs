using Dapper;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Dtos.Requests;


namespace ProjetoIniciaVs.API.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<PacienteRepository> _Logger;

        public PacienteRepository(string connectionString, ILogger<PacienteRepository> logger)
        {
            _connectionString = connectionString;
            _Logger = logger;
        }

        public async Task<IEnumerable<PacienteResponseDto>> GetAllPacientesAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Pacientes";
                    return await connection.QueryAsync<PacienteResponseDto>(query);

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar os pacientes: {ex.Message}", ex);
            }
        }

        public async Task<PacienteResponseDto> GetPacienteByIdAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Pacientes WHERE Id = @Id";
                    return await connection.QueryFirstOrDefaultAsync<PacienteResponseDto>(query, new { Id = id });

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar o paciente: {ex.Message}", ex);
            }
        }
        public async Task<PacienteResponseDto> AddPacienteAsync(PacienteRequestDto paciente)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Pacientes (Nome, Idade, Logradouro, Numero, Email) 
                      VALUES (@Nome, @Idade, @Logradouro, @Numero, @Email);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);
                    ";
                    int novoId = await connection.ExecuteScalarAsync<int>(query, paciente);

                    string selectQuery = "SELECT * FROM Pacientes WHERE Id = @Id";

                    var pacienteCriado = await connection.QueryFirstOrDefaultAsync<PacienteResponseDto>(selectQuery, new { Id = novoId });
                    _Logger.LogInformation("Paciente criado com sucesso: Id: {@Id},nome: {@Nome}", pacienteCriado.Id, pacienteCriado.Nome);

                    return pacienteCriado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o paciente: {ex.Message}", ex);
            }
        }
        public async Task<PacienteResponseDto> UpdatePacienteAsync(PacienteRequestDto paciente, int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                string query = @"UPDATE Pacientes SET Nome = @Nome, Idade = @Idade, Logradouro = @Logradouro, Numero = @Numero, Email = @Email WHERE Id = @id
                ";
                
                await connection.ExecuteAsync(query, new
                {
                    paciente.Nome,
                    paciente.Idade,
                    paciente.Logradouro,
                    paciente.Numero,
                    paciente.Email,
                    Id = id
                });

                string selectQuery = "SELECT * FROM Pacientes WHERE Id = @id";

                var pacienteAtualizado = await connection.QueryFirstOrDefaultAsync<PacienteResponseDto>(selectQuery, new { Id = id});

                _Logger.LogInformation("Paciente atualizado com sucesso: Id: {@id}, Nome: {@Nome}", pacienteAtualizado.Id, pacienteAtualizado.Nome);

                return pacienteAtualizado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar o paciente: {ex.Message}", ex);
            }
        }
        public async Task DeletePacienteAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Pacientes WHERE Id = @Id";
                    await connection.ExecuteAsync(query, new { Id = id });
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao deletar o paciente: {ex.Message}", ex);
            }
        }
    }
}
