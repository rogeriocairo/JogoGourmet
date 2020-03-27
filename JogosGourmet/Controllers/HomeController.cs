using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JogosGourmet.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace JogosGourmet.Controllers
{
    public class HomeController : Controller
    {
        private List<Pergunta> perguntas = new List<Pergunta>();

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            perguntas.Add(new Pergunta("Pense em um prato que você goste", "OK", Guid.Empty));
            perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "massa"), "SimNao", perguntas.Last().Id, "Sim"));
            perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "lasanha"), "SimNao", perguntas.Last().Id, "Sim"));
            perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "bolo de chocolate"), "SimNao", perguntas[1].Id, "Não"));
            perguntas.Add(new Pergunta("Acertei de novo!", "Finalizar", perguntas.Last().Id));

            ViewData["resposta"] = perguntas.First().Id;

            return View(perguntas);
        }

        [HttpPost]
        public IActionResult Post(List<Pergunta> perguntas, string codigoId)
        {
            var botaoOK = HttpContext.Request.Form["BotaoOK"].ToString();
            var botaoNao = HttpContext.Request.Form["BotaoNao"].ToString();
            var botaoSim = HttpContext.Request.Form["BotaoSim"].ToString();

            if (botaoOK != "")
            {
                var CodigoId = Guid.Parse(botaoOK);
                var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(CodigoId)).Id;
                ViewData["resposta"] = resposta;
            }

            if (botaoNao != "")
            {
                var CodigoId = Guid.Parse(botaoNao);
                var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(CodigoId) && x.RespostaType == "Não");

                if (resposta is null)
                {
                    ViewData["Perguntas"] = perguntas;
                    ViewData["CodigoId"] = codigoId;                    

                    return View("Pergunta");                    
                }
                else
                {
                    ViewData["resposta"] = resposta.Id;
                }
            }

            if (botaoSim != "")
            {
                var CodigoId = Guid.Parse(botaoSim);
                var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(CodigoId) && x.RespostaType == "Sim");

                if (resposta is null)
                {
                    ViewData["resposta"] = perguntas.Last().Id;
                }
                else
                {
                    ViewData["resposta"] = resposta.Id;
                }
            }

            ViewData["Perguntas"] = perguntas;

            return View(perguntas);
        }

        public IActionResult Pergunta()
        {
            ViewData["novoPrato"] = HttpContext.Request.Form["txtNovoPrato"].ToString();
            return View(perguntas);
        }

        public IActionResult Novo(List<Pergunta> perguntas, string codigoId)
        {
            var test = ViewData["Perguntas"];
            var test2 = ViewData["CodigoId"];

            return View(perguntas);
        }
    }
}
