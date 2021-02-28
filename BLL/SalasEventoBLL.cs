using DAL;
using Metadata;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL
{
    public class SalasEventoBLL
    {
        SalasEventoDAL dal = new SalasEventoDAL();

        #region Trazer salas
        public List<SalasEvento> TrazerSalas()
        {
            return dal.TrazerSalas();
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(SalasEvento sala)
        {
            MessageResponse response = new MessageResponse();
            response = VerificarAtualizar(sala);
            if (response.Success)
            {
                response = dal.Cadastrar(sala);
                response.Message = "Cadastrado com sucesso!";
                return response;
            }
            return response;
        }
        #endregion

        #region Excluir
        public MessageResponse Excluir(long idSala)
        {
            return dal.Excluir(idSala);
        }
        #endregion

        #region Atualizar
        public MessageResponse Atualizar(SalasEvento sala)
        {
            MessageResponse response = new MessageResponse();
            response = VerificarAtualizar(sala);
            if (response.Success)
            {
                response = dal.Atualizar(sala);
                response.Message = "Atualizado com sucesso!";
                return response;
            }
            return response;
        }
        #endregion

        #region Método para verificar e inserir/atualizar
        private MessageResponse VerificarAtualizar(SalasEvento sala)
        {
            MessageResponse response = new MessageResponse();
            List<string> erros = new List<string>();

            #region Nome
            if (string.IsNullOrWhiteSpace(sala.Nome))
            {
                erros.Add("Nome deve ser informado.");
            }
            else
            {
                sala.Nome = Regex.Replace(sala.Nome, " {2,}", " ");
                sala.Nome = sala.Nome.Trim();
                if (sala.Nome.Length < 3 || sala.Nome.Length > 60)
                {
                    erros.Add("Nome deve conter entre 3 e 60 caracteres.");
                }
                else
                {
                    for (int i = 0; i < sala.Nome.Length; i++)
                    {
                        if (!char.IsLetter(sala.Nome[i]) && sala.Nome[i] != ' ')
                        {
                            erros.Add("Nome inválido");
                            break;
                        }
                    }
                }
            }
            #endregion

            StringBuilder errosSala = new StringBuilder();

            if (erros.Count != 0)
            {
                for (int i = 0; i < erros.Count; i++)
                {
                    errosSala.AppendLine(erros[i].ToString());
                }
                response.Success = false;
                response.Message = errosSala.ToString();
                return response;
            }
            response.Success = true;
            return response;
        }
        #endregion

        #region Ler por ID
        public List<SalasEvento> LerPorID(long id)
        {
            return dal.LerPorID(id);
        }
        #endregion
    }
}
