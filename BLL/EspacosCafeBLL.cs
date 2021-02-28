using DAL;
using Metadata;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class EspacosCafeBLL
    {
        EspacosCafeDAL dal = new EspacosCafeDAL();

        #region Trazer espaços de café
        public List<EspacosCafe> TrazerEspacos()
        {
            return dal.TrazerEspacosCafe();
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(EspacosCafe espaco)
        {
            MessageResponse response = new MessageResponse();
            response = VerificarAtualizar(espaco);
            if (response.Success)
            {
                response = dal.Cadastrar(espaco);
                response.Message = "Cadastrado com sucesso!";
                return response;
            }
            return response;
        }
        #endregion

        #region Excluir
        public MessageResponse Excluir(long idEspaco)
        {
            return dal.Excluir(idEspaco);
        }
        #endregion

        #region Atualizar
        public MessageResponse Atualizar(EspacosCafe espaco)
        {
            MessageResponse response = new MessageResponse();
            response = VerificarAtualizar(espaco);
            if (response.Success)
            {
                response = dal.Atualizar(espaco);
                response.Message = "Atualizado com sucesso!";
                return response;
            }
            return response;
        }
        #endregion

        #region Método para verificar e inserir/atualizar
        private MessageResponse VerificarAtualizar(EspacosCafe espaco)
        {
            MessageResponse response = new MessageResponse();
            List<string> erros = new List<string>();

            StringBuilder errosEspaco = new StringBuilder();

            if (erros.Count != 0)
            {
                for (int i = 0; i < erros.Count; i++)
                {
                    errosEspaco.AppendLine(erros[i].ToString());
                }
                response.Success = false;
                response.Message = errosEspaco.ToString();
                return response;
            }
            response.Success = true;
            return response;
        }
        #endregion

        #region Trazer ocupações do espaço do café
        public List<Ocupacao> TrazerEspacoCafeOcupacoes(long idEspacoCafe)
        {
            return dal.TrazerEspacoCafeOcupacoes(idEspacoCafe);
        }
        #endregion

        #region Ler por ID
        public List<EspacosCafe> LerPorID(long id)
        {
            return dal.LerPorID(id);
        }
        #endregion
    }
}
