using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace c_nnect_SQL
{
    public partial class FormCadastro : Form
    {
        cl_Contato cont = new cl_Contato();
        cl_ControleContato controle = new cl_ControleContato();

        public FormCadastro()
        {
            InitializeComponent();
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {

        }

        // Método para limpar os campos do formulário
        private void limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Verifica se o campo de nome está vazio
            if (txtNome.Text == "")
            {
                MessageBox.Show("Digite tudo, por favor!!");
            }
            else
            {
                // Preenche as propriedades do objeto cont com os dados dos campos
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                // Exibe uma mensagem com o resultado da operação de cadastro
                MessageBox.Show(controle.cadastrar(cont));

                // Limpa os campos do formulário
                limpar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // Preenche as propriedades do objeto cont com os dados dos campos
            cont.Codcontato = int.Parse(txtCodigo.Text);
            cont.Nome = txtNome.Text;
            cont.Telefone = txtTelefone.Text;
            cont.Celular = txtCelular.Text;
            cont.Email = txtEmail.Text;

            // Exibe uma mensagem com o resultado
            MessageBox.Show(controle.alterar(cont));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Tenta buscar um contato com base no código informado
                cont = controle.buscar(int.Parse(txtCodigo.Text));

                // Se o contato não for encontrado, exibe uma mensagem
                if (cont is null)
                {
                    MessageBox.Show("Registro não encontrado!");
                }
                else
                {
                    // Preenche os campos do formulário com os dados do contato encontrado
                    txtCodigo.Text = cont.Codcontato.ToString();
                    txtNome.Text = cont.Nome;
                    txtTelefone.Text = cont.Telefone;
                    txtCelular.Text = cont.Celular;
                    txtEmail.Text = cont.Email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Preenche a propriedade do objeto cont com o código informado
            cont.Codcontato = int.Parse(txtCodigo.Text);

            // Exibe uma mensagem com o resultado da operação de exclusão
            MessageBox.Show(controle.excluir(cont));
        }

    }
}
