using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class OcupacoesDAL
    {
        #region Trazer ocupações
        public List<Ocupacao> TrazerOcupacoes()
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            SqlConnection connection2 = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = @"select * from ocupacoes";

            command.Connection = connection;

            List<Ocupacao> ocupacoes = new List<Ocupacao>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    long id = Convert.ToInt64(reader["ID"]);
                    long pessoa = Convert.ToInt64(reader["PESSOA"]);
                    string nomePessoa = $"{Convert.ToString(reader["NOMEPESSOA"])}";
                    long espacoCafe = Convert.ToInt64(reader["ESPACOCAFE"]);
                    string horario = "Sem horário cadastrado.";

                    try
                    {
                        connection2.ConnectionString = connectionString;
                        SqlCommand command2 = new SqlCommand();
                        command2.CommandText = @"select horainicial, horafinal from espacos";
                        command2.Connection = connection2;

                        connection2.Open();
                        SqlDataReader reader2 = command2.ExecuteReader();

                        while (reader2.Read())
                        {
                            DateTime horaInicial = Convert.ToDateTime(reader2["HORAINICIAL"]);
                            DateTime horaFinal = Convert.ToDateTime(reader2["HORAFINAL"]);
                            horario = $"Das {horaInicial.ToString("HH:mm")} às {horaFinal.ToString("HH:mm")}";
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        connection2.Dispose();
                    }

                    ocupacoes.Add(new Ocupacao(id, pessoa, nomePessoa, espacoCafe, horario));
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

            return ocupacoes;
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(Ocupacao ocupacao)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "insert into ocupacoes (pessoa, nomepessoa, sala, espacocafe, horario) values (@pessoa, @nomepessoa, @sala, @espacocafe, @horario)";
            command.Parameters.AddWithValue("@pessoa", ocupacao.Pessoa);
            command.Parameters.AddWithValue("@nomepessoa", TrazerNomePessoaPorID(ocupacao.Pessoa));
            command.Parameters.AddWithValue("@sala", ocupacao.Sala);
            command.Parameters.AddWithValue("@espacocafe", ocupacao.EspacoCafe);
            command.Parameters.AddWithValue("@horario", TrazerHorarioEspacoCafePorID(ocupacao.EspacoCafe));
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
        public MessageResponse Excluir(long idOcupacao)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "delete from ocupacoes where id = @id";
            command.Parameters.AddWithValue("@id", idOcupacao);

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
        public MessageResponse Atualizar(Ocupacao ocupacao)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "update ocupacoes set pessoa = @pessoa, nomepessoa = @nomepessoa, sala = @sala, espacocafe = @espacocafe, horario = @horario where id = @id";
            command.Parameters.AddWithValue("@id", ocupacao.ID);
            command.Parameters.AddWithValue("@pessoa", ocupacao.Pessoa);
            command.Parameters.AddWithValue("@nomepessoa", ocupacao.NomePessoa);
            command.Parameters.AddWithValue("@sala", ocupacao.Sala);
            command.Parameters.AddWithValue("@espacocafe", ocupacao.EspacoCafe);
            command.Parameters.AddWithValue("@horario", ocupacao.Horario);
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

        #region Trazer nome da pessoa por ID
        private string TrazerNomePessoaPorID(long idPessoa)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            string nomePessoa = "";

            command.CommandText = "select nome, sobrenome from pessoas where id = @id";
            command.Parameters.AddWithValue("@id", idPessoa);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nomePessoa = $"{Convert.ToString(reader["NOME"])} {Convert.ToString(reader["SOBRENOME"])}";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Dispose();
            }

            return nomePessoa;
        }
        #endregion

        #region Trazer horário do espaço de café por ID
        private string TrazerHorarioEspacoCafePorID(long idEspacoCafe)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            string horario = "";

            command.CommandText = "select horainicial, horafinal from espacos where id = @id";
            command.Parameters.AddWithValue("@id", idEspacoCafe);
            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    horario = $"Das {Convert.ToDateTime(reader["HORAINICIAL"])} às {Convert.ToDateTime(reader["HORAFINAL"])}.";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Dispose();
            }

            return horario;
        }
        #endregion

        /// <summary>
        /// Se a sala cuja a ocupação está sendo cadastrada tiver 1 ocupação a mais que o resto, não permitir cadastrar
        /// </summary>
        /// <returns></returns>
        public bool VerificarDiferencaOcupacoes(long idSala)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = @"select id from salas where id not in (@id)";
            command.Parameters.AddWithValue("@id", idSala);

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    long idOutraSala = Convert.ToInt64(reader["ID"]);

                    SqlConnection connection2 = new SqlConnection();
                    connection2.ConnectionString = connectionString;

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = @"select count(id) from ocupacoes where sala = @id";
                    command2.Parameters.AddWithValue("@id", idOutraSala);

                    command2.Connection = connection2;

                    try
                    {
                        connection2.Open();
                        int outraSalaOcupacoes = Convert.ToInt32(command2.ExecuteScalar());
                        int salaAtualOcupacoes = TrazerNumeroOcupacoesSala(idSala);

                        if (salaAtualOcupacoes > outraSalaOcupacoes)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        connection2.Dispose();
                    }
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

            return true;
        }

        #region Trazer número de ocupações da sala por ID
        private int TrazerNumeroOcupacoesSala(long idSala)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            int contador = 0;

            SqlCommand command = new SqlCommand();
            command.CommandText = @"select count(id) from ocupacoes where sala = @id";
            command.Parameters.AddWithValue("@id", idSala);

            command.Connection = connection;

            try
            {
                connection.Open();
                contador = Convert.ToInt32(command.ExecuteScalar());
            }
            catch
            {
                throw;
            }

            return contador;
        }
        #endregion
    }
}
