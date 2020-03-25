using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogosGourmet.Models
{
    public class Resposta : EntidadeBase
    {
        public Resposta(Guid usuarioId, List<Questao> questoes)
        {
            UsuarioId = usuarioId;
            Questoes = questoes;
        }

        public Guid UsuarioId { get; set; }
        public List<Questao> Questoes { get; set; }
    }
}
