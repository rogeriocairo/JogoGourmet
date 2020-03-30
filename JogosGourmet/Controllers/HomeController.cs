using Microsoft.AspNetCore.Mvc;
using JogosGourmet.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Newtonsoft.Json;

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
            if (TempData["data"] == null)
            {
                perguntas.Add(new Pergunta("Pense em um prato que você goste", "OK", Guid.Empty));
                perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "massa"), "SimNao", perguntas.Last().Id, "Sim"));
                perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "lasanha"), "SimNao", perguntas.Last().Id, "Sim"));
                perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "bolo de chocolate"), "SimNao", perguntas[1].Id, "Não"));
                perguntas.Add(new Pergunta("Acertei de novo!", "Finalizar", perguntas.Last().Id));
            }
            else
            {
                List<Pergunta> deserializedlistobj = (List<Pergunta>)JsonConvert.DeserializeObject(TempData["data"].ToString(), typeof(List<Pergunta>));

                foreach (var item in deserializedlistobj)
                {
                    perguntas.Add(new Pergunta(item.Id,  item.Enunciado, item.FormatacaoPergunta, item.RespostaId, item.RespostaType));
                }
            }

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
                var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(Guid.Parse(codigoId))).Id;
                ViewData["resposta"] = resposta;
            }
            else if (botaoNao != "")
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
            else if (botaoSim != "")
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
            ViewData["pratoNovo"] = HttpContext.Request.Form["txtNovoPrato"].ToString();

            ViewData["codigoId"] = codigoId;

            var prato = perguntas.FirstOrDefault(x => x.Id.Equals(Guid.Parse(codigoId))).Enunciado;

            ViewData["pratoAnterior"] = prato.Substring(26, prato.Length - 26);

            return View(perguntas);
        }

        public IActionResult Final(List<Pergunta> perguntas, string codigoId)
        {
            var perguntaFinal = HttpContext.Request.Form["txtFinal"].ToString();

            var perguntaAnterior = perguntas.FirstOrDefault(x => x.Id.Equals(Guid.Parse(codigoId)));

            var pergunta = perguntas.FirstOrDefault(x => x.Id.Equals(perguntaAnterior.RespostaId));

            var contador = perguntas.Count();

            for (int i = 0; i < contador; i++)
            {
                if (perguntas[i].Id == pergunta.Id)
                {
                    i++;
                    perguntas.Insert(i, new Pergunta(string.Format("O prato que você pensou é {0}?", perguntaFinal), "SimNao", pergunta.Id, "Sim"));

                }
            }

            TempData["data"] = JsonConvert.SerializeObject(perguntas);

            return RedirectToAction("Index");
        }
    }
}
