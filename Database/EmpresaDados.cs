using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class EmpresaDados : Base
    {
        [JsonProperty("atividade_principal")]
        public List<AtividadePrincipalLista> AtividadePrincipalLista { get; set; }

        [JsonProperty("atividades_secundarias")]
        public List<AtividadesSecundariasLista> AtividadesSecundariasLista { get; set; }

        [JsonProperty("qsa")]
        public List<QsaLista> QsaLista { get; set; }

        [JsonProperty("extra")]
        public Extra Extra { get; set; }
    }

    public abstract class Modelo
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }


    public class AtividadesSecundariasLista : Modelo
    {

    }
    public class AtividadePrincipalLista : Modelo
    {

    }
    public class QsaLista
    {
        [JsonProperty("qual")]
        public string Qual { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }
    }

    public class Extra
    {

    }
}
