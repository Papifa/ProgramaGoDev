using System;

namespace Metadata
{
    public class PessoaViewModel
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string SalaEtapaUm { get; set; }
        public string SalaEtapaDois { get; set; }
        public DateTime CafeInicialEtapaUm { get; set; }
        public DateTime CafeFinalEtapaUm { get; set; }
        public DateTime CafeInicialEtapaDois { get; set; }
        public DateTime CafeFinalEtapaDois { get; set; }
    }
}
