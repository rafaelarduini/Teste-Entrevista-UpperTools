using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Empresa
    {
        public string CNPJ { get; set; }

        public string DataSituacao { get; set; }

        public string Nome { get; set; }

        public string UF { get; set; }

        public string Telefone { get; set; }

        public string Situacao { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string CEP { get; set; }

        public string Municipio { get; set; }

        public string Porte { get; set; }

        public string Abertura { get; set; }

        public string NaturezaJuridica { get; set; }

        public string NomeFantasia { get; set; }

        public string UltimaAtualizacao { get; set; }

        public string Tipo { get; set; }

        public string Complemento { get; set; }

        public string Email { get; set; }

        public string Efr { get; set; }

        public string MotivoSituacao { get; set; }

        public string SituacaoEspecial { get; set; }

        public string DataSituacaoEspecial { get; set; }

        public decimal CapitalSocial { get; set; }

        public string AtividadePrincipal { get; set; }

        public string AtividadesSecundarias { get; set; }

        public string Qsa { get; set; }
    }
}