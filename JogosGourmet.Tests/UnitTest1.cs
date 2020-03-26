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

        [Fact]
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
    }
}
