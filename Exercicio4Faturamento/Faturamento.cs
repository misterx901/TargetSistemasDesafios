using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio4Faturamento
{
    public class Faturamento
    {
        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }

        [JsonProperty("percentual")]
        public double PercentualFaturamento { get; set; }

    }
}
