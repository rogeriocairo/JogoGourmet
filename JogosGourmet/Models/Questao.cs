using System;
using System.Collections.Generic;

namespace JogosGourmet.Models
{
    public class Questao : EntidadeBase
    {

        public Questao()
        {

        }

        public Questao(int pergunta, string texto             )
        {
            Pergunta = pergunta;
            Texto = texto;            
            
            //RespostaPositiva = respostaPositiva;
            //RespostaNegativa = respotaNegativa;
        }

        public int Pergunta { get; private set; }

        public string Texto { get; private set; }

        public string BotaoOK { get; set; }

        public string BotaoSim { get; set; }

        public string BotaoNao { get; set; }

        public int? RespostaPositiva { get; private set; }

        public int? RespostaNegativa { get; private set; }

        //public int Ordem { get; private set; }

        //public List<Common.Enum.RespostaType> TipoResposta { get; private set; }
    }

}
