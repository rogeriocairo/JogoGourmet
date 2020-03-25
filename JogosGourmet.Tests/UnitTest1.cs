using JogosGourmet.Common;
using JogosGourmet.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace JogosGourmet.Tests
{
    public class UnitTest1
    {
        private List<Pergunta> perguntasSim = new List<Pergunta>();
        private List<Pergunta> perguntasNao = new List<Pergunta>();


        public UnitTest1()
        {
           
        }

        [Fact]
        public void Test1()
        {
            //var respostas = 
            //var usuario = new Usuario { Nome = "Teste", };


        }

        public void Teste()
        {
            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string TesteSwitch(int opcao)
        {
            var msg = "";

            switch (opcao)
            {
                case 0:
                    var msg1 =  "Operação realizada com sucesso."  ;
                    break;
                case -1:
                    var msg2 = "Nenhum item foi encontrado para realizar a operação.";
                    break;
                case -2:
                    var msg3 = "Operação cancelada  pelo  usuário.";
                    break;                
            }            
        }
    }
}
