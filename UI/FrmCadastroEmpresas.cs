using Business;
using Database;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace CadastroEmpresas
{
    public partial class FrmCadastroEmpresas : Form
    {
        public FrmCadastroEmpresas()
        {
            InitializeComponent();
        }

        string URI = string.Empty;
        string cnpjEmpresa = string.Empty;

        private void btbPreencher_Click(object sender, EventArgs e)
        {
            cnpjEmpresa = txtCNPJReceitaFederal.Text;
            cnpjEmpresa = new string(cnpjEmpresa.Where(char.IsDigit).ToArray());
            if (cnpjEmpresa != string.Empty)
            {
                GetEmpresaPorCNPJ(cnpjEmpresa);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //EmpresaNegocios.Adicionar();
        }

        //Obtem dados da empresa através de um webservice
        public async void GetEmpresaPorCNPJ(string cnpjEmpresa)
        {
            using (var client = new HttpClient())
            {
                BindingSource bsEmpresa = new BindingSource();
                URI = "https://www.receitaws.com.br/v1/cnpj/" + cnpjEmpresa.ToString();

                HttpResponseMessage response = await client.GetAsync(URI);
                if (response.IsSuccessStatusCode)
                {
                    var EmpresaJson = await response.Content.ReadAsStringAsync();
                    var empresa = JsonConvert.DeserializeObject<EmpresaDados>(EmpresaJson);
                    txtCNPJFormulario.Text = empresa.Cnpj;
                    txtNome.Text = empresa.Nome;
                    foreach (AtividadePrincipalLista a in empresa.AtividadePrincipalLista)
                    {
                        txtAtividadePrincipal.Text = a.Text + " " + a.Code;
                    }

                    txtDataSituacao.Text = empresa.DataSituacao.ToString();
                    txtTipo.Text = empresa.Tipo;
                    txtSituacao.Text = empresa.Situacao;
                    txtBairro.Text = empresa.Bairro;
                    txtLogradouro.Text = empresa.Logradouro;
                    txtNumero.Text = empresa.Numero;
                    txtCEP.Text = empresa.Cep;
                    txtMunicipio.Text = empresa.Municipio;
                    txtUF.Text = empresa.Uf;
                    txtTelefone.Text = empresa.Telefone;
                    var listaAtividadesSecundarias = string.Empty;
                    foreach (AtividadesSecundariasLista a in empresa.AtividadesSecundariasLista)
                    {
                        listaAtividadesSecundarias = a.Text + " " + a.Code + " ";
                        txtAtividadesSecundarias.Text += (txtAtividadesSecundarias.Text + listaAtividadesSecundarias + " ");
                    }
                    txtPorte.Text = empresa.Porte;
                    txtDataAbertura.Text = empresa.Abertura.ToString();
                    txtNaturezaJuridica.Text = empresa.NaturezaJuridica;
                    txtNomeFantasia.Text = empresa.Fantasia;
                    txtStatus.Text = empresa.Status;
                    txtComplemento.Text = empresa.Complemento;
                    txtEmail.Text = empresa.Email;
                    txtEfr.Text = empresa.Efr;
                    txtMotivoSituacao.Text = empresa.MotivoSituacao;
                    txtSituacaoEspecial.Text = empresa.SituacaoEspecial;
                    txtDataSitucaoEspecial.Text = empresa.DataSituacaoEspecial.ToString();
                    txtCapitalSocial.Text = empresa.CapitalSocial.ToString("N2");
                    txtUltimaAtualizacao.Text = empresa.UltimaAtualizacao.ToString();
                    var listaQsa = string.Empty;
                    foreach (QsaLista a in empresa.QsaLista)
                    {
                        listaQsa = a.Qual + " " + a.Nome + " ";
                        txtQsa.Text = txtQsa.Text + listaQsa;
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao obter dados : " + response.StatusCode);
                }
            }
        }

        private void btbBuscar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            EmpresaNegocios empresaNegocios = new EmpresaNegocios();
            EmpresaColecao empresaColecao = new EmpresaColecao();

            empresaColecao = empresaNegocios.BuscarPorNome(txtNomeCNPJPesquisa.Text);

            dqvPesquisa.DataSource = null;
            dqvPesquisa.DataSource = empresaColecao;

            dqvPesquisa.Update();
            dqvPesquisa.Refresh();

        }

        private void btbExcluir_Click(object sender, EventArgs e)
        {
            if (dqvPesquisa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma empresa selecionada");
                return;
            }

            DialogResult resultado = MessageBox.Show("Tem cereteza que deseja excluir as empresas selecionadas?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            Empresa empresaSelecionado = (dqvPesquisa.SelectedRows[0].DataBoundItem as Empresa);

            EmpresaNegocios empresaNegocios = new EmpresaNegocios();
            empresaNegocios.Excluir(empresaSelecionado);

            string retorno = empresaNegocios.Excluir(empresaSelecionado);

            try
            {
                int idEmpresa = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente excluido com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Não foi possível excluir. Detalhes: " + retorno, "Erro");
                AtualizarGrid();
            }

        }

        private void btnBancoDados_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
            pnlBancoDados.Visible = true;
        }
    }
}
