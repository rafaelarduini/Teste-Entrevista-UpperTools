using Business;
using Database;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
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

            Empresa empresa = new Empresa();
            empresa.Cnpj = txtCNPJFormulario.Text;
            empresa.Nome = txtNome.Text;
            empresa.AtividadePrincipal = txtAtividadePrincipal.Text;
            empresa.DataSituacao = txtDataSituacao.Text;
            empresa.Tipo = txtTipo.Text;
            empresa.Situacao = txtSituacao.Text;
            empresa.Logradouro = txtLogradouro.Text;
            empresa.Numero = txtNumero.Text;
            empresa.Bairro = txtBairro.Text;
            empresa.Cep = txtCEP.Text;
            empresa.Municipio = txtMunicipio.Text;
            empresa.Uf = txtUF.Text;
            empresa.Telefone = txtTelefone.Text;
            empresa.AtividadesSecundarias = txtAtividadesSecundarias.Text;
            empresa.Porte = txtPorte.Text;
            empresa.Abertura = txtDataAbertura.Text;
            empresa.NaturezaJuridica = txtNaturezaJuridica.Text;
            empresa.Fantasia = txtNomeFantasia.Text;
            empresa.Status = txtStatus.Text;
            empresa.Complemento = txtComplemento.Text;
            empresa.Email = txtEmail.Text;
            empresa.Efr = txtEfr.Text;
            empresa.MotivoSituacao = txtMotivoSituacao.Text;
            empresa.SituacaoEspecial = txtSituacaoEspecial.Text;
            empresa.DataSituacaoEspecial = txtDataSitucaoEspecial.Text;
            empresa.CapitalSocial = Convert.ToDecimal(txtCapitalSocial.Text);
            empresa.UltimaAtualizacao = txtCNPJFormulario.Text;
            empresa.Qsa = txtCNPJFormulario.Text;

            EmpresaNegocios empresaNegocios = new EmpresaNegocios();

            string retorno = empresaNegocios.Adicionar(empresa);

            MessageBox.Show("Empresa cadastrada com sucesso: " + retorno.ToString());

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
                    EmpresaDados empresaDados = JsonConvert.DeserializeObject<EmpresaDados>(EmpresaJson);
                    txtCNPJFormulario.Text = empresaDados.Cnpj;
                    txtNome.Text = empresaDados.Nome;
                    foreach (AtividadePrincipalLista a in empresaDados.AtividadePrincipalLista)
                    {
                        txtAtividadePrincipal.Text = a.Text + " " + a.Code;
                    }

                    txtDataSituacao.Text = empresaDados.DataSituacao.ToString();
                    txtTipo.Text = empresaDados.Tipo;
                    txtSituacao.Text = empresaDados.Situacao;
                    txtBairro.Text = empresaDados.Bairro;
                    txtLogradouro.Text = empresaDados.Logradouro;
                    txtNumero.Text = empresaDados.Numero;
                    txtCEP.Text = empresaDados.Cep;
                    txtMunicipio.Text = empresaDados.Municipio;
                    txtUF.Text = empresaDados.Uf;
                    txtTelefone.Text = empresaDados.Telefone;
                    var listaAtividadesSecundarias = string.Empty;
                    foreach (AtividadesSecundariasLista a in empresaDados.AtividadesSecundariasLista)
                    {
                        listaAtividadesSecundarias = a.Text + " " + a.Code + " ";
                        txtAtividadesSecundarias.Text += (txtAtividadesSecundarias.Text + listaAtividadesSecundarias + " ");
                    }
                    txtPorte.Text = empresaDados.Porte;
                    txtDataAbertura.Text = empresaDados.Abertura.ToString();
                    txtNaturezaJuridica.Text = empresaDados.NaturezaJuridica;
                    txtNomeFantasia.Text = empresaDados.Fantasia;
                    txtStatus.Text = empresaDados.Status;
                    txtComplemento.Text = empresaDados.Complemento;
                    txtEmail.Text = empresaDados.Email;
                    txtEfr.Text = empresaDados.Efr;
                    txtMotivoSituacao.Text = empresaDados.MotivoSituacao;
                    txtSituacaoEspecial.Text = empresaDados.SituacaoEspecial;
                    txtDataSitucaoEspecial.Text = empresaDados.DataSituacaoEspecial.ToString();
                    txtCapitalSocial.Text = empresaDados.CapitalSocial.ToString("N2");
                    txtUltimaAtualizacao.Text = empresaDados.UltimaAtualizacao.ToString();
                    var listaQsa = string.Empty;
                    foreach (QsaLista a in empresaDados.QsaLista)
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

            MessageBox.Show("Cliente excluido com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBancoDados_Click(object sender, EventArgs e)
        {
            txtNomeCNPJPesquisa.Text = string.Empty;
            pnlBancoDados.Visible = true;
            AtualizarGrid();
        }

        // Permite movimentação do Panel

        Point PanelMouseDownLocation;

        private void pnlBancoDados_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            {

                pnlBancoDados.Left += e.X - PanelMouseDownLocation.X;

                pnlBancoDados.Top += e.Y - PanelMouseDownLocation.Y;

            }
        }

        private void pnlBancoDados_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) PanelMouseDownLocation = e.Location;
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            pnlBancoDados.Visible = false;
        }

        // txtCapitalSocial aceita apenas Números e Decimal

        private void txtCapitalSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
        }
    }
}
