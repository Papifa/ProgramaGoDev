namespace Metadata
{
    public class Ocupacao
    {
        public Ocupacao(long pessoa, long sala, long espacoCafe)
        {
            Pessoa = pessoa;
            Sala = sala;
            EspacoCafe = espacoCafe;
        }

        public Ocupacao(long id, long idPessoa, string nomePessoa, long idEspacoCafe, string horario)
        {
            ID = id;
            Pessoa = idPessoa;
            NomePessoa = nomePessoa;
            EspacoCafe = idEspacoCafe;
            Horario = horario;
        }

        public long ID { get; set; }
        public long Pessoa { get; set; }
        public string NomePessoa { get; set; }
        public long Sala { get; set; }
        public long EspacoCafe { get; set; }
        public string Horario { get; set; }
    }
}
