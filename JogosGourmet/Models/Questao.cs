using System;
using System.Collections.Generic;

namespace JogosGourmet.Models
{
    public class Questao : EntidadeBase
    {

        public Questao()
        {

        }

        public Questao(int pergunta, string texto
            //List<Common.Enum.RespostaType> tipoResposta
            //,
            //int ordem,
            //int? respostaPositiva = null,
            //int? respotaNegativa = null
            )
        {
            Pergunta = pergunta;
            Texto = texto;
            // Resposta = resposta;
            //Ordem = ordem;
            //TipoResposta = tipoResposta;
            //RespostaPositiva = respostaPositiva;
            //RespostaNegativa = respotaNegativa;
        }

        public int Pergunta { get; private set; }

        public string Texto { get; private set; }

        //public string Resposta { get; private set; }

        public int? RespostaPositiva { get; private set; }

        public int? RespostaNegativa { get; private set; }

        //public int Ordem { get; private set; }

        //public List<Common.Enum.RespostaType> TipoResposta { get; private set; }
    }

}
