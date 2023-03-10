using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio3Faturamento
{
    public class Faturamento
    {
        [JsonProperty("dia")]
        public int Dia { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }

    }
}
