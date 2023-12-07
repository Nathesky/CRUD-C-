using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_nnect_SQL
{
    public partial class FormConsulta : Form
    {
        cl_ControleContato controle = new cl_ControleContato();

        public FormConsulta()
        {
            InitializeComponent();
        }

        // Evento acionado quando o botão de busca é clicado
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Verifica a opção selecionada no ComboBox
            if (CbOpcao.SelectedIndex == 0)
            {
                try
                {
                    // Tenta converter o texto da caixa de busca para um valor inteiro
                    int codigo = Convert.ToInt32(txtBusca.Text);
                    // Chama o método de pesquisa por código na controladora e atualiza o DataSource do DataGridView
                    dataGridView1.DataSource = controle.pesquisaCodigo(codigo);
                }
                catch
                {
                    // Em caso de erro na conversão, exibe uma mensagem de erro
                    MessageBox.Show("Digite um valor inteiro para o código!");
                    txtBusca.Clear();
                    txtBusca.Focus();
                }
                }
                else if (CbOpcao.SelectedIndex == 1)
                {
                    // Para a opção de pesquisa por nome, chama o método correspondente na controladora e atualiza o DataSource do DataGridView
                    string nomecontato = (txtBusca.Text);
                    dataGridView1.DataSource = controle.pesquisanome(nomecontato);
                }
                else if (CbOpcao.SelectedIndex == 2)
                {
                    // Para a opção de pesquisa por telefone, chama o método correspondente na controladora e atualiza o DataSource do DataGridView
                    string telefonecontato = (txtBusca.Text);
                    dataGridView1.DataSource = controle.pesquisatelefone(telefonecontato);
                }
                else if (CbOpcao.SelectedIndex == 3)
                {
                    // Para a opção de pesquisa por celular, chama o método correspondente na controladora e atualiza o DataSource do DataGridView
                    string celularcontato = (txtBusca.Text);
                    dataGridView1.DataSource = controle.pesquisacelular(celularcontato);
                }
                else if (CbOpcao.SelectedIndex == 4)
                {
                    // Para a opção de pesquisa por email, chama o método correspondente na controladora e atualiza o DataSource do DataGridView
                    string emailcontato = (txtBusca.Text);
                    dataGridView1.DataSource = controle.pesquisaemail(emailcontato);
                }
            }

                private void BtnListar_Click(object sender, EventArgs e)
                {
                    // Chama o método na controladora para preencher o DataGridView com todos os contatos
                    dataGridView1.DataSource = controle.PreencherTodos();
                }

                private void CbOpcao_SelectedIndexChanged(object sender, EventArgs e)
                {
                    // Verifica se há uma opção selecionada no ComboBox
                    if (CbOpcao.SelectedIndex < 0)
                    {
                        // Se não houver, desabilita a caixa de busca e o botão de busca
                        txtBusca.Enabled = false;
                        BtnBuscar.Enabled = false;
                    }
                    else
                    {
                        // Se houver, habilita a caixa de busca e a limpa, focando nela
                        txtBusca.Enabled = true;
                        txtBusca.Clear();
                        txtBusca.Focus();
                    }
                }


                private void txtBusca_TextChanged(object sender, EventArgs e)
                {
                    if (txtBusca.Text != "")
                    {
                        BtnBuscar.Enabled = true;
                    }
                    else
                    {
                        BtnBuscar.Enabled = false;
                    }
                }

        private void FormConsulta_Load(object sender, EventArgs e)
        {

        }
    }
}
