using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class SalasEventoDAL
    {
        #region Trazer salas
        public List<SalasEvento> TrazerSalas()
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = @"select * from salas";

            command.Connection = connection;

            List<SalasEvento> salas = new List<SalasEvento>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NOME"]);
                    int lotacao = Convert.ToInt32(reader["LOTACAO"]);

                    salas.Add(new SalasEvento(id, nome, lotacao));
                }
            }
            catch 
            {
                throw;
            }
            finally
            {
                connection.Dispose();
            }

            return salas;
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(SalasEvento se)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "insert into salas (nome, lotacao) values (@nome, @lotacao)";
            command.Parameters.AddWithValue("@nome", se.Nome);
            command.Parameters.AddWithValue("@lotacao", se.Lotacao);
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Ocorreu um erro ao realizar a requisição solicitada. Erro: {ex.Message}";
                return response;
            }
            finally
            {
                connection.Dispose();
            }

            response.Success = true;
            response.Message = "Cadastrado com sucesso.";
            return response;
        }
        #endregion

        #region Excluir
        public MessageResponse Excluir(long idSala)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "delete from salas where id = @id";
            command.Parameters.AddWithValue("@id", idSala);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Ocorreu um erro ao realizar a requisição solicitada. Erro: {ex.Message}";
                return response;
            }
            finally
            {
                connection.Dispose();
            }

            response.Success = true;
            response.Message = "Excluído com sucesso.";
            return response;
        }
        #endregion

        #region Atualizar
        public MessageResponse Atualizar(SalasEvento sala)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "update salas set nome = @nome, lotacao = @lotacao where id = @id";
            command.Parameters.AddWithValue("@id", sala.ID);
            command.Parameters.AddWithValue("@nome", sala.Nome);
            command.Parameters.AddWithValue("@lotacao", sala.Lotacao);
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Ocorreu um erro ao realizar a requisição solicitada. Erro: {ex.Message}";
                return response;
            }
            finally
            {
                connection.Dispose();
            }

            response.Success = true;
            response.Message = "Excluído com sucesso.";
            return response;
        }
        #endregion

        #region Ler Por ID
        public List<SalasEvento> LerPorID(long id)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from salas where id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;

            List<SalasEvento> salas = new List<SalasEvento>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NOME"]);
                    int lotacao = Convert.ToInt32(reader["LOTACAO"]);

                    salas.Add(new SalasEvento(id, nome, lotacao));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Dispose();
            }
            return salas;
        }
        #endregion
    }
}
