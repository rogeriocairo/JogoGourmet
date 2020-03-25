using System.Collections.Generic;

namespace JogosGourmet.Models
{
    public class Usuario : EntidadeBase
    {
        public Usuario(string nome)
        {
            Nome = nome;           
        }

        public string Nome { get; set; }      

    }
}

