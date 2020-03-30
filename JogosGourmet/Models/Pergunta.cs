using System;

namespace JogosGourmet.Models
{
    public class Pergunta : EntidadeBase
    {
        public Pergunta()
        {

        }

        public Pergunta(string enunciado, string formatacaoPergunta, Guid respostaId, string respostaType = "Indefinido")
        {
            Enunciado = enunciado;
            RespostaType = respostaType;
            RespostaId = respostaId;
            FormatacaoPergunta = formatacaoPergunta;
        }

        public Pergunta(Guid id,  string enunciado, string formatacaoPergunta, Guid respostaId, string respostaType = "Indefinido")
        {
            Id = id;
            Enunciado = enunciado;
            RespostaType = respostaType;
            RespostaId = respostaId;
            FormatacaoPergunta = formatacaoPergunta;
        }

        public string Enunciado { get; set; }

        public string FormatacaoPergunta { get; set; }

        public string RespostaType { get; set; }

        public Guid RespostaId { get; set; }

    }
}
