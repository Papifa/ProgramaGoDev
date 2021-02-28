using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class PessoaDAL
    {
        #region Trazer pessoas
        public List<Pessoa> TrazerPessoas()
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from pessoas";

            command.Connection = connection;

            List<Pessoa> pessoas = new List<Pessoa>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NOME"]);
                    string sobrenome = Convert.ToString(reader["SOBRENOME"]);

                    Pessoa ps = new Pessoa(id, nome, sobrenome);
                    pessoas.Add(ps);
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

            return pessoas;
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(Pessoa p)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "insert into pessoas (nome, sobrenome) values (@nome, @sobrenome)";
            command.Parameters.AddWithValue("@nome", p.Nome);
            command.Parameters.AddWithValue("@sobrenome", p.Sobrenome);
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
        public MessageResponse Excluir(long idPessoa)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "delete from pessoas where id = @id";
            command.Parameters.AddWithValue("@id", idPessoa);

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
        public MessageResponse Atualizar(Pessoa pessoa)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "update pessoas set nome = @nome, sobrenome = @sobrenome where id = @id";
            command.Parameters.AddWithValue("@id", pessoa.ID);
            command.Parameters.AddWithValue("@nome", pessoa.Nome);
            command.Parameters.AddWithValue("@sobrenome", pessoa.Sobrenome);
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
            response.Message = "Atualizado com sucesso.";
            return response;
        }
        #endregion

        #region Ler Por ID
        public List<Pessoa> LerPorID(long id)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from pessoas where id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;

            List<Pessoa> pessoas = new List<Pessoa>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NOME"]);
                    string sobrenome = Convert.ToString(reader["SOBRENOME"]);

                    pessoas.Add(new Pessoa(id, nome, sobrenome));
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
            return pessoas;
        }
        #endregion
    }
}
