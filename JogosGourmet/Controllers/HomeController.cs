using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JogosGourmet.Models;
using System.Collections.Generic;
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
        private List<string> respostaTypeOk = new List<string>();
        private List<string> respostaTypeSimNao = new List<string>();
        private List<string> respostaTypeCancelar = new List<string>();

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            perguntas.Add(new Pergunta("Pense em um prato que você goste", "OK", Guid.Empty));
            perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "massa"), "SimNao", perguntas.Last().Id, "Sim"));
            perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "lasanha"), "SimNao", perguntas.Last().Id, "Sim"));
            perguntas.Add(new Pergunta(string.Format("O prato que você pensou é {0}?", "bolo de chocolate"), "SimNao", perguntas.Last().Id, "Não"));
            perguntas.Add(new Pergunta("Acertei de novo!", "Ok", perguntas.Last().Id));

            ViewData["resposta"] = perguntas.First().Id;

            return View(perguntas);
        }

        [HttpPost]
        public IActionResult Positivo(List<Pergunta> perguntas)
        {
            try
            {
                var numero = HttpContext.Request.Form["BotaoOK"].ToString();
                var tipo = HttpContext.Request.Form["BotaoOK"].ToString();
                var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(numero) && x.RespostaType.Equals("Sim"));
                ViewData["resposta"] = resposta.Id;
                ViewData["perguntas"] = perguntas;
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Post(List<Pergunta> perguntas)
        {
            var CodigoId = Guid.Parse(HttpContext.Request.Form["BotaoOK"].ToString());

            ViewData["resposta"] = perguntas.FirstOrDefault(x => x.RespostaId.Equals(CodigoId)).Id;
            ViewData["Perguntas"] = perguntas;


            return View(perguntas);
        }

        public IActionResult Resultado()
        {
            try
            {
                var CodigoId = Guid.Parse(HttpContext.Request.Form["BotaoOK"].ToString());

                // var resposta = perguntas.FirstOrDefault(x => x.RespostaId.Equals(CodigoId));

                //ViewData["resposta"] = resposta.Id;
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
