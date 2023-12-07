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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        // Criando instâncias dos formulários e da classe de login
        FormPrincipal formPrincipal = new FormPrincipal();
        cl_Login lgn = new cl_Login();

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Verifica se os campos de login e senha estão vazios
            if (txtLogin.Text == "" || txtSenha.Text == "")
            {
                // Exibe uma mensagem de erro caso algum dos campos esteja vazio
                MessageBox.Show("Digite Login e senha para acessar o sistema!!!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Chama o método Logar da classe cl_Login para verificar as credenciais
                    bool logar = lgn.Logar(txtLogin.Text, txtSenha.Text);

                    // Se login e senha são válidos, oculta o formulário de login e exibe o formulário principal
                    if (logar)
                    {
                        this.Hide();
                        formPrincipal.Show();
                    }
                    else
                    {
                        // Exibe uma mensagem de erro se login e senha não são válidos
                        MessageBox.Show("Login e/ou senha inválidos!!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Limpa os campos de login e senha e foca no campo de login
                        txtLogin.Clear();
                        txtSenha.Clear();
                        txtLogin.Focus();
                    }
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro em caso de exceção
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
    

