using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Exercicio4Faturamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dadosFaturamento = File.ReadAllText("dadosExercicio4.json");

            var vetorComFaturamento = criarVetorComRegistrosDoFaturamento(dadosFaturamento);

            var vetorComFaturamentoComPercentualPorEstado = calcularPercentualFaturamentoPorEstado(vetorComFaturamento);

            foreach(var percentualFaturamentoPorEstado in vetorComFaturamentoComPercentualPorEstado)
            {
                Console.WriteLine("O estado " + percentualFaturamentoPorEstado.Estado + " obteve " + String.Format("{0:0.##}", percentualFaturamentoPorEstado.PercentualFaturamento) + "% do faturamento mensal total da empresa");

            }

        }

        static Faturamento[] criarVetorComRegistrosDoFaturamento(string dadosFaturamento)
        {
            var listaComFaturamento = JsonConvert.DeserializeObject<List<Faturamento>>(dadosFaturamento);

            var vetorComFaturamento = listaComFaturamento.ToArray();

            return vetorComFaturamento;
        }

        static double calcularValorMensalTotalDaDistribuidora(Faturamento[] faturamentos)
        {
            double valorMensalTotalFaturamento = 0;

            foreach (var faturamento in faturamentos)
                valorMensalTotalFaturamento = valorMensalTotalFaturamento + faturamento.Valor;

            return valorMensalTotalFaturamento;
        }

        static Faturamento[] calcularPercentualFaturamentoPorEstado(Faturamento[] faturamentos)
        {
            var valorMensalTotalFaturamento = calcularValorMensalTotalDaDistribuidora(faturamentos);

            foreach (var faturamento in faturamentos)
                faturamento.PercentualFaturamento = (faturamento.Valor/valorMensalTotalFaturamento)*100;

            return faturamentos;
        }
    }
}
