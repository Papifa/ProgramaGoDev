using DAL;
using Metadata;
using System.Collections.Generic;

namespace BLL
{
    public class OcupacoesBLL
    {
        OcupacoesDAL dal = new OcupacoesDAL();

        #region Trazer Ocupações
        public List<Ocupacao> TrazerOcupacoes()
        {
            return dal.TrazerOcupacoes();
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(Ocupacao ocupacao)
        {
            if (dal.VerificarDiferencaOcupacoes(ocupacao.Sala))
            {
                return dal.Cadastrar(ocupacao);
            }

            return new MessageResponse()
            {
                Message = "Não foi possível cadastrar esta ocupação pois esta sala possui pelo menos 1 ocupação que as outras.",
                Success = false
            };
        }
        #endregion

        #region Excluir
        public MessageResponse Excluir(long idOcupacao)
        {
            return dal.Excluir(idOcupacao);
        }
        #endregion

        #region Atualizar
        public MessageResponse Atualizar(Ocupacao ocupacao)
        {
            return dal.Atualizar(ocupacao);
        }
        #endregion
    }
}
