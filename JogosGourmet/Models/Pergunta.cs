using System;
using System.Collections.Generic;
using System.Linq;
using static JogosGourmet.Common.Enum;

namespace JogosGourmet.Models
{
    public class Pergunta : EntidadeBase
    {
        public Pergunta()
        {

        }

        public Pergunta(string enunciado, List<RespostaType> formatacaoPergunta, Guid respostaId, RespostaType respostaType = RespostaType.Indefinido)
        {
            Enunciado = enunciado;
            FormatacaoPergunta = formatacaoPergunta;
            RespostaType = respostaType;
            RespostaId = respostaId;
        }

        public string Enunciado { get; set; }

        public List<RespostaType> FormatacaoPergunta { get; private set; }

        public RespostaType RespostaType { get; private set; }

        public Guid RespostaId { get; set; }

    }
}
