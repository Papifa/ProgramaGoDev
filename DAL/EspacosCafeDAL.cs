using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class EspacosCafeDAL
    {
        #region Trazer espaços de café
        public List<EspacosCafe> TrazerEspacosCafe()
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = @"select * from espacos";

            command.Connection = connection;

            List<EspacosCafe> espacos = new List<EspacosCafe>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    long id = Convert.ToInt64(reader["ID"]);
                    int lotacao = Convert.ToInt32(reader["LOTACAO"]);
                    DateTime horaInicial = Convert.ToDateTime(reader["HORAINICIAL"]);
                    DateTime horaFinal = Convert.ToDateTime(reader["HORAFINAL"]);

                    EspacosCafe es = new EspacosCafe(id, lotacao, horaInicial, horaFinal);
                    espacos.Add(es);
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

            return espacos;
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(EspacosCafe esp)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "insert into espacos (lotacao, horainicial, horafinal) values (@lotacao, @horainicial, @horafinal)";
            command.Parameters.AddWithValue("@lotacao", esp.Lotacao);
            command.Parameters.AddWithValue("@horainicial", esp.HoraInicial);
            command.Parameters.AddWithValue("@horafinal", esp.HoraFinal);
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
        public MessageResponse Excluir(long idEspaco)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "delete from espacos where id = @id";
            command.Parameters.AddWithValue("@id", idEspaco);

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
        public MessageResponse Atualizar(EspacosCafe espaco)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            MessageResponse response = new MessageResponse();

            command.CommandText = "update espacos set lotacao = @lotacao, horainicial = @horainicial, horafinal = @horafinal where id = @id";
            command.Parameters.AddWithValue("@id", espaco.ID);
            command.Parameters.AddWithValue("@lotacao", espaco.Lotacao);
            command.Parameters.AddWithValue("@horainicial", espaco.HoraInicial);
            command.Parameters.AddWithValue("@horafinal", espaco.HoraFinal);
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

        #region Trazer ocupações do espaço do café
        public List<Ocupacao> TrazerEspacoCafeOcupacoes(long idEspacoCafe)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            List<Ocupacao> ocupacoes = new List<Ocupacao>();

            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = @"select * from ocupacoes where espacocafe = @espacocafe";
            command.Parameters.AddWithValue("@espacocafe", idEspacoCafe);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    long id = Convert.ToInt64(reader["ID"]);
                    long pessoa = Convert.ToInt64(reader["PESSOA"]);
                    string nomePessoa = $"{Convert.ToString(reader["NOMEPESSOA"])}{Convert.ToString(reader["SOBRENOMEPESSOA"])}";
                    long espacoCafe = Convert.ToInt64(reader["ESPACOCAFE"]);
                    DateTime horaInicial = new DateTime(0, 0, 0, 0, 0, 0);
                    DateTime horaFinal = new DateTime(0, 0, 0, 0, 0, 0);

                    SqlConnection connection2 = new SqlConnection();
                    connection2.ConnectionString = connectionString;

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = @"select horainicial, horafinal from espacos where id = @id";
                    command2.Parameters.AddWithValue("@id", idEspacoCafe);

                    try
                    {
                        connection2.Open();
                        SqlDataReader reader2 = command2.ExecuteReader();

                        while (reader2.Read())
                        {
                            horaInicial = Convert.ToDateTime(reader2["HORAINICIAL"]);
                            horaFinal = Convert.ToDateTime(reader2["HORAFINAL"]);
                        }
                    }
                    catch
                    {
                        throw;
                    }

                    string horario = (horaInicial.Minute == 0 && horaInicial.Hour == 0 && horaFinal.Minute == 0 && horaFinal.Hour == 0) ? "Sem horário cadastrado." : $"Das {horaInicial.ToString("HH:mm")} às {horaFinal.ToString("HH:mm")}";

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

        #region Ler Por ID
        public List<EspacosCafe> LerPorID(long id)
        {
            string connectionString = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from espacos where id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;

            List<EspacosCafe> espacos = new List<EspacosCafe>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                    int lotacao = Convert.ToInt32(reader["LOTACAO"]);
                    DateTime horaInicial = Convert.ToDateTime(reader["HORAINICIAL"]);
                    DateTime horaFinal = Convert.ToDateTime(reader["HORAFINAL"]);

                    espacos.Add(new EspacosCafe(id, lotacao, horaInicial, horaFinal));
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
            return espacos;
        }
        #endregion
    }
}
