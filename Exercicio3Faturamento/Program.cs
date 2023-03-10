using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Exercicio3Faturamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dadosFaturamento = File.ReadAllText("dados.json");

            var vetorComFaturamento = criarVetorComRegistrosDoFaturamento(dadosFaturamento);

            Faturamento menorFaturamentoDoMes = calcularDiaComMenorValorDeFaturamentoNoMes(vetorComFaturamento);

            Console.WriteLine("O menor valor de faturamento foi " + menorFaturamentoDoMes.Valor + " reais no dia " + menorFaturamentoDoMes.Dia + " do mês");

            Faturamento maiorFaturamentoDoMes = calcularDiaComMaiorValorDeFaturamentoNoMes(vetorComFaturamento);

            Console.WriteLine("O maior valor de faturamento foi " + maiorFaturamentoDoMes.Valor + " reais no dia " + maiorFaturamentoDoMes.Dia + " do mês");

            Console.WriteLine("Foram "+ calcularDiaValorDeFaturamentoMaiorQueMediaMensalNoMes(vetorComFaturamento)+" dias no mês onde o faturamento diario foi superior a media mensal");
        }

        static Faturamento[] criarVetorComRegistrosDoFaturamento(string dadosFaturamento)
        {
            var listaComFaturamento = JsonConvert.DeserializeObject<List<Faturamento>>(dadosFaturamento);

            var vetorComFaturamento = listaComFaturamento.ToArray();

            return vetorComFaturamento;
        }

        static Faturamento calcularDiaComMenorValorDeFaturamentoNoMes(Faturamento[] vetorComFaturamento)
        {
            double menorFaturamento = 0;

            Faturamento menorFaturamentoDoMes = new Faturamento()
            {
                Dia = 0,
                Valor = 0
            };

            for(int i = 0; i < vetorComFaturamento.Length; i++)
            {
                while (menorFaturamento == 0)
                {
                    menorFaturamento = vetorComFaturamento[i].Valor;

                    menorFaturamentoDoMes.Dia = vetorComFaturamento[i].Dia;
                    menorFaturamentoDoMes.Valor = vetorComFaturamento[i].Valor;
                }

                if (vetorComFaturamento[i].Valor!=0 && (vetorComFaturamento[i].Valor < menorFaturamento))
                {
                    menorFaturamento = vetorComFaturamento[i].Valor;

                    menorFaturamentoDoMes.Dia = vetorComFaturamento[i].Dia;
                    menorFaturamentoDoMes.Valor = vetorComFaturamento[i].Valor;
                }
            }
            return menorFaturamentoDoMes;
        }

        static Faturamento calcularDiaComMaiorValorDeFaturamentoNoMes(Faturamento[] vetorComFaturamento)
        {
            double maiorFaturamento = 0;

            Faturamento maiorFaturamentoDoMes = new Faturamento()
            {
                Dia = 0,
                Valor = 0
            };

            for (int i = 0; i < vetorComFaturamento.Length; i++)
            {
                while (maiorFaturamento == 0)
                {
                    maiorFaturamento = vetorComFaturamento[i].Valor;

                    maiorFaturamentoDoMes.Dia = vetorComFaturamento[i].Dia;
                    maiorFaturamentoDoMes.Valor = vetorComFaturamento[i].Valor;
                }

                if (vetorComFaturamento[i].Valor > maiorFaturamento)
                {
                    maiorFaturamento = vetorComFaturamento[i].Valor;

                    maiorFaturamentoDoMes.Dia = vetorComFaturamento[i].Dia;
                    maiorFaturamentoDoMes.Valor = vetorComFaturamento[i].Valor;
                }
            }
            return maiorFaturamentoDoMes;
        }

        static int calcularDiaValorDeFaturamentoMaiorQueMediaMensalNoMes(Faturamento[] vetorComFaturamento)
        {
            double mediaMensalFaturamento = 0;
            int diasUteis = 0;
            int diasComValorMaiorQueMediaMensal = 0;

            for (int i = 0; i < vetorComFaturamento.Length; i++)
            {

                if (vetorComFaturamento[i].Valor != 0)
                {
                    mediaMensalFaturamento= mediaMensalFaturamento + vetorComFaturamento[i].Valor;
                    diasUteis++;
                }
            }
            mediaMensalFaturamento = mediaMensalFaturamento / diasUteis;

            for (int i = 0; i < vetorComFaturamento.Length; i++)
            {
                if (vetorComFaturamento[i].Valor > mediaMensalFaturamento)
                    diasComValorMaiorQueMediaMensal++;
            }
            return diasComValorMaiorQueMediaMensal;
        }
    }
}
