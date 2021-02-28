using BLL;
using Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaGoDev
{
    public partial class Menu : Form
    {
        PessoaBLL pBLL = new PessoaBLL();
        SalasEventoBLL sBLL = new SalasEventoBLL();
        EspacosCafeBLL eBLL = new EspacosCafeBLL();
        OcupacoesBLL oBLL = new OcupacoesBLL();

        public Menu()
        {
            try
            {
                InitializeComponent();
                dgvPessoas.DataSource = pBLL.TrazerPessoas();
                dgvSalas.DataSource = sBLL.TrazerSalas();
                dgvEspacos.DataSource = eBLL.TrazerEspacos();
                dgvOcupacoes.DataSource = oBLL.TrazerOcupacoes();
            }
            catch
            {
                throw;
            }
        }

        #region Refresh/clear
        private void LimparTudo()
        {
            FormCleaner.Clear(this);
        }

        private void picbRefresh_Click(object sender, EventArgs e)
        {
            dgvPessoas.DataSource = pBLL.TrazerPessoas();
        }

        private void picbRefresh2_Click(object sender, EventArgs e)
        {
            dgvSalas.DataSource = sBLL.TrazerSalas();
        }

        private void picbRefresh3_Click(object sender, EventArgs e)
        {
            dgvEspacos.DataSource = eBLL.TrazerEspacos();
        }

        private void picbRefresh4_Click(object sender, EventArgs e)
        {
            dgvOcupacoes.DataSource = oBLL.TrazerOcupacoes();
        }

        private void picbClear_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }

        private void picbClear2_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }

        private void picbClear3_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }

        private void picbClear4_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }
        #endregion

        #region Ao entrar em uma aba, dar refresh no DataGridView
        private void tbPessoas_Enter(object sender, EventArgs e)
        {
            dgvPessoas.DataSource = pBLL.TrazerPessoas();
        }

        private void tbSalas_Enter(object sender, EventArgs e)
        {
            dgvSalas.DataSource = sBLL.TrazerSalas();
        }

        private void tbEspacosCafe_Enter(object sender, EventArgs e)
        {
            dgvEspacos.DataSource = eBLL.TrazerEspacos();
        }

        private void tbOcupacoes_Enter(object sender, EventArgs e)
        {
            dgvOcupacoes.DataSource = oBLL.TrazerOcupacoes();
        }
        #endregion

        #region Cadastrar, atualizar, excluir

        #region Pessoa
        private void btnCadastrarPessoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pBLL.Cadastrar(new Pessoa(txtNomePessoa.Text, txtSobrenomePessoa.Text, 0, 0, 0, 0)).Message);
            dgvPessoas.DataSource = pBLL.TrazerPessoas();
        }

        private void btnExcluirPessoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pBLL.Excluir(long.Parse(txtIDPessoa.Text)).Message);
            dgvPessoas.DataSource = pBLL.TrazerPessoas();
            FormCleaner.Clear(this);
        }

        private void btnAtualizarPessoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pBLL.Atualizar(new Pessoa(long.Parse(txtIDPessoa.Text), txtNomePessoa.Text, txtSobrenomePessoa.Text)).Message);
            dgvPessoas.DataSource = pBLL.TrazerPessoas();
        }
        #endregion

        #region Sala de eventos
        private void btnCadastrarSala_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sBLL.Cadastrar(new SalasEvento(txtNomeSala.Text, int.Parse(txtLotacaoSala.Text))).Message);
            dgvSalas.DataSource = sBLL.TrazerSalas();
        }

        private void btnExcluirSala_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sBLL.Excluir(long.Parse(txtIDSala.Text)).Message);
            dgvSalas.DataSource = sBLL.TrazerSalas();
            FormCleaner.Clear(this);
        }

        private void btnAtualizarSala_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sBLL.Atualizar(new SalasEvento(long.Parse(txtIDSala.Text), txtNomeSala.Text, int.Parse(txtLotacaoSala.Text))).Message);
            dgvSalas.DataSource = sBLL.TrazerSalas();
        }
        #endregion

        #region Espaço de café
        private void btnCadastrarEspaco_Click(object sender, EventArgs e)
        {
            MessageBox.Show(eBLL.Cadastrar(new EspacosCafe(int.Parse(txtLotacaoEspaco.Text), DateTime.Parse(dtHoraInicial.Value.ToString("HH:mm")), DateTime.Parse(dtHoraFinal.Value.ToString("HH:mm")))).Message);
            dgvEspacos.DataSource = eBLL.TrazerEspacos();
        }

        private void btnExcluirEspaco_Click(object sender, EventArgs e)
        {
            MessageBox.Show(eBLL.Excluir(int.Parse(txtIDEspaco.Text)).Message);
            dgvEspacos.DataSource = eBLL.TrazerEspacos();
            FormCleaner.Clear(this);
        }

        private void btnAtualizarEspaco_Click(object sender, EventArgs e)
        {
            MessageBox.Show(eBLL.Atualizar(new EspacosCafe(int.Parse(txtIDEspaco.Text), int.Parse(txtLotacaoEspaco.Text), dtHoraInicial.Value, dtHoraFinal.Value)).Message);
            dgvEspacos.DataSource = eBLL.TrazerEspacos();
        }
        #endregion

        #region Ocupação
        private void btnCadastrarOcupacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oBLL.Cadastrar(new Ocupacao(long.Parse(txtIDPessoaOcupacao.Text), long.Parse(txtIDSalaPessoaOcupacao.Text), long.Parse(txtIDEspacoCafeOcupacao.Text))).Message); ;
            dgvOcupacoes.DataSource = oBLL.TrazerOcupacoes();
        }

        private void btnExcluirOcupacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oBLL.Excluir(long.Parse(txtIDOcupacoes.Text)).Message);
            dgvOcupacoes.DataSource = oBLL.TrazerOcupacoes();
            FormCleaner.Clear(this);
        }

        private void btnAtualizarOcupacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oBLL.Atualizar(new Ocupacao(long.Parse(txtIDPessoaOcupacao.Text), long.Parse(txtIDSalaPessoaOcupacao.Text), long.Parse(txtIDEspacoCafeOcupacao.Text))).Message);
            dgvOcupacoes.DataSource = oBLL.TrazerOcupacoes();
        }
        #endregion

        #endregion

        #region Pesquisar por ID
        private void picPesquisarPorIDPessoa_Click(object sender, EventArgs e)
        {
            dgvPessoas.DataSource = pBLL.LerPorID(long.Parse(txtIDPessoa.Text));
        }

        private void picPesquisarPorIDSala_Click(object sender, EventArgs e)
        {
            dgvSalas.DataSource = sBLL.LerPorID(long.Parse(txtIDSala.Text));
        }

        private void picPesquisarPorIDEspaco_Click(object sender, EventArgs e)
        {
            dgvEspacos.DataSource = eBLL.LerPorID(long.Parse(txtIDEspaco.Text));
        }
        #endregion

        //private void dgvPessoas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txtIDEspaco.Text = (string)dgvEspacos.Rows[e.RowIndex].Cells[0].Value;
        //    txtNomePessoa.Text = (string)dgvEspacos.Rows[e.RowIndex].Cells[1].Value;
        //    txtSobrenomePessoa.Text = (string)dgvEspacos.Rows[e.RowIndex].Cells[2].Value;
        //    txtPessoaSalaUm.Text = (string)dgvEspacos.Rows[e.RowIndex].Cells[3].Value;
        //    txtPessoaSalaDois.Text = (string)dgvEspacos.Rows[e.RowIndex].Cells[4].Value;
        //    DateTime espacoCafeEtapaUm = (DateTime)dgvEspacos.Rows[e.RowIndex].Cells[5].Value;
        //    DateTime espacoCafeEtapaDois = (DateTime)dgvEspacos.Rows[e.RowIndex].Cells[6].Value;
        //}

        //private void dgvSalas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void dgvEspacos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txtIDEspaco.Text = (string)dgvEspacos.Rows[e.RowIndex].Cells[0].Value;
        //    txtLotacaoEspaco.Text = (string)dgvEspacos.Rows[e.RowIndex].Cells[1].Value;
        //    dtHoraInicial.Value = (DateTime)dgvEspacos.Rows[e.RowIndex].Cells[2].Value;
        //    dtHoraFinal.Value = (DateTime)dgvEspacos.Rows[e.RowIndex].Cells[3].Value;

        //    dgvEspacoOcupacoes.DataSource = eBLL.TrazerEspacoCafeOcupacoes(long.Parse(txtIDEspaco.Text));
        //}

        //private void dgvOcupacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
