namespace Metadata
{
    public class Pessoa
    {
        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public Pessoa(long id, string nome, string sobrenome)
        {
            ID = id;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public Pessoa(string nome, string sobrenome, long salaEtapaUm, long salaEtapaDois, long espacoCafeEtapaUm, long espacoCafeEtapaDois)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            SalaEtapaUm = salaEtapaUm;
            SalaEtapaDois = salaEtapaDois;
            EspacoCafeEtapaUm = espacoCafeEtapaUm;
            EspacoCafeEtapaDois = espacoCafeEtapaDois;
        }

        public long ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public long SalaEtapaUm { get; set; }
        public long SalaEtapaDois { get; set; }
        public long EspacoCafeEtapaUm { get; set; }
        public long EspacoCafeEtapaDois { get; set; }
    }
}
