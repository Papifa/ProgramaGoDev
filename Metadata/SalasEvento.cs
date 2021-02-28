namespace Metadata
{
    public class SalasEvento
    {
        public SalasEvento(string nome, int lotacao)
        {
            Nome = nome;
            Lotacao = lotacao;
        }

        public SalasEvento(long id, string nome, int lotacao)
        {
            ID = id;
            Nome = nome;
            Lotacao = lotacao;
        }

        public long ID { get; set; }
        public string Nome { get; set; }
        public int Lotacao { get; set; }
    }
}
