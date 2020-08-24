using Newtonsoft.Json;
using System.Collections.Generic;

namespace Database
{
    public class EmpresaDados
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("data_situacao")]
        public string DataSituacao { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("porte")]
        public string Porte { get; set; }

        [JsonProperty("abertura")]
        public string Abertura { get; set; }

        [JsonProperty("natureza_juridica")]
        public string NaturezaJuridica { get; set; }

        [JsonProperty("fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty("ultima_atualizacao")]
        public string UltimaAtualizacao { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("efr")]
        public string Efr { get; set; }

        [JsonProperty("motivo_situacao")]
        public string MotivoSituacao { get; set; }

        [JsonProperty("situacao_especial")]
        public string SituacaoEspecial { get; set; }

        [JsonProperty("data_situacao_especial")]
        public string DataSituacaoEspecial { get; set; }

        [JsonProperty("capital_social")]
        public decimal CapitalSocial { get; set; }

        [JsonProperty("atividade_principal")]
        public List<AtividadePrincipalLista> AtividadePrincipalLista { get; set; }

        [JsonProperty("atividades_secundarias")]
        public List<AtividadesSecundariasLista> AtividadesSecundariasLista { get; set; }

        [JsonProperty("qsa")]
        public List<QsaLista> QsaLista { get; set; }

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
}
