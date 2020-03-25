using System.Collections.Generic;
using static JogosGourmet.Common.Enum;

namespace JogosGourmet.Models
{
    public class Pergunta : EntidadeBase
    {
        public Pergunta(string enunciado, List<RespostaType> tipoResposta)
        {
            Enunciado = enunciado;
            TipoResposta = tipoResposta;
        }

        public void AtualizaListaQuestoes()
        {

        }

        public string Enunciado { get; private set; }

        public List<RespostaType> TipoResposta { get; private set; }

        public Questao QuestaoPos { get; private set; }

        public Questao QuestaoNeg { get; set; }
    }
}
