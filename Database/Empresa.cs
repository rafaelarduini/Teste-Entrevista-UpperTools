using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Empresa : Base
    {
        public string Cnpj { get; set; }
        public string AtividadePrincipal { get; set; }

        public string AtividadesSecundarias { get; set; }

        public string Qsa { get; set; }
    }
}