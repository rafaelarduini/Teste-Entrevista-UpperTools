using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmpresaNegocios
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Adicionar(Empresa empresa)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@CNPJ", empresa.Cnpj);
                acessoDadosSqlServer.AdicionarParametros("@Nome", empresa.Nome);
                acessoDadosSqlServer.AdicionarParametros("@AtividadePrincipal", empresa.AtividadePrincipal);
                acessoDadosSqlServer.AdicionarParametros("@DataSituacao", empresa.DataSituacao);
                acessoDadosSqlServer.AdicionarParametros("@Tipo", empresa.Tipo);
                acessoDadosSqlServer.AdicionarParametros("@Situacao", empresa.Situacao);
                acessoDadosSqlServer.AdicionarParametros("@Numero", empresa.Numero);
                acessoDadosSqlServer.AdicionarParametros("@CEP", empresa.Cep);
                acessoDadosSqlServer.AdicionarParametros("@Municipio", empresa.Municipio);
                acessoDadosSqlServer.AdicionarParametros("@UF", empresa.Uf);
                acessoDadosSqlServer.AdicionarParametros("@AtividadesSecundarias", empresa.AtividadesSecundarias);
                acessoDadosSqlServer.AdicionarParametros("@Porte", empresa.Porte);
                acessoDadosSqlServer.AdicionarParametros("@DataAbertura", empresa.Abertura);
                acessoDadosSqlServer.AdicionarParametros("@NaturezaJuridica", empresa.NaturezaJuridica);
                acessoDadosSqlServer.AdicionarParametros("@NomeFantasia", empresa.Fantasia);
                acessoDadosSqlServer.AdicionarParametros("@StatusEmpresa", empresa.Status);
                acessoDadosSqlServer.AdicionarParametros("@Complemento", empresa.Complemento);
                acessoDadosSqlServer.AdicionarParametros("@Email", empresa.Email);
                acessoDadosSqlServer.AdicionarParametros("@Efr", empresa.Efr);
                acessoDadosSqlServer.AdicionarParametros("@MotivoSituacao", empresa.MotivoSituacao);
                acessoDadosSqlServer.AdicionarParametros("@SituacaoEspecial", empresa.SituacaoEspecial);
                acessoDadosSqlServer.AdicionarParametros("@CapitalSocial", empresa.CapitalSocial);
                acessoDadosSqlServer.AdicionarParametros("@UltimaAtualizacao", empresa.UltimaAtualizacao);
                acessoDadosSqlServer.AdicionarParametros("@Qsa", empresa.Qsa);
                string idEmpresa = acessoDadosSqlServer.ExecutarManipulcao(CommandType.StoredProcedure, "uspEmpresaAdicionar").ToString();

                return idEmpresa;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string Excluir(Empresa empresa)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdEmpresa", empresa.IdEmpresa);
                string idEmpresa = acessoDadosSqlServer.ExecutarManipulcao(CommandType.StoredProcedure, "uspEmpresaExcluir").ToString();

                return idEmpresa;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public EmpresaColecao BuscarPorNome(string nome)
        {
            try
            {
                EmpresaColecao empresaColecao = new EmpresaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", nome);

                DataTable dataTableEmpresa = acessoDadosSqlServer.ExecutarBusca(CommandType.StoredProcedure, "uspEmpresaBuscarPorNome");

                foreach (DataRow linha in dataTableEmpresa.Rows)
                {
                    Empresa empresa = new Empresa();
                    empresa.IdEmpresa = Convert.ToInt32(linha["IdEmpresa"]);
                    empresa.Cnpj = Convert.ToString(linha["CNPJ"]);
                    empresa.Nome = Convert.ToString(linha["Nome"]);
                    empresa.AtividadePrincipal = Convert.ToString(linha["AtividadePrincipal"]);
                    empresa.DataSituacao = Convert.ToString(linha["DataSituacao"]);
                    empresa.Tipo = Convert.ToString(linha["Tipo"]);
                    empresa.Situacao = Convert.ToString(linha["Situacao"]);
                    empresa.Logradouro = Convert.ToString(linha["Logradouro"]);
                    empresa.Numero = Convert.ToString(linha["Numero"]);
                    empresa.Bairro = Convert.ToString(linha["Bairro"]);
                    empresa.Cep = Convert.ToString(linha["CEP"]);
                    empresa.Municipio = Convert.ToString(linha["Municipio"]);
                    empresa.Uf = Convert.ToString(linha["UF"]);
                    empresa.Telefone = Convert.ToString(linha["Telefone"]);
                    empresa.AtividadesSecundarias = Convert.ToString(linha["CNPJ"]);
                    empresa.Porte = Convert.ToString(linha["Porte"]);
                    empresa.Abertura = Convert.ToString(linha["DataAbertura"]);
                    empresa.NaturezaJuridica = Convert.ToString(linha["NaturezaJuridica"]);
                    empresa.Fantasia = Convert.ToString(linha["NomeFantasia"]);
                    empresa.Status = Convert.ToString(linha["StatusEmpresa"]);
                    empresa.Complemento = Convert.ToString(linha["Complemento"]);
                    empresa.Email = Convert.ToString(linha["Email"]);
                    empresa.Efr = Convert.ToString(linha["Efr"]);
                    empresa.MotivoSituacao = Convert.ToString(linha["MotivoSituacao"]);
                    empresa.SituacaoEspecial = Convert.ToString(linha["SituacaoEspecial"]);
                    empresa.DataSituacaoEspecial = Convert.ToString(linha["DataSituacaoEspecial"]);
                    empresa.CapitalSocial = Convert.ToDecimal(linha["CapitalSocial"]);
                    empresa.UltimaAtualizacao = Convert.ToString(linha["UltimaAtualizacao"]);
                    empresa.Qsa = Convert.ToString(linha["SituacaoEspecial"]);

                    empresaColecao.Add(empresa);
                }

                return empresaColecao;

            }
            catch (Exception exception)
            {
                throw new Exception("Não foi possível buscar a empresa por nome. Detalher: " + exception.Message);
            }
        }

        public EmpresaColecao BuscarPorCNPJ(string cnpj)
        {
            try
            {
                EmpresaColecao empresaColecao = new EmpresaColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@CNPJ", cnpj);

                DataTable dataTableEmpresa = acessoDadosSqlServer.ExecutarBusca(CommandType.StoredProcedure, "uspEmpresaBuscarPorCNPJ");

                foreach (DataRow linha in dataTableEmpresa.Rows)
                {
                    Empresa empresa = new Empresa();
                    empresa.IdEmpresa = Convert.ToInt32(linha["IdEmpresa"]);
                    empresa.Cnpj = Convert.ToString(linha["CNPJ"]);
                    empresa.Nome = Convert.ToString(linha["Nome"]);
                    //empresa.AtividadePrincipal = Convert.ToString(linha["AtividadePrincipal"]);
                    empresa.DataSituacao = Convert.ToString(linha["DataSituacao"]);
                    empresa.Tipo = Convert.ToString(linha["Tipo"]);
                    empresa.Situacao = Convert.ToString(linha["Situacao"]);
                    empresa.Logradouro = Convert.ToString(linha["Logradouro"]);
                    empresa.Numero = Convert.ToString(linha["Numero"]);
                    empresa.Bairro = Convert.ToString(linha["Bairro"]);
                    empresa.Cep = Convert.ToString(linha["CEP"]);
                    empresa.Municipio = Convert.ToString(linha["Municipio"]);
                    empresa.Uf = Convert.ToString(linha["UF"]);
                    empresa.Telefone = Convert.ToString(linha["Telefone"]);
                    //empresa.AtividadesSecundarias = Convert.ToString(linha["CNPJ"]);
                    empresa.Porte = Convert.ToString(linha["Porte"]);
                    empresa.Abertura = Convert.ToString(linha["DataAbertura"]);
                    empresa.NaturezaJuridica = Convert.ToString(linha["NaturezaJuridica"]);
                    empresa.Fantasia = Convert.ToString(linha["NomeFantasia"]);
                    empresa.Status = Convert.ToString(linha["StatusEmpresa"]);
                    empresa.Complemento = Convert.ToString(linha["Complemento"]);
                    empresa.Email = Convert.ToString(linha["Email"]);
                    empresa.Efr = Convert.ToString(linha["Efr"]);
                    empresa.MotivoSituacao = Convert.ToString(linha["MotivoSituacao"]);
                    empresa.SituacaoEspecial = Convert.ToString(linha["SituacaoEspecial"]);
                    empresa.DataSituacaoEspecial = Convert.ToString(linha["DataSituacaoEspecial"]);
                    empresa.CapitalSocial = Convert.ToDecimal(linha["CapitalSocial"]);
                    empresa.UltimaAtualizacao = Convert.ToString(linha["UltimaAtualizacao"]);
                    //empresa.Qsa = Convert.ToString(linha["SituacaoEspecial"]);

                    empresaColecao.Add(empresa);


                }

                return empresaColecao;

            }
            catch (Exception exception)
            {
                throw new Exception("Não foi possível buscar a empresa por nome. Detalher: " + exception.Message);
            }
        }
    }
}
