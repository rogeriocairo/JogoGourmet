using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JogosGourmet.Models;
using System.Collections.Generic;
using static JogosGourmet.Common.Enum;
using System.Linq;

namespace JogosGourmet.Controllers
{
    public class HomeController : Controller
    {
        private List<Questao> questoes = new List<Questao>();
        private List<Pergunta> perguntas = new List<Pergunta>();
        private List<Pergunta> perguntasNao = new List<Pergunta>();
        private List<Common.Enum.RespostaType> respostaTypeOk = new List<Common.Enum.RespostaType>();
        private List<Common.Enum.RespostaType> respostaTypeSimNao = new List<Common.Enum.RespostaType>();
        private List<Common.Enum.RespostaType> respostaTypeCancelar = new List<Common.Enum.RespostaType>();

        public HomeController()
        {
            var usuario = new Usuario("Usuário");

            respostaTypeOk.Add(RespostaType.OK);

            respostaTypeSimNao.Add(RespostaType.Sim);
            respostaTypeSimNao.Add(RespostaType.Não);

            respostaTypeCancelar.Add(RespostaType.OK);
            respostaTypeCancelar.Add(RespostaType.Cancelar);

            //questoes.Add(new Questao(1, "Pense em um prato que você goste", "", respostaTypeOk, 1, 2));
            //questoes.Add(new Questao(2, string.Format("O prato que você pensou é {0}?", "massa"), "", respostaTypeSimNao, 2, 3, 4));
            //questoes.Add(new Questao(3, string.Format("O prato que você pensou é {0}?", "lasanha"), "", respostaTypeSimNao, 5, 6, 3));
            //questoes.Add(new Questao(4, string.Format("O prato que você pensou é {0}?", "bolo de chocolate"), "", respostaTypeSimNao, 0, 4, 5));
            //questoes.Add(new Questao(5, "Qual o pra que você pensou?", "", respostaTypeCancelar, 0, 4, 6));
            //questoes.Add(new Questao(6, "Qual o pra que você pensou?", "", respostaTypeCancelar, 0, 4, 7));
            //questoes.Add(new Questao(7, "Acertei de novo", "", respostaTypeOk, 1, 0));

        }

        public IActionResult Index()
        {
            if (ViewData["PerguntasSim"] is null)
            {
                perguntas.Add(new Pergunta("Pense em um prato que você goste", respostaTypeOk));
                ViewData["Perguntas"] = perguntas;
            }
            else
            {
            //    perguntasSim.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "massa"), respostaTypeSimNao));
            //    perguntasSim.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "lasanha"), respostaTypeSimNao));
            //    perguntasNao.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "bolo de chocolate"), respostaTypeSimNao));
            //    perguntasSim.Add(new Pergunta("Acertei de novo", respostaTypeOk));

                if (true)
                {

                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(Questao valor)
        {
            if (true)
            {

            }

            return View();
        }

        public IActionResult Privacy()
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
