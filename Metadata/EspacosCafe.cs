using System;
using System.Collections.Generic;

namespace Metadata
{
    public class EspacosCafe
    {
        public EspacosCafe(int lotacao, DateTime horaInicial, DateTime horaFinal)
        {
            Lotacao = lotacao;
            HoraInicial = horaInicial;
            HoraFinal = horaFinal;
        }

        public EspacosCafe(long id, int lotacao, DateTime horaInicial, DateTime horaFinal)
        {
            ID = id;
            Lotacao = lotacao;
            HoraInicial = horaInicial;
            HoraFinal = horaFinal;
        }

        public EspacosCafe(long id, int lotacao, DateTime horaInicial, DateTime horaFinal, List<Ocupacao> ocupacoes)
        {
            ID = id;
            Lotacao = lotacao;
            HoraInicial = horaInicial;
            HoraFinal = horaFinal;
            Ocupacoes = ocupacoes;
        }

        public long ID { get; set; }
        public int Lotacao { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public List<Ocupacao> Ocupacoes { get; set; }
    }
}
