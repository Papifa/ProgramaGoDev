using DAL;
using Metadata;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL
{
    public class PessoaBLL
    {
        PessoaDAL dal = new PessoaDAL();

        #region Trazer pessoas
        public List<Pessoa> TrazerPessoas()
        {
            return dal.TrazerPessoas();
        }
        #endregion

        #region Cadastrar
        public MessageResponse Cadastrar(Pessoa pessoa)
        {
            MessageResponse response = new MessageResponse();
            List<string> erros = new List<string>();

            #region Nome
            if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                erros.Add("Nome deve ser informado.");
            }
            else
            {
                pessoa.Nome = Regex.Replace(pessoa.Nome, " {2,}", " ");
                pessoa.Nome = pessoa.Nome.Trim();
                if (pessoa.Nome.Length < 3 || pessoa.Nome.Length > 60)
                {
                    erros.Add("Nome deve conter entre 3 e 60 caracteres.");
                }
                else
                {
                    for (int i = 0; i < pessoa.Nome.Length; i++)
                    {
                        if (!char.IsLetter(pessoa.Nome[i]) && pessoa.Nome[i] != ' ')
                        {
                            erros.Add("Nome inválido");
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Sobrenome
            if (string.IsNullOrWhiteSpace(pessoa.Sobrenome))
            {
                erros.Add("Sobrenome deve ser informado.");
            }
            else
            {
                pessoa.Sobrenome = Regex.Replace(pessoa.Sobrenome, " {2,}", " ");
                pessoa.Sobrenome = pessoa.Sobrenome.Trim();
                if (pessoa.Sobrenome.Length < 3 || pessoa.Sobrenome.Length > 60)
                {
                    erros.Add("Sobrenome deve conter entre 3 e 60 caracteres.");
                }
                else
                {
                    for (int i = 0; i < pessoa.Sobrenome.Length; i++)
                    {
                        if (!char.IsLetter(pessoa.Sobrenome[i]) && pessoa.Sobrenome[i] != ' ')
                        {
                            erros.Add("Sobrenome inválido");
                            break;
                        }
                    }
                }
            }
            #endregion

            StringBuilder errosPessoa = new StringBuilder();

            if (erros.Count != 0)
            {
                for (int i = 0; i < erros.Count; i++)
                {
                    errosPessoa.AppendLine(erros[i].ToString());
                }
                response.Success = false;
                response.Message = errosPessoa.ToString();
                return response;
            }
            response = dal.Cadastrar(pessoa);
            response.Message = "Cadastrado com sucesso!";
            return response;
        }
        #endregion

        #region Excluir
        public MessageResponse Excluir(long idPessoa)
        {
            return dal.Excluir(idPessoa);
        }
        #endregion

        #region Atualizar
        public MessageResponse Atualizar(Pessoa pessoa)
        {
            return dal.Atualizar(pessoa);
        }
        #endregion

        #region Ler por ID
        public List<Pessoa> LerPorID(long id)
        {
            return dal.LerPorID(id);
        }
        #endregion
    }
}
