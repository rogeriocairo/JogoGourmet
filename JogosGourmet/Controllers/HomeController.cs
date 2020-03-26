using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JogosGourmet.Models;
using System.Collections.Generic;
using static JogosGourmet.Common.Enum;
using Microsoft.AspNetCore.Http;
using System;
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
            if (ViewData["Perguntas"] is null)
            {
                perguntas.Add(new Pergunta("Pense em um prato que você goste", respostaTypeOk, Guid.Empty));
                perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "massa"), respostaTypeSimNao, perguntas.Last().Id, RespostaType.Sim));
                perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "lasanha"), respostaTypeSimNao, perguntas.Last().Id, RespostaType.Sim));
                perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "bolo de chocolate"), respostaTypeSimNao, perguntas.Last().Id, RespostaType.Não));
                perguntas.Add(new Pergunta("Acertei de novo!", respostaTypeOk, perguntas.Last().Id));

                ViewData["resposta"] = perguntas.First().Id;
            }

            return View(perguntas);
        }

        [HttpPost]
        public IActionResult Positivo(List<Pergunta> perguntas)
        {
            try
            {
                var numero = HttpContext.Request.Form["BotaoOK"].ToString();
                var tipo = HttpContext.Request.Form["BotaoOK"].ToString();
                var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(numero) && x.RespostaType.Equals(RespostaType.Sim));
                ViewData["resposta"] = resposta.Id;
                ViewData["Perguntas"] = perguntas;
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            return View("CalPage");
        }

        [HttpPost]
        public IActionResult Post(List<Pergunta> perguntas)
        {
            try
            {
                var CodigoId = Guid.Parse(HttpContext.Request.Form["BotaoOK"].ToString());

                ViewData["resposta"] = perguntas.FirstOrDefault(x => x.RespostaId.Equals(CodigoId)).Id;
                ViewData["Perguntas"] = perguntas;
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }

            return Redirect("/Home");
        }

        public IActionResult Resultado()
        {
            try
            {
                var CodigoId = Guid.Parse(HttpContext.Request.Form["BotaoOK"].ToString());

                var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(CodigoId));

                ViewData["resposta"] = resposta.Id;
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }

            return Redirect("/Home/");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
